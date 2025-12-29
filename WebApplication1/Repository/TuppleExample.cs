using WebApplication1.IRepository;
using WebApplication1.ModelsDTO;

namespace WebApplication1.Repository
{
    public class TuppleExample : ITuppleExample
    {
        public List<StudentInformation> StudentInfor { get; set; }
        public TuppleExample() { 
            StudentInfor = new List<StudentInformation>();
        }

        public async Task<Tuple<StudentInformation, StudentInformation>> SaveToListWithTuple(Tuple<int , string , string> StdInfo)
        {
            try
            {
                StudentInformation nwStudent = new StudentInformation 
                {
                    StudentId = StdInfo.Item1,
                    StudentName = StdInfo.Item2,
                    StudentEmail = StdInfo.Item3,
                };

                StudentInfor.Add(nwStudent);

                //return new Tuple<int, string>(200, "Successfull");
                return new Tuple<StudentInformation, StudentInformation>(nwStudent, nwStudent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<MessageHelper> SaveToListWithClass(StudentInformation StdInfo)
        {
            try
            {
                StudentInfor.Add(StdInfo);
                return new MessageHelper
                {
                    statusCode = 200,
                    Message = "Successfull"
                };
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Task SaveToListWithInOutParameter(int StudentId, string StudentName, string  StudentEmail, out long statusCode, out string message)
        {
            try
            {
                var newStudent = new StudentInformation
                {
                    StudentId = StudentId,
                    StudentName = StudentName,
                    StudentEmail = StudentEmail,
                };

                StudentInfor.Add(newStudent);

                statusCode = 200;
                message = "Successfull";

                return Task.CompletedTask;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
