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

        [Posicao(0,100)]
        public string Fim { get { return "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999"; } }

        public LancamentoContabil()
            :this(new GerarLinha())
        {
            Lotes = new List<LancamentoContabilLote>();
        }

        IGerarLinha _gerarLinha;

        public LancamentoContabil(IGerarLinha gerarLinha)
        {
            _gerarLinha = gerarLinha;
        }

        public override string ToString()
        {
            return _gerarLinha.Gerar(this);
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

            retorno.AppendLine(this.ToString());

            return retorno;
        }


    }
}
