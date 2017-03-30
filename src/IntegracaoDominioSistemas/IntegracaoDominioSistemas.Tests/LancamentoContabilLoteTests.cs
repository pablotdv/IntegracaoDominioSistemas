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
    public class LancamentoContabilLoteTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            LancamentoContabilLote lote = new LancamentoContabilLote() {
                CodigoSequencial = 1,
                Tipo = "X",
                DataLancamento = new DateTime(2017, 03, 20),
                Usuario = "USUSARIO.TESTE",                

            };

            string experado = "020000001X20/03/2017USUSARIO.TESTE                                                                                                                    ";
            string retornado = lote.ToString();

            Assert.AreEqual(experado, retornado);
        }
    }
}