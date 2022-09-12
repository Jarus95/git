var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("me", GetMe);

app.MapGet("hello", SayHello);

app.MapGet("create-ticket/{from}/{count}", CreateTicket);

app.Run();

string GetMe()
{
    return "I'm DotNet Developer";
}

string SayHello(string name, int id)
{
    return $"{id}. Hello {name}!";
}

int[] CreateTicket(int from = 0, int count = 9)
{
    int[] savollar = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    return savollar.Skip(from).Take(count).ToArray();
}