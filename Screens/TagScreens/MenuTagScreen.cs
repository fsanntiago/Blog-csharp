namespace Blog.Screens.TagScreens
{
    public class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de tag");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar tags");
            Console.WriteLine("2 - Cadastrar tag");
            Console.WriteLine("3 - Atualizar tag");
            Console.WriteLine("4 - Deletar tag");
            Console.WriteLine();
            Console.WriteLine("0 - Voltar para o inicio");
            Console.WriteLine();
            Console.Write("Digite sua escolha: ");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListTagsScreen.Load();
                    break;
                case 2:
                    CreateTagScreen.Load();
                    break;
                case 3:
                    UpdateTagScreen.Load();
                    break;
                case 4:
                    DeleteTagScreen.Load();
                    break;
                default:
                    Program.Load();
                    break;
            }
        }
    }
}
