using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers
{
    public class ListOfEntityResult<Type> where Type : class
    {
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
        public List<Type> Data { get; set; }
    }
}
