using MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Interfaces
{
    public interface IEroeRepository
    {
        public List<Eroe> FetchById(Giocatore giocatore);
    }
}
