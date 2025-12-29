using Microsoft.AspNetCore.Mvc;
using WebApplication1.ModelsDTO;

namespace WebApplication1.IRepository
{
    public interface ILambdaExpressionExample
    {
        public Task<MessageHelperRecord> LambdaExpressionExampleCheck(Tuple<long, string, string> information);
        public Task<MessageHelperRecord> LambdaExpressionExampleCallBack(Tuple<long, string, string> information);
        public Task<MessageHelperRecord> DeligateInstateOfIfElse(long Number);
    }
}
