using System;
using System.Collections.Generic;
using System.IO;

namespace ContactsManagerCLI
{
    public static class Contacts
    {
        private static string path = Path.Combine(Directory.GetCurrentDirectory(), "contacts.txt");
        public static List<Contact> contactList = new List<Contact>();

        public static bool ReadContacts()
        {
            if(File.Exists(path))
            {
                try
                {
                    string[] allContacts = File.ReadAllLines(path);
                    foreach(string contact in allContacts)
                    {
                        string[] contactInfo = contact.Split(new[] { ":::" }, StringSplitOptions.RemoveEmptyEntries);
                        contactList.Add(new Contact(contactInfo[0], contactInfo[1]));
                    }
                    return true;
                } catch(Exception)
                {
                    Console.WriteLine("Could read data from file");
                }
            } else
            {
                try
                {
                    File.Create(path);
                    return true;
                } catch(Exception)
                {
                    Console.WriteLine("Could not create file to store contacts");
                }
            }

            return false;
        }
    }
}
