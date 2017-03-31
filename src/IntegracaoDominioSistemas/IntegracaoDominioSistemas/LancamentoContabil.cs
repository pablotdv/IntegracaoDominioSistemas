using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoDominioSistemas
{
    public class LancamentoContabil : ILinha
    {
        [Linhas]
        public LancamentoContabilCabecalho Cabecalho { get; set; }

        [Linhas]
        public List<LancamentoContabilLote> Lotes { get; set; }

        public LancamentoContabil()
        {
            Lotes = new List<LancamentoContabilLote>();
        }

        public StringBuilder GerarTxt()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(Cabecalho.ToString());

            foreach(var lote in Lotes)
            {
                retorno.AppendLine(lote.ToString());
                foreach(var lancamento in lote.Lancamentos)
                {
                    retorno.AppendLine(lancamento.ToString());
                }
            }

            return retorno;
        }


    }
}
