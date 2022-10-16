using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.TagScreens
{
    public class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir tag");
            Console.WriteLine("------------------");
            Console.WriteLine("Qual o id da tag que deseja excluir?");
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
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Tag excluida com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
