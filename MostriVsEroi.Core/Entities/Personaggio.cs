using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Entities
{
    public abstract class Personaggio
    {
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public Arma Arma { get; set; }
        public int Livello { get; set; }
        public int PuntiVita { get; set; }
        public int Id { get; set; }
    }
}
