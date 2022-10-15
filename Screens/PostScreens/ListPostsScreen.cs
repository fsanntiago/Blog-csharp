using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public class ListPostsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de posts");
            Console.WriteLine("------------------");
            List();

            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void List()
        {
            try
            {
                var repositoryPost = new PostRepository(Database.Connection);
                var postsCategories = repositoryPost.GetWithCategory();
                var postsTags = repositoryPost.GetWithTag();

                Console.WriteLine($"{"Post",-40}{"Categorias",-30}{"Tags",-20}\n");
                foreach (var postCategory in postsCategories)
                {
                    Console.Write($"{postCategory.Key.Title,-40}");
                    Console.Write($"{postCategory.Value.Name,-30}");

                    foreach (var postTag in postsTags)
                    {
                        if (postTag.Id.Equals(postCategory.Key.Id))
                        {
                            if (!postTag.Tags.Any())
                            {
                                Console.WriteLine($"{"-",-20}");
                                continue;
                            }
                            foreach (var tag in postTag.Tags)
                            {
                                if (postTag.Tags.IndexOf(tag) + 1 == postTag.Tags.Count)
                                    Console.WriteLine($"{tag.Name,-20}");
                                else
                                    Console.Write($"{tag.Name}, ");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível listar as categorias");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
