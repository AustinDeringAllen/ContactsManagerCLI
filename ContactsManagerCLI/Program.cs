using System;
using System.Collections.Generic;

namespace ContactsManagerCLI
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if (Contacts.ReadContacts())
            {
                Contacts.ContactList.ForEach(delegate (Contact contact)
                {
                    Console.WriteLine("{0} {1}", contact.Name, contact.Number);
                });
            }
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("1. View all contacts");
            Console.WriteLine("2. Search contacts");
            Console.WriteLine("3. Add a new contact");
            Console.WriteLine("4. Delete a contact");
            Console.WriteLine("5. Edit a contact");
            Console.WriteLine("6. Exit");
        }
    }
}
