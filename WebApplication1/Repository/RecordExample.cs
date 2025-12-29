using WebApplication1.IRepository;
using WebApplication1.ModelsDTO;

namespace WebApplication1.Repository
{
    public class RecordExample : IRecordExample
    {
        public async Task<MessageHelperRecord> Compare_Records(Tuple<long, string, string> information)
        {
            try
            {
                EmployeeInformation recordInfo1 = new EmployeeInformation(information.Item1,information.Item2,information.Item3);
                EmployeeInformation recordInfo2 = recordInfo1 with { EmployeeEmail = recordInfo1.EmployeeName + "@gmail.com" };

                EmployeeInformation recordInfo3 = recordInfo2 with { EmployeeEmail = recordInfo1.EmployeeEmail };

                if(recordInfo1 == recordInfo3)
                {
                    (long EmployeeId, string EmployeeName, string Email) = recordInfo1;
                    MessageHelperRecord response = new MessageHelperRecord(200, "Two Records are equlas");
                    return response;
                }

                MessageHelperRecord responseNotEqual = new MessageHelperRecord(500, "Two Records are not Equals");
                return responseNotEqual;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<MessageHelperRecord> CompareClassNotEquals(Tuple<long, string, string> information)
        {
            try
            {
                StudentInformation recordInfo1 = new StudentInformation
                {
                    StudentId = (int)information.Item1,
                    StudentName = information.Item2,
                    StudentEmail = information.Item3,
                };

                StudentInformation recordCopy = new StudentInformation
                {
                    StudentId = recordInfo1.StudentId,
                    StudentName = recordInfo1.StudentName,
                    StudentEmail = recordInfo1.StudentName + "@gmail.com",
                };


                StudentInformation recordInfo2 = new StudentInformation
                {
                    StudentId = (int)information.Item1,
                    StudentName = information.Item2,
                    StudentEmail = information.Item3,
                };

                if(recordInfo1 == recordInfo2)
                {
                    MessageHelperRecord response = new MessageHelperRecord(200, "Two Classes are equlas");
                    return response;
                }
                MessageHelperRecord responseNotEqual = new MessageHelperRecord(500, "Two Classes are equlas");
                return responseNotEqual;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<MessageHelperRecord> CompareClassEquals(Tuple<long, string, string> information)
        {
            try
            {
                StudentInformation recordInfo1 = new StudentInformation
                {
                    StudentId = (int)information.Item1,
                    StudentName = information.Item2,
                    StudentEmail = information.Item3,
                };

                
                StudentInformation recordInfo2 = new StudentInformation
                {
                    StudentId = (int)information.Item1,
                    StudentName = information.Item2,
                    StudentEmail = information.Item3,
                };

                if( recordInfo1.StudentId == recordInfo2.StudentId && recordInfo1.StudentName == recordInfo2.StudentName && recordInfo1.StudentEmail == recordInfo2.StudentEmail)
                {
                    MessageHelperRecord response = new MessageHelperRecord(200, "Two Classes are equlas");
                    return response;
                }
                MessageHelperRecord responseNotEqual = new MessageHelperRecord(500, "Two Classes are equlas");
                return responseNotEqual;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
