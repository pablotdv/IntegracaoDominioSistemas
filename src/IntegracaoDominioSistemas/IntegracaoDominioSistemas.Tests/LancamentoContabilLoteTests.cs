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
        LancamentoContabilLote lote;
        [TestInitialize]
        public void Initialize()
        {
            lote = new LancamentoContabilLote()
            {
                CodigoSequencial = 1,
                Tipo = "X",
                DataLancamento = new DateTime(2017, 03, 20),
                Usuario = "USUSARIO.TESTE",

            };
        }
        [TestMethod()]
        public void Lote_ToStringTest()
        {
            string experado = "020000001X20/03/2017USUSARIO.TESTE                                                                                                                    ";
            string retornado = lote.ToString();

            Assert.AreEqual(experado, retornado);
        }        
    }
}