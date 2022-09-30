namespace Oechsle.Api.CrossCutting.Dto
{
    public class RegisterEmployeeDto
    {
        public string employee_name { get; set; }
        public decimal employee_salary { get; set; }
        public int employee_age { get; set; } 
        public string profile_image { get; set; }
    }

    public class UpdateEmployeeDto
    {
        public int id { get; set; }
        public RegisterEmployeeDto Employee { get; set; }
    } 
}
