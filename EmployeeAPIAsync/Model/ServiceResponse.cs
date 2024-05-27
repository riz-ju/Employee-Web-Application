namespace EmployeeAPIAsync.Model
{
    public class ServiceResponse
    {
        public object? Data { get; set; }
        public bool success { get; set; }
        public string message { get; set; } = string.Empty;
    }
}
