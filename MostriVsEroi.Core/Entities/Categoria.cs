using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Entities
{
    public class Categoria
    {
        public string Nome { get; set; }
        public int Id { get; set; }

        public Categoria(string nome, int id)
        {
            Nome = nome;
            Id = id;
        }
        public Categoria()
        {

        }
    }
}
