var question = new Question("Savol?", index:2, new List<string>(){"1","2","3","4"});

Database db = new Database();
db.usersDb.AddUser(1,"ad");

var user = db.usersDb.GetUser(1);

if(user != null)
    user.Step = 2;

var user1 = db.usersDb.GetUser(1);

Console.WriteLine(user1?.ToText());