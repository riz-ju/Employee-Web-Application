namespace Employee.Web.Models
{
    public class ServiceResponse
    {
        public object Data { get; set; }
        public bool success { get; set; }
        public string message { get; set; } = string.Empty;
    }
}
