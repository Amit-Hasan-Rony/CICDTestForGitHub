using Microsoft.AspNetCore.Mvc;
using WebApplication1.IRepository;
using WebApplication1.ModelsDTO;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LambdaExpressionExampleController : ControllerBase
    {
        private readonly ILambdaExpressionExample _iRepository;

        public LambdaExpressionExampleController(ILambdaExpressionExample iRepository)
        {
            _iRepository = iRepository;
        }
        [HttpPost]
        [Route("LambdaExpressionExampleCheck")]
        public async Task<IActionResult> LambdaExpressionExampleCheck(Tuple<long , string , string> information)
        {
            var response = await _iRepository.LambdaExpressionExampleCheck(information);
            return Ok(response);
        }


        [HttpPost]
        [Route("LambdaExpressionExampleCallBack")]
        public async Task<IActionResult> LambdaExpressionExampleCallBack(Tuple<long, string, string> information)
        {
            var response = await _iRepository.LambdaExpressionExampleCallBack(information);
            return Ok(response);
        }



        [HttpGet]
        [Route("DeligateInstateOfIfElse")]
        public async Task<IActionResult> DeligateInstateOfIfElse(long Number)
        {
            var resp = await _iRepository.DeligateInstateOfIfElse(Number);
            //return Ok(resp);
            return Ok(new { Message = "Success", Data = resp });
        }

    }
}
