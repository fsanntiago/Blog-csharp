using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class ListUsersScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de usuário");
            Console.WriteLine("------------------");

            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void List()
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                var users = repository.GetWithRoles();

                Console.WriteLine($"{"Nome",-30}{"Email",-30}{"Perfis",-20}\n");
                foreach (var user in users)
                {
                    Console.Write($"{user.Name,-30}{user.Email,-30}");
                    if (!user.Roles.Any())
                    {
                        Console.WriteLine($"{"-",-20}");
                        continue;
                    }

                    foreach (var role in user.Roles)
                    {
                        if (user.Roles.IndexOf(role) + 1 == user.Roles.Count)  // Ultimo item da lista
                        {
                            Console.WriteLine($"{role.Name,-20}");
                        }
                        else
                        {
                            Console.Write($"{role.Name}, ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível listar os usuário");
                Console.WriteLine(ex.Message);
            }


        }
    }
}
