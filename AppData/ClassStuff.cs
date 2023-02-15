using Konditer_FigmaProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konditer_FigmaProject.AppData
{
    public partial class ClassStuff
    {
        public string Hellow
        {
            get
            {
                string name = $"{lastname}!";
                return name;
            }
        }

        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public int doljnsot { get; set; }
    }

}
