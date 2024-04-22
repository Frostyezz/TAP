namespace Lab4Web.Services.Lambda
{
    public interface ILambdaService
    {
        Tuple<int, int, int> Test1(int value);

        bool Test2(string value);

        Task<string> Test3Async(string value);

        string Test4();

        int Test5(int value);

        bool Test6(int value, int div);

        string Test7(string value);

        string Test8(string value);

        string Test9(string value);

        Task<string> AsyncLambda(string value);
    }
}
