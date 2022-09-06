namespace Structs;

struct User
{
    public string name { get; set; }
    public int son;

    public User(string name, int son)
    {
        this.name = name;
        this.son = son;
    }

    public User Copy()
    {
        return this;
    }
}