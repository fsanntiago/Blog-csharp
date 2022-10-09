using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir usuário");
            Console.WriteLine("------------------");
            Console.WriteLine("Qual o id do usuário que deseja excluir?");
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
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Usuário excluido com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível exluir o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
