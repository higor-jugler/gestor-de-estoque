using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeEstoque
{
    [System.Serializable]
    internal class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Produto digital, não à como inserir entrada.");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas no ebook {nome}");
            Console.WriteLine("Qtde a vendas: ");
            int entrada = int.Parse(Console.ReadLine());
            vendas -= entrada;
            Console.WriteLine("Saida registrado");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"R$: {preco}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine("======================");
        }
    }
}
