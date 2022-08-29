namespace SealedAndAbstract
{
    public class User
    {
        public int Age;

        public virtual int GetAge()
        {
            return Age;
        }
    }

    public class Employee : User
    {
        public sealed override int GetAge()
        {
            return base.GetAge();
        }
    }
}
