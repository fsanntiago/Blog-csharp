using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar um usuário");
            Console.WriteLine("----------------");

            Console.Write("Digite o Titulo:");
            var title = Console.ReadLine();

            Console.Write("Digite o Corpo do post:");
            var body = Console.ReadLine();

            Console.Write("Digite o Resumo:");
            var summary = Console.ReadLine();

            Console.Write("Digite o Slug:");
            var slug = Console.ReadLine();

            Console.Write("Digite o Id da Categoria:");
            var category = int.Parse(Console.ReadLine());

            Console.Write("Digite o Id do Autor:");
            var author = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Create(new Post()
            {
                CategoryId = category,
                AuthorId = author,
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
            });
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Create(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Create(post);
                Console.WriteLine("Post cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível cadastrar o post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
