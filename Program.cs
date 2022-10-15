using Blog.Screens.CategoryScreens;
using Blog.Screens.LinkScreens;
using Blog.Screens.PostScreens;
using Blog.Screens.RoleScreens;
using Blog.Screens.UserScreens;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            using (Database.Connection = new SqlConnection(CONNECTION_STRING))
            {
                Load();
                Console.ReadKey();
            }
        }

        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("---------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuário");
            Console.WriteLine("2 - Gestão de perfil");
            Console.WriteLine("3 - Vincular perfil/usuário");
            Console.WriteLine("4 - Gestão de categorias");
            Console.WriteLine("5 - Gestão de posts");
            Console.WriteLine();
            Console.Write("Digite sua escolha: ");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    MenuRoleScreen.Load();
                    break;
                case 3:
                    LinkUserToARoleScreen.Load();
                    break;
                case 4:
                    MenuCategoryScreen.Load();
                    break;
                case 5:
                    MenuPostScreen.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}