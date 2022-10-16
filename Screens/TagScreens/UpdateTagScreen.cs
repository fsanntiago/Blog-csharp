using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.TagScreens
{
    public class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando tag");
            Console.WriteLine("------------------");
            Console.Write("Digite o ID da tag que deseja atualizar:");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Digite o Nome");
            var name = Console.ReadLine();
            Console.Write("Digite o Slug");
            var slug = Console.ReadLine();

            Update(new Tag()
            {
                Id = id,
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);

                Console.WriteLine("Tag atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
