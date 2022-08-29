namespace Assembly1
{
    public class Employee : User
    {
        private int P_private;

        public Employee()
        {
            P_public = 1;
            P_internal = 2;
            P_protected_internal = 3;
            P_protected = 4;
            P_private_protected = 5;
            // P_private = 5;       // we can not use private members of base class in derived class
            // P_default = 6;
        }
    }
}
