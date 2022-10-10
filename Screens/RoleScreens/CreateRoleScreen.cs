using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.RoleScreens
{
    public class CreateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Cadastrar perfil");
            Console.WriteLine("----------------");
            Console.WriteLine();
            Console.Write("Digite o Nome");
            var name = Console.ReadLine();
            Console.Write("Digite o Slug");
            var slug = Console.ReadLine();

            Create(new Role()
            {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Create(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Create(role);

                Console.WriteLine("Perfil cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível listar os perfis");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
