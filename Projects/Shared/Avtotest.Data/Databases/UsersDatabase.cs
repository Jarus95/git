using Avtotest.Data.Models;

namespace Avtotest.Data.Databases;

public class UsersDatabase
{
    public List<User> Users { get; set; }

    public UsersDatabase(List<User> users)
    {
        Users = users;
    }
}