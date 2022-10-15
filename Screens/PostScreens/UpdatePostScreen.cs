using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public class UpdatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando post");
            Console.WriteLine("------------------");
            Console.Write("Digite o ID do post que deseja atualizar:");
            var id = int.Parse(Console.ReadLine()!);

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

            var createDate = GetCreateDate(id);

            Console.WriteLine();

            Update(new Post()
            {
                Id = id,
                CategoryId = category,
                AuthorId = author,
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                CreateDate = createDate,
                LastUpdateDate = DateTime.Now,
            });
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Update(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Update(post);
                Console.WriteLine("Post atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Não foi possível atualizar o post");
                Console.WriteLine(ex.Message);
            }
        }

        private static DateTime GetCreateDate(int id)
        {
            var repository = new Repository<Post>(Database.Connection);
            var post = repository.Get(id);

            return post.CreateDate;
        }
    }
}
