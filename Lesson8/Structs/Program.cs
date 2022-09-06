
using System.Runtime.CompilerServices;
using Structs.Structs;

Book myBook = new Book();
myBook.Name = "Csharp";
myBook.Author = "Kimdr";
myBook.Year = 2023;
//ShowBook(myBook);

Book book1 = new Book()
{
    Name = "Kitob1 nomi",
    Author = "Kimdr",
    Year = 1998
};
//ShowBook(book1);

User user1 = new User("Sen", 5);
ShowUser(user1);

void ShowUser(User book)
{
    Console.WriteLine($"1. {book.Name}, {book.Answers}");
}

#region MyRegion
Tuple<string, int> usersTuple = new Tuple<string, int>("User1", 80);
List<Tuple<string, int>> userTuplesList = new List<Tuple<string, int>>();
List<string> strings = new List<string>();
userTuplesList.Add(usersTuple);
#endregion

List<User> users = new List<User>();
var user = new User("Ismi", 80);
users.Add(user);

foreach (var u in users)
{
    Console.WriteLine(u.Name + " : " + u.Answers);
}

