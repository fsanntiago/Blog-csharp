using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.RoleScreens
{
    public class UpdateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando perfil");
            Console.WriteLine("------------------");
            Console.Write("Digite o ID do perfil que deseja atualizar:");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Digite o Nome");
            var name = Console.ReadLine();
            Console.Write("Digite o Slug");
            var slug = Console.ReadLine();

            Update(new Role()
            {
                Id = id,
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Update(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Update(role);

                Console.WriteLine("Perfil atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o perfil");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
