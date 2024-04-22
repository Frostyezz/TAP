namespace Lab4Web.Services.Linq
{
    public interface ILinqService
    {
        int Test1(int value);
        List<Teacher> Test2(string subject);
        List<string> Test3();
        int Test4();
        List<Teacher> Test5(string name);
        List<string> Test6();
        Dictionary<int, List<Teacher>> Test7();
    }
}
