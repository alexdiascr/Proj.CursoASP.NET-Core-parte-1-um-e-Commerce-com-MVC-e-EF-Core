using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                //utilizando a clausula where do linq e o linq utiliza uma expressão labda 
                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any()) //utilizando any para retorna verdadeiro caso existir conforme a expressão 
                {
                    //Acessando o db set que está dentro do contexto
                    //.Add - método para adicionar uma nova instância de produto dentro da lista de produtos
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }
            contexto.SaveChanges();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
