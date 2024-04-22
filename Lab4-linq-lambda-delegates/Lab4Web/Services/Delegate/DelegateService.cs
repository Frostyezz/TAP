namespace Lab4Web.Services.Delegate
{
    public class DelegateService : IDelegateService
    {
        // 1 c
        public delegate void Conversation();
        public string Introduction(string value, Func<string, string, string> callback)
        {
            var upperName = value.ToUpper();
            return callback(upperName, "Test");
        }

        public string Hello(string firstname, string lastname)
        {
            return $"Hello, {firstname} {lastname}";
        }

        // 1 a
        public string HelloAndIntroduction(string name)
        {
            Func<string, string, string> helloDelegate = new(Hello);

            var result = Introduction(name, helloDelegate);

            return result;
        }

        // 1 b
        public string Bye(string firstname, string lastname)
        {
            return $"Bye, {firstname} {lastname}";
        }

        // 1 b
        public string WelcomeOrBye(string name, bool isWelcome)
        {
            Func<string, string, string> helloDelegate = new(Hello);
            Func<string, string, string> byeDelegate = new(Bye);

            var callback = isWelcome ? helloDelegate : byeDelegate;

            return Introduction(name, callback);
        }

        // 1 c
        public void ConversationMethod(string name)
        {
            Conversation? conversation = null;

            conversation += () => Introduction(name, Hello);

            conversation += () => Introduction(name, Bye);

            conversation();
        }

        // 1 c
        public void ConversationDelegate(string name)
        {
            ConversationMethod(name);
        }

    }
}
