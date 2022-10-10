namespace Blog.Screens.RoleScreens
{
    public class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de usuário");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar perfis");
            Console.WriteLine("2 - Cadastrar perfil");
            Console.WriteLine("3 - Atualizar perfil");
            Console.WriteLine("4 - Deletar perfil");
            Console.WriteLine();
            Console.WriteLine("0 - Voltar para o inicio");
            Console.WriteLine();
            Console.Write("Digite sua escolha: ");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListRolesScreen.Load();
                    break;
                case 2:
                    CreateRoleScreen.Load();
                    break;
                case 3:
                    UpdateRoleScreen.Load();
                    break;
                case 4:
                    DeleteRoleScreen.Load();
                    break;
                default:
                    Program.Load();
                    break;
            }
        }
    }
}
