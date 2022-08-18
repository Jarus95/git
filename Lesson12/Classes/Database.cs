class Database
{
    public QuestionsDatabase questionDb;
    public UsersDatabase usersDb;

    public Database()
    {
        questionDb = new QuestionsDatabase();
        usersDb = new UsersDatabase();
    }
}