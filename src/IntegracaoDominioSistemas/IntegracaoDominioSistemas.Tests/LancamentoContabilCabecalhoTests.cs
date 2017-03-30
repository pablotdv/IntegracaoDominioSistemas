using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracaoDominioSistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoDominioSistemas.Tests
{
    [TestClass()]
    public class LancamentoContabilCabecalhoTests
    {

        [TestMethod()]
        public void Lote_ToStringTest()
        {
            LancamentoContabilCabecalho cabecalho = new LancamentoContabilCabecalho()
            {
                CodigoEmpresa = 3,
                CnpjEmpresa = "85844000000120",
                DataInicialLancamentos = new DateTime(2017, 03, 20),
                DataFinalLancamentos = new DateTime(2017, 03, 29),
                TipoNota = TipoNota.ContabilidadeLancamentosLotes,
                Sistema = Sistema.Outro
            };

            var linha = cabecalho.ToString();

            Assert.AreEqual("0100000038584400000012020/03/201729/03/2017N0500000017", linha);
        }
    }
}