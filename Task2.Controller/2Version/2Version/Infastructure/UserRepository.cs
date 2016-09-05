using System.Collections.Generic;
using _2Version.Models;

namespace _2Version.Infastructure {
    public class UserRepository {
        private List<User> Users { get; set; }
        private int id;
        public static UserRepository Instance { get; }

        private UserRepository() {
            Users = new List<User>();
        }

        static UserRepository() {
            Instance = new UserRepository();
        }
        public void Add(User user) {
            id++;
            user.Id = id;
            Users.Add(user);
        }

        public void Delete(int id) {
            Users.Remove(Users.Find(u => u.Id == id));
        }
        public List<User> GetAll() {
            return Users;
        }
        public User Get(int id) {
            return Users.Find(user => user.Id == id);
        }
    }
}