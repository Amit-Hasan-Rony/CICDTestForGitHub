using WebApplication1.ModelsDTO;
using WebApplication1.Repository;

namespace WebApplication1.IRepository
{
    public interface ITuppleExample
    {
        public Task<Tuple<StudentInformation, StudentInformation>> SaveToListWithTuple(Tuple<int, string, string> StdInfo);
        public Task<MessageHelper> SaveToListWithClass(StudentInformation StdInfo);
        public Task SaveToListWithInOutParameter(int StudentId, string StudentName, string StudentEmail, out long statusCode, out string message);
    }
}
