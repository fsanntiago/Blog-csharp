using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            //ReadUsers();
            //ReadUser();
            //CreateUser();
            //UpdateUser();
            DeleteUser();
        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }

            }
        }

        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);

                Console.WriteLine(user.Name);
            }
        }

        public static void CreateUser()
        {
            var user = new User()
            {
                Bio = "Equipe balta.io",
                Email = "hell@balta.io",
                Image = "https://",
                Name = "Equipe balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var rows = connection.Insert<User>(user);
                if (rows == 0)
                {
                    Console.WriteLine("Cadastro falhou");
                }
                else
                {
                    Console.WriteLine("Cadastro realizado com sucesso");
                }

            }
        }

        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 2,
                Bio = "Equipe | balta.io",
                Email = "hell@balta.io",
                Image = "https://...",
                Name = "Equipe de suporte balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var res = connection.Update<User>(user);
                if (!res)
                {
                    Console.WriteLine("Atualizacao falhou");
                }
                else
                {
                    Console.WriteLine("Atualizacao realizada com sucesso");
                }

            }
        }

        public static void DeleteUser()
        {

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(2);

                var res = connection.Delete<User>(user);
                if (!res)
                {
                    Console.WriteLine("Exclusao falhou");
                }
                else
                {
                    Console.WriteLine("Exclusao realizada com sucesso");
                }

            }
        }
    }
}