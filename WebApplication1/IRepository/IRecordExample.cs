using WebApplication1.ModelsDTO;

namespace WebApplication1.IRepository
{
    public interface IRecordExample
    {
        public Task<MessageHelperRecord> Compare_Records(Tuple<long, string, string> information);
        public Task<MessageHelperRecord> CompareClassNotEquals(Tuple<long, string, string> information);
        public Task<MessageHelperRecord> CompareClassEquals(Tuple<long, string, string> information);
    }
}
