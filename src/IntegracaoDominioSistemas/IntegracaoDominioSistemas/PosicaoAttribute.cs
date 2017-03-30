using System;

namespace IntegracaoDominioSistemas
{
    public class PosicaoAttribute : Attribute
    {
        private int _inicial;
        private int _final;
        public int Inicial { get { return _inicial; } set { _inicial = value; } }
        public int Final { get { return _final; } set { _final = value; } }

        public PosicaoAttribute(int inicial, int final)
        {
            Inicial = inicial;
            Final = final;
        }
    }
}