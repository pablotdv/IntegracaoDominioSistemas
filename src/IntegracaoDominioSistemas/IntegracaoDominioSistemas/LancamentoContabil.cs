using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoDominioSistemas
{
    public class LancamentoContabil
    {
        public LancamentoContabilCabecalho Cabecalho { get; set; }
        public List<LancamentoContabilLote> Lotes { get; set; }
    }
}
