using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando categoria");
            Console.WriteLine("------------------");
            Console.Write("Digite o ID da categoria que deseja atualizar:");
            var id = int.Parse(Console.ReadLine()!);

            Console.Write("Digite o Nome:");
            var name = Console.ReadLine();

            Console.Write("Digite o Slug:");
            var slug = Console.ReadLine();
            Console.WriteLine();

            Update(new Category()
            {
                Id = id,
                Name = name,
                Slug = slug

            });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Update(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Update(category);
                Console.WriteLine("Categoria atualizada com sucesso!");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Não foi possível atualizar a categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
