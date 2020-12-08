using System;
using System.Collections.Generic;

namespace ContactsManagerCLI
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            if (Contacts.ReadContacts())
            {
                Console.WriteLine("Welcome to the CLI Contact Manager!");
                Console.WriteLine("----------");

                while(true)
                {
                    DisplayMenu();
                    if(!GetInput())
                    {
                        break;
                    }
                }

                Console.WriteLine("Thank you for using the CLI Contact Manager.");
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
            Console.WriteLine("----------");
        }

        public static bool GetInput()
        {
            string input = Console.ReadLine();
            Console.WriteLine("----------");

            switch (input)
            {
                case "1":
                    if (Contacts.ContactList.Count != 0)
                        DisplayContacts(Contacts.ContactList);
                    else
                        Console.WriteLine("Contact list is empty.");
                    break;
                case "2":
                    Console.WriteLine("Enter a name or phone number to search by:");
                    input = Console.ReadLine();
                    DisplayContacts(Contacts.SearchContacts(input));
                    break;
                case "3":
                    // Add
                    var contact = new Contact();

                    Console.WriteLine("Name of contact:");
                    input = Console.ReadLine();
                    contact.Name = input;

                    Console.WriteLine("Contact's phone number:");
                    input = Console.ReadLine();
                    contact.Number = input;

                    Contacts.ContactList.Add(contact);
                    Contacts.WriteContacts();
                    break;
                case "4":
                    // Delete
                    int numberToDelete;
                    while (true)
                    {
                        DisplayContacts(Contacts.ContactList);
                        Console.WriteLine("-----------");
                        Console.WriteLine("Input Contact # to edit:");
                        input = Console.ReadLine();
                        Console.WriteLine("-----------");
                        try
                        {
                            numberToDelete = int.Parse(input);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Input was not a number try again.");
                            Console.WriteLine("----------");
                        }
                    }
                    Contacts.DeleteContact(numberToDelete);
                    Contacts.WriteContacts();
                    break;
                case "5":
                    // Edit
                    int contactNumber;
                    while (true)
                    {
                        DisplayContacts(Contacts.ContactList);
                        Console.WriteLine("-----------");
                        Console.WriteLine("Input Contact # to edit:");
                        input = Console.ReadLine();
                        Console.WriteLine("-----------");
                        try
                        {
                            contactNumber = int.Parse(input);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Input was not a number try again.");
                            Console.WriteLine("----------");
                        }
                    }

                    Contacts.EditContact(contactNumber);
                    Contacts.WriteContacts();
                    break;
                case "6":
                    return false;
                default:
                    Console.WriteLine("Input not recognized try again. \n");
                    return true;
            }

            Console.WriteLine("----------");

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
