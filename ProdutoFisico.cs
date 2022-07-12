using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeEstoque
{
    internal class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        ProdutoFisico(string nome, float preco, float frete, int estoque)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
            this.estoque = estoque;
        }

        public void AdicionarEntrada()
        {
            
        }

        public void AdicionarSaida()
        {
            
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"R$: {preco}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("======================");
        }
    }
}
