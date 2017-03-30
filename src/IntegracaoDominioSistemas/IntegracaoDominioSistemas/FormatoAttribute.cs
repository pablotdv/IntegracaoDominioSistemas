using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoDominioSistemas
{
    public class FormatoAttribute : Attribute
    {
        private string _formato;
        public string Formato { get { return _formato; } set { _formato = value; } }

        public FormatoAttribute(string formato)
        {
            _formato = formato;
        }


    }
}
