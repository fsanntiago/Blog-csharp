using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar um usuário");
            Console.WriteLine("----------------");
            Console.Write("Digite o Nome:");
            var name = Console.ReadLine();

            Console.Write("Digite o Email:");
            var email = Console.ReadLine();

            Console.Write("Digite a Senha:");
            var password = Console.ReadLine();

            Console.Write("Digite a Bio:");
            var bio = Console.ReadLine();

            Console.Write("Digite o link da Imagem:");
            var image = Console.ReadLine();

            Console.Write("Digite o Slug:");
            var slug = Console.ReadLine();
            Console.WriteLine();

            Create(new User()
            {
                Name = name,
                Email = email,
                PasswordHash = password,
                Bio = bio,
                Image = image,
                Slug = slug

            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(user);
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível cadastrar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
