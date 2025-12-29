namespace WebApplication1.ModelsDTO
{
    public class StudentInformation
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
    }
    public class MessageHelper
    {
        public long statusCode { get; set; }
        public string Message { get; set; }
    }


    public record EmployeeInformation(long EmployeeId, string EmployeeName, string EmployeeEmail);
    public record MessageHelperRecord(long statusCode , string Message);
}
