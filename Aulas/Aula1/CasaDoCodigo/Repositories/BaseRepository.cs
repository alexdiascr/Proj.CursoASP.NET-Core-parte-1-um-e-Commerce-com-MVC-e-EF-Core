using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        //campos protected para que os mesmos sejam visíveis por todoas as classe derivadas
        protected readonly ApplicationContext contexto; 
        protected readonly DbSet<T> dbSet;


        /*Como a classe ProdutoRepository vai instaciar o contexto? 
        //Não vai ser instaciado, pois a mesma vai receber no construtor 
        //através da injeção de depêndencia */
        //Assim o contexto sendo fornecido via injeção de depêndencia

        public BaseRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<T>();
        }
    }
}
