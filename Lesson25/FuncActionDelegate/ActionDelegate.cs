namespace FuncActionDelegate
{
    internal class ActionDelegate
    {
        public ActionDelegate()
        {
            StartDelegate start = Start;
            start();

            LogDelegate log = Log;
            log("Log delegate.");

            SumDelegate sum = Sum;
            var sumResult = sum(2, 4);

            Action startAction = Start;
            startAction();

            Action<string> logAction = Log;
            Action<int, int, int, string> sumAction = SumResult;

            sumAction(3, 5, 6, "soz");

            void Start()
            {
                Log("Started");
            }

            void Log(string message)
            {
                Console.WriteLine(message);
            }

            int Sum(int a, int b)
            {
                return a + b;
            }

            void SumResult(int a, int b, int c, string satr)
            {
                Console.WriteLine(a + b + c);
            }
        }

        delegate void StartDelegate();
        delegate void LogDelegate(string message);
        delegate int SumDelegate(int x, int y);
    }
}
