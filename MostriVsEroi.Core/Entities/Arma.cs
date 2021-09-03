using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Entities
{
    public class Arma
        {
            public string Nome { get; set; }

            public int PuntiDanno { get; set; }

            public int Id { get; set; }

        public Arma()
        {
         
        }
        public Arma(string nome, int puntiDanno, int id)
            {
                Nome = nome;
                PuntiDanno = puntiDanno;
                Id = id;
            }
            public Arma(string nome, int puntiDanno)
            {
                Nome = nome;
                PuntiDanno = puntiDanno;
            }
        }
}
