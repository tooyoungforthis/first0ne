using System;
using System.Collections.Generic;

namespace unban
{
    /*Phone book offers the following commands
    1) Сreation of new entry.
    2) Editing of established entries
    3) Deleting of established entries
    4) View created entry
    5) View all created entries with summary information including Surname, Name, PhoneNumber */
    public class Program
    {
        static void PrintCommands()
        {
            Console.WriteLine("press 1 to create new entry" + "\n" + "press 2 to edit the entry" + "\n" + "press 3 to delete the entry");
            Console.WriteLine("press 4 to view created entry" + "\n" + "press 5 to view all summary entries");
        }
        public static void Main(string[] args)
        {
            PrintCommands();

            // Choose the operation
            int pressedButton;
            PhoneBook phonebook = new PhoneBook();
            while (true)
            {
                Console.WriteLine("Choose operation");
                if ((int.TryParse(Console.ReadLine(), out pressedButton)) && (pressedButton < 6) && (pressedButton > 0))
                {
                    if (pressedButton == 1)
                    {
                        phonebook.CreationOfNewEntry();
                    }
                    else if (pressedButton == 2)
                    {
                        if (PhoneBook.phonebook.Count == 0) Console.WriteLine("need to create new entry");
                        else
                        {
                            Console.Write($"Enter the number of the editing entry, from 0 to {PhoneBook.phonebook.Count - 1}: ");
                            int entryNumber = int.Parse(Console.ReadLine());
                            if (entryNumber <= PhoneBook.phonebook.Count-1) phonebook.EditingTheEntry(entryNumber);
                            else Console.WriteLine($"Last entry number is {PhoneBook.phonebook.Count - 1}");
                        }
                    }
                    else if (pressedButton == 3)
                    {
                        if (PhoneBook.phonebook.Count == 0) Console.WriteLine("need to create new entry");
                        else
                        {
                            Console.Write($"Enter the number of the deleting entry, from 0 to {PhoneBook.phonebook.Count - 1}: ");
                            int entryNumber = int.Parse(Console.ReadLine());
                            if (entryNumber <= PhoneBook.phonebook.Count-1) phonebook.DeletingTheEntry(entryNumber);
                            else Console.WriteLine($"Last entry number is {PhoneBook.phonebook.Count - 1}");
                        }
                    }
                    else if (pressedButton == 4)
                    {
                        if (PhoneBook.phonebook.Count == 0) Console.WriteLine("need to create new entry");
                        else
                        {
                            Console.Write($"Enter the number of the viewing entry, from 0 to {PhoneBook.phonebook.Count - 1}: ");
                            int entryNumber = int.Parse(Console.ReadLine());
                            if (entryNumber <= PhoneBook.phonebook.Count-1) phonebook.ViewingCreatedEntry(entryNumber);
                            else Console.WriteLine($"Last entry number is {PhoneBook.phonebook.Count - 1}");
                        }
                    }
                    else
                    {
                        if (PhoneBook.phonebook.Count == 0) Console.WriteLine("need to create new entry");
                        else phonebook.ViewingAllSummaryEntries();
                    }
                    PrintCommands();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                    PrintCommands();
                }

            }
        }
    }

    public class PhoneBook
    //commands of phonebook
    {
        public static List<Person> phonebook = new List<Person>();

        public List<Person> CreationOfNewEntry()
        {
            Console.WriteLine("Enter surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter patronymic");
            string patronymic = Console.ReadLine();

            string phonenumber;
            while (true)
            {
                Console.WriteLine("Enter phoneNumber, only digits allowed");
                phonenumber = Console.ReadLine();
                if (int.TryParse(phonenumber, out int number))
                {
                    break;
                }
                Console.WriteLine("Invalid input");
            }

            Console.WriteLine("Enter country");
            string country = Console.ReadLine();
            Console.WriteLine("Enter dateofbirth, FORMAT: day.month.year, EXAMPLE: 01.01.1970");
            string dateofbirth = Console.ReadLine();
            Console.WriteLine("Enter organization");
            string organization = Console.ReadLine();
            Console.WriteLine("Enter position");
            string position = Console.ReadLine();
            Console.WriteLine("Enter otherinformation");
            string otherinformation = Console.ReadLine();

            Person person = new Person(surname, name, patronymic, phonenumber, country, dateofbirth, organization, position, otherinformation);
            phonebook.Add(person);
            return phonebook;

        }

        public List<Person> EditingTheEntry(int entrynumber)
        {
            //List<Tuple<string, string>> changes = new List<Tuple<string, string>>();
            Console.Write("1 - surname, 2 - name, 3 - patronymic, 4 - phonenumber, 5 - country, 6 - dateofbirth, ");
            Console.WriteLine("7 - organization, 8 - position, 9 - otherinformation");
            Console.WriteLine("Enter the number of parameter you want to edit and its new value: ");
            while (true)
            {
                Console.Write("Enter the number of parameter: ");
                int parameter;
                int.TryParse(Console.ReadLine(), out parameter);
                Console.Write("Enter new value: ");
                string newValue = Console.ReadLine();

                if (parameter == 4)
                {
                    while (true)
                    {   
                        if (int.TryParse(newValue, out int number))
                        {
                            phonebook[entrynumber].PhoneNumber = newValue;
                            break;
                        }
                        Console.WriteLine("Only digits allowed");
                        Console.Write("Enter new value: ");
                        newValue = Console.ReadLine();
                    }
                }   

                if (newValue == "stop" || parameter == 0) break;

                if (parameter == 1) phonebook[entrynumber].SurName = newValue;
                else if (parameter == 2) phonebook[entrynumber].Name = newValue;
                else if (parameter == 3) phonebook[entrynumber].Patronymic = newValue;
                else if (parameter == 5) phonebook[entrynumber].Country = newValue;
                else if (parameter == 6) phonebook[entrynumber].DateOfBirth = newValue;
                else if (parameter == 7) phonebook[entrynumber].Organization = newValue;
                else if (parameter == 8) phonebook[entrynumber].Position = newValue;
                else phonebook[entrynumber].OtherInformation = newValue;
            }

            return phonebook;
        }

        public List<Person> DeletingTheEntry(int entrynumber)
        {
            phonebook.RemoveAt(entrynumber);
            return phonebook;
        }

        public void ViewingCreatedEntry(int entrynumber)
        {
            Console.WriteLine($"surname: {phonebook[entrynumber].SurName}");
            Console.WriteLine($"name: {phonebook[entrynumber].Name}");
            Console.WriteLine($"patronymic {phonebook[entrynumber].Patronymic}");
            Console.WriteLine($"phonenumber {phonebook[entrynumber].PhoneNumber}");
            Console.WriteLine($"country: {phonebook[entrynumber].Country}");
            Console.WriteLine($"date of birth: {phonebook[entrynumber].DateOfBirth}");
            Console.WriteLine($"organization: {phonebook[entrynumber].Organization}");
            Console.WriteLine($"position: {phonebook[entrynumber].Position}");
            Console.WriteLine($"other information: {phonebook[entrynumber].OtherInformation}");
        }

        public void ViewingAllSummaryEntries()
        {
            foreach (Person person in phonebook)
            {
                Console.Write($"surname: {person.SurName}, ");
                Console.Write($"name: {person.Name}, ");
                Console.WriteLine($"phonenumber: {person.PhoneNumber}");

            }

        }


    }


    public class Person
    {
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string DateOfBirth { get; set; } // format: day.month.year  example: 01.01.1970
        public string Organization { get; set; }
        public string Position { get; set; }
        public string OtherInformation { get; set; }

        public Person(string surname, string name, string patronymic, string phonenumber, string country, string dateofbirth, string organization, string position, string otherinformation)
        {
            SurName = surname;
            Name = name;
            Patronymic = patronymic;
            PhoneNumber = phonenumber;
            Country = country;
            DateOfBirth = dateofbirth;
            Organization = organization;
            Position = position;
            OtherInformation = otherinformation;
        }
    }
}