namespace Classes;

class Database
{
    public QuestionsDatabase questionDb;
    public UsersDatabase usersDb;
    private WriteReadDatabase fileSaver;

    public Database()
    {
        questionDb = new QuestionsDatabase();
        usersDb = new UsersDatabase();
        fileSaver = new WriteReadDatabase();
        usersDb.Users = fileSaver.ReadUsers();
    }

    public void Save()
    {
        fileSaver.Write(usersDb.Users);
    }
}