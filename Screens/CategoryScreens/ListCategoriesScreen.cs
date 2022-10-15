using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public class ListCategoriesScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("1 - Lista de todas as categorias");
            Console.WriteLine("2 - Lista de posts de uma categoria");
            Console.WriteLine("------------------");
            Console.Write("Digite sua escolha: ");
            var option = short.Parse(Console.ReadLine()!);
            switch (option)
            {
                case 1:
                    ListAll();
                    break;
                case 2:
                    ListCategoryWithPosts();
                    break;
                default:
                    Load();
                    break;
            }

            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void ListAll()
        {
            try
            {
                var repository = new CategoryRepository(Database.Connection);
                var categories = repository.GetWithPost();

                Console.WriteLine("Lista de todas as categorias");
                Console.WriteLine("------------------");
                Console.WriteLine($"{"Categoria",-30}{"Quantidade de Posts",-30}\n");
                foreach (var category in categories)
                {
                    Console.Write($"{category.Name,-30}");
                    if (!category.Posts.Any())
                    {
                        Console.WriteLine($"{"0",-30}");
                        continue;
                    }

                    var numbersPosts = category.Posts.Count;
                    Console.WriteLine($"{numbersPosts,-30}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível listar as categorias");
                Console.WriteLine(ex.Message);
            }
        }

        public static void ListCategoryWithPosts()
        {
            try
            {
                var repository = new CategoryRepository(Database.Connection);
                var categories = repository.GetWithPost();

                Console.Clear();
                Console.WriteLine("Lista de posts de uma categoria");
                Console.WriteLine("------------------");
                Console.Write("Digite o Id da categoria: ");
                var id = int.Parse(Console.ReadLine()!);

                var category = categories.FirstOrDefault<Category>(x => x.Id == id);
                if (category == null)
                {
                    Console.WriteLine("\nEssa Id não existe");
                    return;
                }

                if (!category.Posts.Any())
                {
                    Console.WriteLine($"\n{category.Name} não possui nenhum post.");
                }
                else
                {
                    Console.WriteLine($"\n{category.Name}");
                    Console.WriteLine("------------------");
                    Console.WriteLine("Posts:");

                    foreach (var post in category.Posts)
                    {
                        Console.WriteLine($"- {post.Title}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível listar os posts dessa categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
