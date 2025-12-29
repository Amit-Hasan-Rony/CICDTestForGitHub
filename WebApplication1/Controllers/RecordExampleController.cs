using Microsoft.AspNetCore.Mvc;
using WebApplication1.IRepository;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordExampleController : ControllerBase
    {
        public readonly IRecordExample _iRecord;
        public RecordExampleController(IRecordExample iRecord)
        {
            _iRecord = iRecord;
        }

        [HttpPost]
        [Route("Compare_RecordsAndClasses")]
        public async Task<IActionResult> Compare_RecordsAndClasses(Tuple<long , string , string> information)
        {
            var resCompareRecord = await _iRecord.Compare_Records(information);
            var resCompareClassNotEquals = await _iRecord.CompareClassNotEquals(information);
            var resCompareClassEuals = await _iRecord.CompareClassEquals (information);

            return Ok(new { resCompareClassNotEquals, resCompareRecord, resCompareClassEuals });
        }
    }
}
