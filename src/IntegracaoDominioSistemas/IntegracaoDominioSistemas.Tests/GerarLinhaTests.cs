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

        [TestMethod]
        public void Gerar_CampoInteiro_ZerosEsquerda_Tamanho5_Test()
        {
            string retorno = gerarLinha.Gerar(new InteiroZerosEsquerda() { Campo = 9 });
            Assert.AreEqual("00009", retorno);
            Assert.AreEqual(5, retorno.Length);
        }

        [TestMethod]
        public void Gerar_CampoInteiro_ZerosDireita_Tamanho5_Test()
        {
            string retorno = gerarLinha.Gerar(new InteiroZerosDireita() { Campo = 9 });
            Assert.AreEqual("90000", retorno);
            Assert.AreEqual(5, retorno.Length);
        }

        [TestMethod]
        public void Gerar_CampoInteiro_ZerosDireitaEsquerda_Tamanho5_Test()
        {
            string retorno = gerarLinha.Gerar(new InteiroZerosDireitaEsquerda() { Campo = 9, Campo2 = 5 });
            Assert.AreEqual("9000000005", retorno);
            Assert.AreEqual(10, retorno.Length);
        }

        [TestMethod]
        public void Gerar_CampoData_Formato_Tamanho10_Test()
        {
            string retorno = gerarLinha.Gerar(new DataFormat() { Data = new DateTime(2017, 03, 30) });
            Assert.AreEqual("30/03/2017", retorno);
            Assert.AreEqual(10, retorno.Length);
        }

        [TestMethod]
        public void Gerar_CampoFixo_2_Test()
        {
            string retorno = gerarLinha.Gerar(new ValorFixoModel());
            Assert.AreEqual("01", retorno);
            Assert.AreEqual(2, retorno.Length);
        }

        [TestMethod]
        public void Gerar_CampoNumerico_Tamanho15_PreencherZerosEsquerda_Test()
        {
            string retorno = gerarLinha.Gerar(new ValorNumericoModel() { Valor = 111.55M });
            string experado = "11155".PadLeft(15, '0');
            Assert.AreEqual(experado, retorno);
            Assert.AreEqual(15, retorno.Length);
        }

        [TestMethod]
        public void Gerar_CampoNumericoMilhar_Tamanho15_PreencherZerosEsquerda_Test()
        {
            string retorno = gerarLinha.Gerar(new ValorNumericoModel() { Valor = 1111.55M });
            string experado = "111155".PadLeft(15, '0');
            Assert.AreEqual(experado, retorno);
            Assert.AreEqual(15, retorno.Length);
        }


        [TestMethod]
        public void Gerar_CampoTipoEnum_Tamanho2_PreencherZerosEsquerda_Test()
        {
            string retorno = gerarLinha.Gerar(new TipoEnumModel() { Valor = TipoEnum.Valor2 });
            string experado = "02";
            Assert.AreEqual(experado, retorno);
            Assert.AreEqual(2, retorno.Length);
        }

        [TestMethod]
        public void Gerar_CampoString_BrancosDireita_Tamanho50_Test()
        {
            string retorno = gerarLinha.Gerar(new StringBrancosDireita() { Campo = "STR"});
            string experado = "STR".PadRight(50, ' ');
            Assert.AreEqual(experado, retorno);
            Assert.AreEqual(50, retorno.Length);
        }

    }

    internal class StringBrancosDireita : ILinha
    {
        [Posicao(1, 50)]
        [Preencher(PreencherTipo.BrancosDireita)]
        public string Campo { get; set; }        
    }

    public enum TipoEnum
    {        
        Valor1 = 1,
        Valor2 = 2
    }
    internal class TipoEnumModel : ILinha
    {
        [Posicao(1, 2)]
        [Preencher(PreencherTipo.ZerosEsquerda)]        
        public TipoEnum Valor { get; set; }
    }

    internal class ValorNumericoModel : ILinha
    {
        [Posicao(1, 15)]
        [Numerico(13, 2)]
        [Preencher(PreencherTipo.ZerosEsquerda)]
        public decimal Valor { get; set; }
    }

    internal class ValorFixoModel : ILinha
    {
        [Posicao(1, 2)]
        public string ValorFixo { get { return "01"; } }
    }

    internal class DataFormat : ILinha
    {
        [Posicao(1, 10)]
        [Formato("dd/MM/yyyy")]
        public DateTime Data { get; set; }
    }

    internal class InteiroZerosDireitaEsquerda : ILinha
    {
        [Posicao(1, 5)]
        [Preencher(PreencherTipo.ZerosDireita)]
        public int Campo { get; set; }

        [Posicao(6, 10)]
        [Preencher(PreencherTipo.ZerosEsquerda)]
        public int Campo2 { get; set; }
    }

    internal class InteiroZerosDireita : ILinha
    {
        [Posicao(1, 5)]
        [Preencher(PreencherTipo.ZerosDireita)]
        public int Campo { get; set; }
    }

    internal class InteiroZerosEsquerda : ILinha
    {
        [Posicao(1, 5)]
        [Preencher(PreencherTipo.ZerosEsquerda)]
        public int Campo { get; set; }
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