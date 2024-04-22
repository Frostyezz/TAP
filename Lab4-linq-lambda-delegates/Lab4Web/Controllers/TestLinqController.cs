using Lab4Web.Services.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Lab4Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLinqController : ControllerBase
    {
        private readonly ILinqService _linqService;

        public TestLinqController(ILinqService linqService)
        {
            _linqService = linqService;
        }

        [HttpGet("test-1")]
        public int Get(int age)
        {
            return _linqService.Test1(age);
        }

        [HttpGet("test-2")]
        public string Test2(string subject)
        {
            var teachers = _linqService.Test2(subject);
            return string.Join(", ", teachers);
        }

        [HttpGet("test-3")]
        public string Test3()
        {
            var result = _linqService.Test3();
            return string.Join(", ", result);
        }

        [HttpGet("test-4")]
        public int Test4()
        {
            return _linqService.Test4();
        }

        [HttpGet("test-5")]
        public string Test5(string name)
        {
            var teachers = _linqService.Test5(name);
            return string.Join(", ", teachers);
        }

        [HttpGet("test-6")]
        public string Test6()
        {
            var result = _linqService.Test6();
            return string.Join(", ", result);
        }

        [HttpGet("test-7")]
        public string Test7()
        {
            var result = _linqService.Test7();
            return string.Join(", ", result);
        }
    }
}
