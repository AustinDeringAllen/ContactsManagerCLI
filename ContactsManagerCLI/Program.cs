using System;

namespace ContactsManagerCLI
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Contact contact = new Contact("Dylan Bird", "5555555555");
            Console.WriteLine("{0} {1}", contact.Name, contact.Number);
        }
    }
}
