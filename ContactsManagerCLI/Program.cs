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
                DisplayMenu();
                if (GetInput())
                {
                    DisplayMenu();
                    GetInput();
                }
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

        public static bool GetInput()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    if (Contacts.ContactList.Count != 0)
                        DisplayContacts(Contacts.ContactList);
                    else
                        Console.WriteLine("Contact list is empty.");
                    break;
                case "2":
                    input = Console.ReadLine();
                    DisplayContacts(Contacts.SearchContacts(input));
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    return false;
                default:
                    Console.WriteLine("Input not recognized try again.");
                    break;
            }

            return true;
        }

        public static void DisplayContacts(List<Contact> contacts)
        {
            contacts.ForEach(delegate (Contact contact) {
                Console.WriteLine("{0} {1}", contact.Name, contact.Number);
            });
        }
    }
}
