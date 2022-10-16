using Blog.Repositories;
using Blog.Screens.UserScreens;

namespace Blog.Screens.TagScreens
{
    public class ListTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de tags");
            Console.WriteLine("---------------");

            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void List()
        {
            var repository = new TagRepository(Database.Connection);
            var tags = repository.GetTagsWithPost();

            Console.WriteLine($"{"Tag",-30}{"Quantidade de Posts",-30}\n");
            foreach (var tag in tags)
            {
                Console.Write($"{tag.Name,-30}");

                if (!tag.Posts.Any())
                {
                    Console.WriteLine($"0", -30);
                    continue;
                }

                var numbersPosts = tag.Posts.Count;
                Console.WriteLine($"{numbersPosts,-30}");
            }


        }
    }

}
