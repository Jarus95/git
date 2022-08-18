class UsersDatabase
{
    public List<User> Users = new List<User>();

    public void AddUser(long chatId, string name)
    {
        //check user exist or not
        if (Users.Any(user => user.ChatId == chatId))
        {
            // user exist, return
            return;
        }

        var user = new User(chatId, name);
        Users.Add(user);
    }

    public User? GetUser(long chatId)
    {
        //find user
        //return result
        return Users.FirstOrDefault(user => user.ChatId == chatId);
    }
}
