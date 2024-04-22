namespace Lab4Web.Services.Lambda
{
    public class LambdaService : ILambdaService
    {
        public Tuple<int, int,int> Test1(int value)
        {
            var lambdaExp = (int num) => new Tuple<int, int, int>(num % 10, (num /= 10) % 10, (num /= 10) % 10);
            return lambdaExp(value);
        }

        public bool Test2(string value)
        {
            return int.TryParse(value, out _);
        }

        public async Task<string> Test3Async(string value)
        {
            var lambaExp = async (string v) =>
            {
                await Delay();
                return value.ToLower();
            };

            return await lambaExp(value);
        }


        public Task Delay()
        {
            return Task.Delay(10000);
        }

        // 2 a i
        public string Test4()
        {
            Func<string> func = () => "2 a i";

            return func();
        }

        // 2 a ii
        public int Test5(int value)
        {
            Func<int, int> func = (int value1) => value1 % 2;

            return func(value);
        }

        // 2 a iii
        public bool Test6(int value, int div)
        {
            Func<int, int, bool> func = (int value1, int div1) => value1 % div1 == 0;
            
            return func(value, div);
        }

        // 2 a iv
        public string Test7(string value)
        {
            Func<string, string, string> func = (string value1, string notUsed) => value1.ToUpper();
            
            return func(value, "notUsed");
        }

        // 2 a v
        public string Test8()
        {
            Func<string, string, string> func = (string value1 = "Default", string value2 = "Value") =>
            {
                string lowercase1 = value1.ToLower();
                string lowercase2 = value2.ToLower();

                return $"{lowercase1} {lowercase2}";
            };
                       
            return func("D", "V");
        }

        // 2 a vi
        public string Test9()
        {
            Func<Tuple<int, int, int>, string> func = (Tuple<int, int, int> tuple) => $"{tuple.Item1} {tuple.Item2} {tuple.Item3}";
                       
            return func(new Tuple<int, int, int>(1, 2, 3));
        }

        // 2 b
        public async Task<string> AsyncLambda(string value)
        {
            Func<Task<string>> asyncFunc = async () =>
            {
                await Task.Delay(2000);
                return value;
            };

            return await asyncFunc();
        }
    }
}
