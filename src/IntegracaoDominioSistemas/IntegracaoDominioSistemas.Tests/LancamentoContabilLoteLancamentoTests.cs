using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegracaoDominioSistemas.Tests
{
    /// <summary>
    /// Summary description for LancamentoContabilLoteLancamentoTests
    /// </summary>
    [TestClass]
    public class LancamentoContabilLoteLancamentoTests
    {
        [TestMethod]
        public void LoteLancamento_ToString()
        {
            LancamentoContabilLoteLancamento lancamento = new LancamentoContabilLoteLancamento()
            {
                CodigoSequencial = 2,
                ContaDebito = 1500,
                ContaCredito = 1700,
                ValorLancamento = 55.00M,
                CodigoHistorico = 0,
                Historico = "VLR REF",
                CodigoFilial = 3                

            };            

            var experado = "030000002000150000017000000000000055000000000VLR REF                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         0000003                                                                                                    ";
            var retornado = lancamento.ToString();

            Assert.AreEqual(experado, retornado);
            Assert.AreEqual(664, retornado.Length);
        }
    }
}
