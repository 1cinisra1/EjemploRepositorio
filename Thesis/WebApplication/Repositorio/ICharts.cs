using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Repositorio
{
   public  interface ICharts
    {
      void ListaTecnicos(out string Tecnicos, out string Cantidad); 
    }
}
