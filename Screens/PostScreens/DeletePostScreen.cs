using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public class DeletePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir post");
            Console.WriteLine("------------------");
            Console.WriteLine("Qual o id do post que deseja excluir?");
            var id = int.Parse(Console.ReadLine()!);
            Console.WriteLine();

            Delete(id);
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Post excluida com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
