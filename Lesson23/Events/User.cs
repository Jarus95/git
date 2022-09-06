namespace Events;

delegate void UserAdded(string name);

internal class User
{
    public static event UserAdded UserAddedEvent;

    public string Name;

    public User(string name)
    {
        Name = name;
        UserAddedEvent.Invoke(name);
    }
}