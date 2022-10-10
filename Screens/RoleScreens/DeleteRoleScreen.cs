using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.RoleScreens
{
    public class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir perfil");
            Console.WriteLine("------------------");
            Console.WriteLine("Qual o id do perfil que deseja excluir?");
            var id = int.Parse(Console.ReadLine()!);
            Console.WriteLine();

            Delete(id);
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Perfil excluido com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o perfil");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
