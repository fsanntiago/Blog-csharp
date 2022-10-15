using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir categoria");
            Console.WriteLine("------------------");
            Console.WriteLine("Qual o id da categoria que deseja excluir?");
            var id = int.Parse(Console.ReadLine()!);
            Console.WriteLine();

            Delete(id);
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Categoria excluida com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
