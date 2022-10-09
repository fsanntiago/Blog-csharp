using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando usuário");
            Console.WriteLine("------------------");
            Console.Write("Digite o ID do usuário que deseja atualizar:");
            var id = int.Parse(Console.ReadLine()!);

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

            Update(new User()
            {
                Id = id,
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

        public static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Update(user);
                Console.WriteLine("Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
