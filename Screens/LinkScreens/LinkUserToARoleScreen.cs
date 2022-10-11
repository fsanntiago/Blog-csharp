using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.LinkScreens
{
    public class LinkUserToARoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.Write("Digite o email do usuário: ");
            var email = Console.ReadLine();
            var userExists = UserExists(email);
            if (!userExists)
            {
                Console.WriteLine("Voltando para o menu principal...");
                Thread.Sleep(5000);
                Program.Load();
            }

            Console.WriteLine();
            Console.WriteLine("Lista de perfis");
            Console.WriteLine("---------------");
            ListRoles();

            Console.WriteLine();
            Console.Write("Informe o numero do perfil que deseja vincular a esse usuário: ");
            var role = int.Parse(Console.ReadLine()!);

            Link(email, role);
        }

        public static bool UserExists(string email)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);

                var user = repository.GetByEmail(email);
                return user != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel encontrar o usuário");
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static void Link(string email, int roleId)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);

                var user = repository.GetByEmail(email);

                var insert = repository.LinkUserToARole(user.Id, roleId);
                if (insert)
                    Console.WriteLine("Usuário vinculado com sucesso!");
                else
                {
                    Console.WriteLine("Não foi possivel vincular o usuário");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel vincular o usuário");
                Console.WriteLine(ex.Message);
            }


        }

        public static void ListRoles()
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                var roles = repository.Get();

                Console.WriteLine("Perfis\n");
                foreach (var role in roles)
                {
                    Console.Write($"{role.Id} - ");
                    Console.WriteLine(role.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível listar os perfis");
                Console.WriteLine(ex.Message);
            }

        }
    }
}
