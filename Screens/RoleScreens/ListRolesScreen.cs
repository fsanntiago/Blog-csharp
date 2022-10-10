using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.RoleScreens
{
    public class ListRolesScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de perfis");
            Console.WriteLine("---------------");

            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void List()
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                var roles = repository.Get();

                Console.WriteLine("Perfis\n");
                foreach (var role in roles)
                {
                    Console.WriteLine(role.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível listar os perfis");
                Console.WriteLine(ex.Message);
            }

        }
    }
}
