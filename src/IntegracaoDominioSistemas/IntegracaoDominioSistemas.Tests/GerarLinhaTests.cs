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
    public class GerarLinhaTests
    {
        GerarLinha gerarLinha;

        [TestInitialize]
        public void Initialize()
        {
            gerarLinha = new GerarLinha();
        }

        [TestMethod]
        [ExpectedException(typeof(PosicaoInvalidaException))]
        public void Gerar_LinhaInicialInvalida_Test()
        {
            gerarLinha.Gerar(new LinhaPosicaoInicialInvalida());
        }

        [TestMethod]
        [ExpectedException(typeof(PosicaoInvalidaException))]
        public void Gerar_LinhaPosicaoInvalida_Test()
        {            
            gerarLinha.Gerar(new LinhaPosicaoInvalida());
        }

        [TestMethod]        
        public void Gerar_LinhaPosicaoValida_Test()
        {
            gerarLinha.Gerar(new LinhaPosicaoValida());
        }

        [TestMethod]
        [ExpectedException(typeof(PosicaoInvalidaException))]
        public void Gerar_LinhaPosicaoFinalMenor_Test()
        {
            gerarLinha.Gerar(new LinhaPosicaoFinalMenor());
        }

        [TestMethod()]
        public void Gerar_CampoInteiro_Tamanho1_Test()
        {            
            Linha linha = new Linha()
            {
                Campo = 9
            };


            Assert.AreEqual("9", gerarLinha.Gerar(linha));            
        }
    }

    internal class Linha : ILinha
    {
        [Posicao(1, 1)]
        public int Campo { get; set; }
    }

    internal class LinhaPosicaoInicialInvalida : ILinha
    {
        [Posicao(2, 2)]
        public int Campo { get; set; }        
    }

    internal class LinhaPosicaoInvalida : ILinha
    {
        [Posicao(1, 1)]
        public int Campo { get; set; }

        [Posicao(3, 3)]
        public int Campo2 { get; set; }
    }

    internal class LinhaPosicaoValida : ILinha
    {
        [Posicao(1, 1)]
        public int Campo { get; set; }

        [Posicao(2, 3)]
        public int Campo2 { get; set; }
    }

    internal class LinhaPosicaoFinalMenor : ILinha
    {
        [Posicao(1, 1)]
        public int Campo { get; set; }

        [Posicao(2, 1)]
        public int Campo2 { get; set; }
    }
}