﻿using System;
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

        public static void DeleteContact(int number)
        {
            ContactList.RemoveRange(number-1, 1);
        }

        public static void EditContact(int number)
        {
            string[] contactInfo = new string[2];
            Contact contact = ContactList[number - 1];
            Console.WriteLine("Enter new name or leave input blank to keep current name.");
            contactInfo[0] = Console.ReadLine();
            Console.WriteLine("----------");
            Console.WriteLine("Enter new phone number or leave input blank to keep current phone number.");
            contactInfo[1] = Console.ReadLine();
            Console.WriteLine("----------");

            if (!contactInfo[0].Trim().Equals(""))
                ContactList[number - 1].Name = contactInfo[0].Trim();
            if (!contactInfo[1].Trim().Equals(""))
                ContactList[number - 1].Number = contactInfo[1].Trim();
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
