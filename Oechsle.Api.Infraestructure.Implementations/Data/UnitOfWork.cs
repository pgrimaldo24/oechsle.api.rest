﻿using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using Oechsle.Api.CrossCutting.Common;
using Oechsle.Api.Infraestructure.Interfaces.Data;
using System;
using System.Threading.Tasks;

namespace Oechsle.Api.Infraestructure.Implementations.Data
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly AppSetting settings;
        private bool _disposed;
        private readonly ILifetimeScope _lifetimeScope;
        private IDbContextTransaction _transaction;

        public Func<DateTime> CurrentDateTime { get; set; } = () => DateTime.Now;

        public UnitOfWork(IOptions<AppSetting> settings, IHttpContextAccessor httpContext, ILifetimeScope lifetimeScope)
        {
            this.settings = settings.Value;
            _context = new DataContext(new DbContextOptionsBuilder<DataContext>().UseSqlServer(this.settings.ConnectionStrings.DefaultConnectionSQL).Options, httpContext);
            _httpContext = httpContext;
            _lifetimeScope = lifetimeScope;
        }

        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                {
                    _context.Dispose();
                }

            _disposed = true;
        }

        public DbContext Get()
        {
            return _context;
        }

        public T Repository<T>() where T : class
        {
            return _lifetimeScope.Resolve<T>(new NamedParameter("context", _context));
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangeTransaction()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }
    }
}
