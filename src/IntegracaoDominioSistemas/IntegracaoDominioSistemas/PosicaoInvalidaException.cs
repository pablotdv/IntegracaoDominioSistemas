using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoDominioSistemas
{
    public class PosicaoInvalidaException : Exception
    {
        public PosicaoInvalidaException()
        {

        }
        public PosicaoInvalidaException(string message)
            : base(message)
        {

        }
    }
}
