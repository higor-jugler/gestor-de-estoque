namespace GestorDeEstoque
{
    class Program
    {
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        static void Main(string[] args)
        {
            bool sairApp = false;
            while (!sairApp)
            {
                Console.WriteLine("Bem vindo ao sistema Gestor de Estoque");
                Console.WriteLine("Selecione no menu a opção desejada: \n");
                Console.WriteLine("1 - Listar\n2 - Adicionar\n3 - Remover\n4 - Entrada\n" +
                    "5 - Saida\n6 - Sair");

                Menu menu = (Menu)int.Parse(Console.ReadLine());

                switch(menu)
                {
                    case Menu.Listar:
                        break;
                    case Menu.Adicionar:
                        break;
                    case Menu.Remover:
                        break;
                    case Menu.Entrada:
                        break;
                    case Menu.Saida:
                        break;
                    case Menu.Sair:
                        sairApp = true;
                        break;
                }
            }

        }
    }
}