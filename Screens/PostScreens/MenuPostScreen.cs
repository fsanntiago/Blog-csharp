namespace Blog.Screens.PostScreens
{
    public class MenuPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de post");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar post");
            Console.WriteLine("2 - Cadastrar post");
            Console.WriteLine("3 - Atualizar post");
            Console.WriteLine("4 - Deletar post");
            Console.WriteLine();
            Console.WriteLine("0 - Voltar para o inicio");
            Console.WriteLine();
            Console.Write("Digite sua escolha:");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListPostsScreen.Load();
                    break;
                case 2:
                    CreatePostScreen.Load();
                    break;
                case 3:
                    UpdatePostScreen.Load();
                    break;
                case 4:
                    DeletePostScreen.Load();
                    break;
                default:
                    Program.Load();
                    break;
            }
        }

    }
}
