using System;
using System.Collections.Generic;
using System.IO;

namespace ContactsManagerCLI
{
    public static class Contacts
    {
        private static string path = Path.Combine(Directory.GetCurrentDirectory(), "contacts.txt");

        private static List<Contact> contactList = new List<Contact>();
        public static List<Contact> ContactList
        {
            get { return contactList; }           
        }

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

        public static bool WriteContacts()
        {
            string[] contacts = new string[ContactList.Count];

            for(int i=0; i<ContactList.Count; i++)
            {
                contacts[i] = ContactList[i].Name + ":::" + ContactList[i].Number;
            }

            try
            {
                File.WriteAllLines(path, contacts);
            } catch(Exception)
            {
                return false;
            }

            
            return true;
        }

        public static List<Contact> SearchContacts(string input)
        {
            List<Contact> bucket = new List<Contact>();
            ContactList.ForEach(delegate (Contact contact)
            {
                if(contact.Name.ToLower().Contains(input) || contact.Number.Contains(input))
                {
                    bucket.Add(contact);
                }
            });

            if(bucket.Count == 0)
            {
                Console.WriteLine("No Results Found!");
                return ContactList;
            }

            return bucket;
        }
    }
}
