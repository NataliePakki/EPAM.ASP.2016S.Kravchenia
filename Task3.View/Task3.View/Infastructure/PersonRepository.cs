using System.Collections.Generic;
using System.Threading.Tasks;
using Task3.View.Models;

namespace Task3.View.Infastructure {
    public class PersonRepository {
        private List<Person> Persons { get; set; }
        private int id;
        public static PersonRepository Instance { get; }

        private PersonRepository() {
            Persons = new List<Person>();
        }

        static PersonRepository() {
            Instance = new PersonRepository();
        }
        public void Add(Person user) {
            id++;
            Persons.Add(user);
        }

        public void Edit(Person user) {
            Delete(user.Id);
            Add(user);
        }

        public void Delete(int id) {
            Persons.Remove(Persons.Find(u => u.Id == id));
        }
        public List<Person> GetAll() {
            return Persons;
        }
        public Person Get(int id) {
            return Persons.Find(user => user.Id == id);
        }
    }
}