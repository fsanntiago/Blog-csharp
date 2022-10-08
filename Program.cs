using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            //ReadUsers(connection);
            //ReadUsersWithRole(connection);
            //CreateUsers(connection);
            //ReadRoles(connection);
            //ReadTags(connection);
            //DeleteUser(connection);
            //UpdateUser(connection);
            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }
        }

        public static void ReadUsersWithRole(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                Console.WriteLine($"- {item.Name}");
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }
        }

        public static void CreateUsers(SqlConnection connection)
        {
            var user = new User()
            {
                Email = "email@balta.io",
                Bio = "bio",
                Image = "image",
                Name = "name",
                PasswordHash = "hash",
                Slug = "slug",
            };
            var repository = new Repository<User>(connection);
            repository.Create(user);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void UpdateUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var item = repository.Get(2);
            item.Email = "hello@balta.io";
            repository.Update(item);
        }

        public static void DeleteUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var item = repository.Get(2);
            repository.Delete(item);
        }
    }
}