using Lab4Web.Services.Delegate;
using Microsoft.AspNetCore.Mvc;

namespace Lab4Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDelegateController : ControllerBase
    {
        private readonly IDelegateService _delegateService;

        public TestDelegateController(IDelegateService delegateService)
        {
            _delegateService = delegateService;
        }

        [HttpGet("test-1")]
        public string Test1(string name)
        {
            var callback = _delegateService.Hello;

            return _delegateService.Introduction(name, callback);
        }

        [HttpGet("test-2")]
        public string Test2(string name, bool welcome)
        {
            var callback1 = _delegateService.Hello;
            var callback2 = (string firstname, string lastname) => $"Bye, {firstname} {lastname}";

            var callback = welcome ? callback1 : callback2;

            return _delegateService.Introduction(name, callback);
        }

        // 1 a
        [HttpGet("test-3")]
        public string Test3(string name)
        {
            return _delegateService.HelloAndIntroduction(name);
        }

        // 1 b
        [HttpGet("test-4")]
        public string Test4(string name, bool isWelcome)
        {
            return _delegateService.WelcomeOrBye(name, isWelcome);
        }

        // 1 c
        [HttpGet("test-5")]
        public void Test5(string name)
        {
            _delegateService.ConversationDelegate(name);
        }
    }
}
