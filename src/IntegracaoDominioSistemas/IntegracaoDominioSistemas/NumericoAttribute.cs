using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoDominioSistemas
{
    public class NumericoAttribute : Attribute
    {
        private int _escala;
        private int _precisao;
        public NumericoAttribute(int escala, int precisao)
        {
            _escala = escala;
            _precisao = precisao;
        }
    }
}
