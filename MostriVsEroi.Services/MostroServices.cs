using MostriVsEroi.Core.Entities;
using MostriVsEroi.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Services
{
    public class MostroServices
    {
        static MostroRepository mr = new MostroRepository();
        public static Mostro ScegliMostro(Eroe eroe)
        {
            List<Mostro> mostri = mr.GetByEroeLevel(eroe);
            Random random = new Random();
            int sceltaMostro = random.Next(1, mostri.Count+1);
            Mostro mostroEstratto = mostri.ElementAt(sceltaMostro - 1);

            return mostroEstratto;
        }
    }
}
