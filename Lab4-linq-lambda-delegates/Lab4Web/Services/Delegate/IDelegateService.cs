namespace Lab4Web.Services.Delegate
{
    public interface IDelegateService
    {
        string Introduction(string value, Func<string, string, string> callback);

        string Hello(string firstname, string lastname);

        string HelloAndIntroduction(string name);

        string Bye(string firstname, string lastname);

        string WelcomeOrBye(string name, bool isWelcome);

        void ConversationDelegate(string name);
    }
}
