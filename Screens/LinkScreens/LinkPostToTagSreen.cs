using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.LinkScreens
{
    public class LinkPostToTagSreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.Write("Digite ID do post: ");
            var postId = int.Parse(Console.ReadLine()!);
            var post = GetPost(postId);
            if (post == null)
            {
                Console.WriteLine("Não foi possivel encontrar o post");
                Console.WriteLine("Voltando para o menu principal...");
                Thread.Sleep(5000);
                Program.Load();
            }
            Console.WriteLine("Post");
            Console.WriteLine("---------------");
            Console.WriteLine(post.Title);

            Console.WriteLine();
            Console.WriteLine("Lista de tags");
            Console.WriteLine("---------------");
            ListTags();

            Console.WriteLine();
            Console.Write("Informe o numero da tags que deseja vincular a esse post: ");
            var tagId = int.Parse(Console.ReadLine()!);

            Link(postId, tagId);
            Console.ReadKey();
            Program.Load();
        }

        public static Post GetPost(int id)
        {
            Post? post = null;
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                var result = repository.Get(id);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel encontrar o post");
                Console.WriteLine(ex.Message);
                return post;
            }
        }

        public static void Link(int postId, int tagId)
        {
            try
            {
                var repository = new PostRepository(Database.Connection);
                repository.LinkPostToTag(postId, tagId);
                Console.WriteLine("Post vinculado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel vincular o post");
                Console.WriteLine(ex.Message);
            }
        }

        public static void ListTags()
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                var tags = repository.Get();

                Console.WriteLine("Tags\n");
                foreach (var tag in tags)
                {
                    Console.Write($"{tag.Id} - ");
                    Console.WriteLine(tag.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível listar as tags");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
