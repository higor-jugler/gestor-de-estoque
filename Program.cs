using System.Runtime.Serialization.Formatters.Binary;

namespace GestorDeEstoque
{
    class Program
    {        
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        enum MenuProduto { ProdutoFisico = 1, Ebook, Curso }
        static void Main(string[] args)
        {
            Carregar();
            bool sairApp = false;
            while (!sairApp)
            {
                Console.WriteLine("Bem vindo ao sistema Gestor de Estoque");
                Console.WriteLine("Selecione no menu a opção desejada: \n");
                Console.WriteLine("1 - Listar\n2 - Adicionar\n3 - Remover\n4 - Entrada\n" +
                    "5 - Saida\n6 - Sair do app Gestor de Estoque");

                Menu menu = (Menu)int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case Menu.Listar:
                        Listagem();
                        break;
                    case Menu.Adicionar:
                        Cadastro();
                        break;
                    case Menu.Remover:
                        Remover();
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
        static void Cadastro()
        {
            Console.WriteLine("Cadstro de Produto");
            Console.WriteLine("1-Produto Fisico\n2 - Ebook\n3 - Curso");
            MenuProduto menuProduto = (MenuProduto)int.Parse(Console.ReadLine());
            switch (menuProduto)
            {
                case MenuProduto.ProdutoFisico:
                    CadastrarPFisico();
                    break;
                case MenuProduto.Ebook:
                    CadastrarEbook();
                    break;
                case MenuProduto.Curso:
                    CadastrarCurso();
                    break;
            }
        }
        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastrando produto físico: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }
        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrar Ebook: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook ebook = new Ebook(nome, preco, autor);
            produtos.Add(ebook);
            Salvar();
        }
        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrar Curso: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Curso curso = new Curso(nome, preco, autor);
            produtos.Add(curso);
            Salvar();
        }
        static void Salvar()
        {
            FileStream fileStream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(fileStream, produtos);

            fileStream.Close();
        }
        static void Carregar()
        {
            FileStream fileStream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)formatter.Deserialize(fileStream);
                if (produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch (Exception e)
            {
                produtos = new List<IEstoque>();
            }
            fileStream.Close();
        }
        static void Listagem()
        {
            Console.WriteLine("Lista de Produtos: ");
            int i = 0;
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine($"ID: {i}");
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }
        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite a ID que você deseja apagar: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }
    }
}