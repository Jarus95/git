namespace FuncActionDelegate
{
    internal class FuncDelegate
    {
        public FuncDelegate()
        {
            //return type int bolgan param talab qilmaydigan method
            Func<Add> getIntFunc = add;
            var result = getIntFunc(); // =2

            Func<string> getStringFunc = GetString;

            Func<int, int, string> sumFunc = Sum;
            string sumResult = sumFunc(3, 5);

            FuncInt func = Sum;

            int GetInt()
            {

                return 2;
            }

            Add add()
            {
                return GetInt;
            }

            string GetString()
            {
                return "2";
            }

            string Sum(int a, int b)
            {
                return (a + b).ToString();
            }

        }

        delegate int Add();
        delegate string FuncInt(int a, int b);
    }
}
