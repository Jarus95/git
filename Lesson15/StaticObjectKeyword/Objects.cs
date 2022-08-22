using Models;

namespace StaticObjectKeyword
{
    public static class Objects
    {
        public static void Main()
        {
            Console.WriteLine("Salom");

            User user = new User();
            object userObj = user;

            user.Name = "ism";
            ShowType(user);

            ShowType(2);
            //ShowType("str");
            //ShowType(true);
        }

        public static void ShowType(object t)
        {
            var son = t as int?;
            Console.WriteLine(son);

            var type = t.GetType();
            Console.WriteLine(type);
        }
    }
}
