using System.Collections.Generic;
using System.Threading.Tasks;
using _1Version.Models;

namespace _1Version.Infastructure {
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
        public async Task Add(User user) {
            id++;
            user.Id = id;
            await Task.Run(() => Users.Add(user));
        }

        public async Task Edit(User user) {
            await Delete(user.Id);
            await Add(user);
        }

        public async Task Delete(int id) {
            await Task.Run(()=> Users.Remove(Users.Find(u => u.Id == id)));
        }
        public List<User> GetAll() {
            return Users;
        }
        public async Task<User> Get(int id) {
            return await Task.Run(() => Users.Find(user => user.Id == id));
        }
    }
}