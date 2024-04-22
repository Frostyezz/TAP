using Lab4Web.Services.Lambda;
using Microsoft.AspNetCore.Mvc;

namespace Lab4Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLambdaController : ControllerBase
    {
        private readonly ILambdaService _lambdaService;

        public TestLambdaController(ILambdaService lambdaService)
        {
            _lambdaService = lambdaService;
        }

        [HttpGet("test-1")]
        public string Get(int value)
        {
            var tupleValue = _lambdaService.Test1(value);
            return $"{tupleValue.Item1} / {tupleValue.Item2} / {tupleValue.Item3}";
        }

        [HttpGet("test-2")]
        public string Test2(string value)
        {
            return _lambdaService.Test2(value) ? "Number" : "Not number";
        }

        [HttpGet("test-3")]
        public string Test3(string value)
        {
            var result = _lambdaService.Test3Async(value).Result;
            return result;
        }

        [HttpGet("test-4")]
        public string Test4()
        {
            return _lambdaService.Test4();
        }

        [HttpGet("test-5")]
        public int Test5(int value)
        {
            return _lambdaService.Test5(value);
        }

        [HttpGet("test-6")]
        public bool Test6(int value, int div)
        {
            return _lambdaService.Test6(value, div);
        }

        [HttpGet("test-7")]
        public string Test7(string value)
        {
            return _lambdaService.Test7(value);
        }

        [HttpGet("test-8")]
        public string Test8(string value)
        {
            return _lambdaService.Test8(value);
        }

        [HttpGet("test-9")]
        public string Test9(string value)
        {
            return _lambdaService.Test9(value);
        }

        [HttpGet("test-10")]
        public string Test10(string value)
        {
            var result = _lambdaService.AsyncLambda(value).Result;
            return result;
        }
    }
}
