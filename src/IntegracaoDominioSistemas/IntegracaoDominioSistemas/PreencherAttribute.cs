using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoDominioSistemas
{
    public class PreencherAttribute : Attribute
    {
        private PreencherTipo _tipo;
        public PreencherTipo Tipo { get { return _tipo; } set { _tipo = value; } }

        public PreencherAttribute(PreencherTipo tipo)
        {
            Tipo = tipo;
        }


    }
}
