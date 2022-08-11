string str = "siz {0} ni kiritingiz, USER_NAME ismingiz";

Console.WriteLine(str);
Console.WriteLine(string.Format(str, 8));
Console.WriteLine(str.Replace("USER_NAME","Ismi"));
Console.WriteLine(string.Format(str.Replace("USER_NAME", "Ismi"), 7));