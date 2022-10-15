using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar uma categoria");
            Console.WriteLine("----------------");
            Console.Write("Digite o Nome:");
            var name = Console.ReadLine();

            Console.Write("Digite o Slug:");
            var slug = Console.ReadLine();
            Console.WriteLine();

            Create(new Category()
            {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Create(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Create(category);

                Console.WriteLine("Categoria cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível cadastrar a categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
