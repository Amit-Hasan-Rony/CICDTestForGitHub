using Microsoft.AspNetCore.Mvc;
using WebApplication1.IRepository;
using WebApplication1.ModelsDTO;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TuppleExampleController : ControllerBase
    {
        public readonly ITuppleExample _iTupple;
        public TuppleExampleController(ITuppleExample iTupple)
        {
            _iTupple = iTupple;
        }


        [HttpPost]
        [Route("SaveToListWithClass")]
        public async Task<IActionResult> SaveToListWithClass(StudentInformation information)
        {
            var res = await _iTupple.SaveToListWithClass(information);
            return Ok(res);
        }


        [HttpPost]
        [Route("SaveToListWithTuple")]
        public async Task<IActionResult> SaveToListWithTuple(Tuple<int, string, string>information)
        {
            var res = await _iTupple.SaveToListWithTuple(information);
            return Ok(res);
        }


        
        [HttpPost]
        [Route("SaveToListWithInOutParameter")]
        public IActionResult SaveToListWithInOutParameter(int StudentId, string StudentName, string StudentEmail)
        {
            long statusCode; string message;
            _iTupple.SaveToListWithInOutParameter(StudentId, StudentName, StudentEmail,out statusCode,out message);
            return Ok(new { statusCode = statusCode, message = message });
        }
    }
}
