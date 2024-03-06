using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace WPFDialogi
{
    internal class ListOfPersons
    {
        public ObservableCollection<Person> persons;

        public ListOfPersons()
        {
            persons = new ObservableCollection<Person>();
            LoadPersons("plik.txt");
            InitializeDefaultPersons(); 
        }

        private void InitializeDefaultPersons()
        {
            persons.Add(new Person("Adam", "Kowalski", EducationLevel.średnie));
            persons.Add(new Person("Monika", "Dudek", EducationLevel.podstawowe));
            persons.Add(new Person("Jan", "Sobieski", EducationLevel.wyższe));
            persons.Add(new Person("Marta", "Nowak", EducationLevel.średnie));
            persons.Add(new Person("Maksymilian", "Głowacki", EducationLevel.średnie));
            persons.Add(new Person("Dżordż", "Sigmus", EducationLevel.podstawowe));
            persons.Add(new Person("Engra", "Deathsword", EducationLevel.wyższe));
            persons.Add(new Person("Ikit", "Claw", EducationLevel.średnie));
        }

        public void AddPerson(Person person)
        {
            persons.Add(person);
        }

        public void RemovePerson(Person person)
        {
            persons.Remove(person);
        }

        public void EditPerson(int index, Person person)
        {
            persons[index] = person;
        }

        public void RemovePersonAt(int index)
        {
            if (index >= 0 && index < persons.Count)
                persons.RemoveAt(index);
        }

        public void LoadPersons(string file)
        {
            try
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');

                        if (parts.Length == 3)
                        {
                            string firstName = parts[0];
                            string lastName = parts[1];
                            EducationLevel education = (EducationLevel)Enum.Parse(typeof(EducationLevel), parts[2]);
                            persons.Add(new Person(firstName, lastName, education));
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File does not exist.");
            }
        }

        public void SavePersons(string file)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    foreach (Person person in persons)
                    {
                        string line = $"{person.FirstName},{person.LastName},{person.Education}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Cannot write to file.");
            }
        }
    }
}
            