using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Entities
{
    public class Eroe : Personaggio
    {
        public int PuntiAccumulati { get; set; }
        public int IdGiocatore { get; set; }

        public Eroe()
        {

        }
    }
}
