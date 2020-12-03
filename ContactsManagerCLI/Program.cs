using System;

namespace ContactsManagerCLI
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if(Contacts.ReadContacts())
            {
                Contacts.contactList.ForEach(delegate (Contact contact)
                {
                    Console.WriteLine("{0} {1}", contact.Name, contact.Number);
                });
            }
        }
    }
}
