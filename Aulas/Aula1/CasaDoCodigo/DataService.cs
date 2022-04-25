using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext contexto, 
                            IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }


        public void InicializaDB()
        {
            //garante que o banco de dados foi criado
            /*Antes se usava o método EnsureCreated, ele cria um banco verificando se tal banco foi criando
            // ou não e se não foi criado o mesmo procura no modelo ou no mapeamento para poder fazer o 
            //esquema e criar o banco de dados. O problema do ensureCreated, depois de criar um banco utili-
            //zando o mesmo, não se pode mais criar nenhuma migração no sistema. O mesmo é mais utilizado para
            //aplicações pequenas, de testes.*/


            /*O método migrate cria bancos da mesma maneira que o EnsureCreated, no entanto através de migrations
             * o que permite logo depois criar novas migrations se for necessário*/


            /*Além disso, uma vez que o banco de dados foi gerado através do método EnsureCreated(), a aplicação 
             * não pode mais usar migrations. Por isso, a não ser que uma aplicação seja pequena e destinada a 
             * testes, é recomendável usar sempre o método Migrate().*/
            contexto.Database.Migrate();

            List<Livro> livros = GetLivros();

            produtoRepository.SaveProdutos(livros);
        }        

        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");

            //convertendo de json para objetos
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }   
}
 