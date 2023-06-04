using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRest.Abstraction
{
    public interface IEntity
    {
        int Id { get; set; }
      
    }
    public interface ISearch
    {
        long Cedula { get; set; }
    }
}
