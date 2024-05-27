namespace EmployeeAPIAsync.Dtos
{
    public class AddEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public string Code { get; set; }
    }
}
