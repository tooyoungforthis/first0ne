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
            Console.WriteLine();
            Console.WriteLine("press 1 to create new entry" + "\n" + "press 2 to edit the entry" + "\n" + "press 3 to delete the entry");
            Console.WriteLine("press 4 to view created entry" + "\n" + "press 5 to view all summary entries");
        }


        public static bool CheckPhoneNumber(string number)
        {
            if (number.Length == 0) return false;

            for (int i = 0; i < number.Length; i++)
            {
                if (Char.IsDigit(number[i])) continue;
                else return false;
            }
            return true;
        }

        public static bool IsNeccesaryValue(string value)
        {
            if (value.Length == 0)
            {
                Console.WriteLine("Required to FILL");
                return false;
            }
            return true;
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

                        if (PhoneBook.phonebook.Count == 0) Console.WriteLine("NEED TO CREATE NEW ENTRY");
                        else
                        {
                            while (true)
                            {
                                Console.Write($"Enter the number of the editing entry, from 1 to {PhoneBook.phonebook.Count}: ");
                                int entryNumber;
                                bool result = int.TryParse(Console.ReadLine(), out entryNumber);
                                if (entryNumber <= PhoneBook.phonebook.Count && entryNumber >= 1 && result)
                                {
                                    phonebook.EditingTheEntry(entryNumber);
                                    break;
                                }
                                else Console.WriteLine($"LAST entry NUMBER is {PhoneBook.phonebook.Count}, try again");
                            }

                        }
                    }
                    else if (pressedButton == 3)
                    {
                        if (PhoneBook.phonebook.Count == 0) Console.WriteLine("NEED TO CREATE NEW ENTRY");
                        else
                        {
                            while (true)
                            {
                                Console.Write($"Enter the number of the deleting entry, from 1 to {PhoneBook.phonebook.Count}: ");
                                int entryNumber;
                                bool result = int.TryParse(Console.ReadLine(), out entryNumber);
                                if (entryNumber <= PhoneBook.phonebook.Count && entryNumber >= 1 && result)
                                {
                                    phonebook.DeletingTheEntry(entryNumber);
                                    break;
                                }
                                else Console.WriteLine($"LAST entry NUMBER is {PhoneBook.phonebook.Count},try again");
                            }
                        }
                    }
                    else if (pressedButton == 4)
                    {
                        if (PhoneBook.phonebook.Count == 0) Console.WriteLine("NEED TO CREATE NEW ENTRY");
                        else
                        {
                            while (true)
                            {
                                Console.Write($"Enter the number of the viewing entry, from 1 to {PhoneBook.phonebook.Count}: ");
                                int entryNumber;
                                bool result = int.TryParse(Console.ReadLine(), out entryNumber);
                                if (entryNumber <= PhoneBook.phonebook.Count && entryNumber >= 1 && result)
                                {
                                    phonebook.ViewingCreatedEntry(entryNumber);
                                    break;
                                }
                                else Console.WriteLine($"LAST entry NUMBER is {PhoneBook.phonebook.Count}, try again");
                            }
                        }
                    }
                    else
                    {
                        if (PhoneBook.phonebook.Count == 0) Console.WriteLine("NEED TO CREATE NEW ENTRY");
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
            string surname;
            while (true)
            {
                Console.WriteLine("Enter surname");
                surname = Console.ReadLine();
                if (Program.IsNeccesaryValue(surname)) break;
            }

            string name;
            while (true)
            {
                Console.WriteLine("Enter name");
                name = Console.ReadLine();
                if (Program.IsNeccesaryValue(name)) break;
            }

            Console.WriteLine("Enter patronymic");
            string patronymic = Console.ReadLine();

            string phonenumber;
            while (true)
            {
                Console.WriteLine("Enter phoneNumber, only digits allowed");
                phonenumber = Console.ReadLine();
                if (Program.CheckPhoneNumber(phonenumber))
                {
                    break;
                }
                Console.WriteLine("Invalid input");
            }

            string country;
            while (true)
            {
                Console.WriteLine("Enter country");
                country = Console.ReadLine();
                if (Program.IsNeccesaryValue(country)) break;
            }

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
            Console.Write("1 - surname, 2 - name, 3 - patronymic, 4 - phonenumber, 5 - country, 6 - dateofbirth, ");
            Console.WriteLine("7 - organization, 8 - position, 9 - otherinformation");
            Console.WriteLine("new value = stop to STOP changes");
            Console.WriteLine("Enter the number of parameter you want to edit and its new value: ");
            while (true)
            {
                Console.Write("Enter the number of parameter: ");
                int parameter;
                int.TryParse(Console.ReadLine(), out parameter);
                if (parameter > 9 || parameter < 1)
                {
                    Console.WriteLine("Invalid number of parameter, try again");
                    continue;
                }
                Console.Write("Enter new value: ");
                string newValue = Console.ReadLine();

                if (newValue == "stop" || parameter == 0) break;


                if (parameter == 4)
                {
                    while (true)
                    {
                        if (Program.CheckPhoneNumber(newValue))
                        {
                            phonebook[entrynumber - 1].PhoneNumber = newValue;
                            break;
                        }
                        Console.WriteLine("Only digits allowed");
                        Console.Write("Enter new value: ");
                        newValue = Console.ReadLine();
                    }
                }

                if (parameter == 1)
                {
                    while (true)
                    {
                        if (Program.IsNeccesaryValue(newValue))
                        {
                            phonebook[entrynumber - 1].SurName = newValue;
                            break;
                        }
                        Console.Write("Enter new value: ");
                        newValue = Console.ReadLine();
                    }
                }

                if (parameter == 2)
                {
                    while (true)
                    {
                        if (Program.IsNeccesaryValue(newValue))
                        {
                            phonebook[entrynumber - 1].Name = newValue;
                            break;
                        }
                        Console.Write("Enter new value: ");
                        newValue = Console.ReadLine();
                    }
                }
                
                if (parameter == 5)
                {
                    while (true)
                    {
                        if (Program.IsNeccesaryValue(newValue))
                        {
                            phonebook[entrynumber - 1].Country = newValue;
                            break;
                        }
                        Console.Write("Enter new value: ");
                        newValue = Console.ReadLine();
                    }
                }

                else if (parameter == 3) phonebook[entrynumber - 1].Patronymic = newValue;
                else if (parameter == 6) phonebook[entrynumber - 1].DateOfBirth = newValue;
                else if (parameter == 7) phonebook[entrynumber - 1].Organization = newValue;
                else if (parameter == 8) phonebook[entrynumber - 1].Position = newValue;
                else phonebook[entrynumber - 1].OtherInformation = newValue;
            }

            return phonebook;
        }

        public List<Person> DeletingTheEntry(int entrynumber)
        {
            phonebook.RemoveAt(entrynumber - 1);
            return phonebook;
        }

        public void ViewingCreatedEntry(int entrynumber)
        {
            Console.WriteLine($"surname: {phonebook[entrynumber - 1].SurName}");
            Console.WriteLine($"name: {phonebook[entrynumber - 1].Name}");
            Console.WriteLine($"patronymic: {phonebook[entrynumber - 1].Patronymic}");
            Console.WriteLine($"phonenumber: {phonebook[entrynumber - 1].PhoneNumber}");
            Console.WriteLine($"country: {phonebook[entrynumber - 1].Country}");
            Console.WriteLine($"date of birth: {phonebook[entrynumber - 1].DateOfBirth}");
            Console.WriteLine($"organization: {phonebook[entrynumber - 1].Organization}");
            Console.WriteLine($"position: {phonebook[entrynumber - 1].Position}");
            Console.WriteLine($"other information: {phonebook[entrynumber - 1].OtherInformation}");
        }

        public void ViewingAllSummaryEntries()
        {
            int i = 0;
            foreach (Person person in phonebook)
            {
                ++i;
                Console.Write(i + ".");
                Console.Write($" surname: {person.SurName}, " + "\t");
                Console.Write($"name: {person.Name}, " + "\t");
                Console.WriteLine($"phonenumber: {person.PhoneNumber}" + '\t');

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