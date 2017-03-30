using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoDominioSistemas
{
    public class LancamentoContabilLote
    {
        public LancamentoContabilLoteCabecalho Cabecalho { get; set; }
        public List<LancamentoContabilLoteLote> Lotes { get; set; }
    }
}
