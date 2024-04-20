using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Year:IEntity
    {
        public int Id { get; set; }
        public string YearInfo { get; set; }
    }
}
