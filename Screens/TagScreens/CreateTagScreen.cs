using Blog.Models;
using Blog.Repositories;
using Blog.Screens.PostScreens;

namespace Blog.Screens.TagScreens
{
    public class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar uma tag");
            Console.WriteLine("----------------");

            Console.Write("Digite o Nome:");
            var name = Console.ReadLine();

            Console.Write("Digite o Slug:");
            var slug = Console.ReadLine();
            Console.WriteLine();

            Create(new Tag()
            {
                Name = name,
                Slug = slug,
            });
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Create(tag);
                Console.WriteLine("Tag cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível cadastrar a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
