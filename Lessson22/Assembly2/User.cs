namespace Assembly2
{
    public class Employee : Assembly1.User
    {
        public Employee()
        {
            P_public = 1;
            //P_internal = 2;
            P_protected_internal = 3;
            P_protected = 4;
            //P_private_protected = 5;
        }
    }
}
