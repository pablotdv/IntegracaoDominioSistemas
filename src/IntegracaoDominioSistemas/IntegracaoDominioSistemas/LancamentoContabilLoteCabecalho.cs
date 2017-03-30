using System;

namespace IntegracaoDominioSistemas
{
    public class LancamentoContabilLoteCabecalho : ILinha
    {
        [Posicao(3, 9)]
        public int CodigoEmpresa { get; set; }

        [Posicao(1, 2)]
        public string Identificador { get { return "01"; } }       

        [Posicao(10, 23)]
        public string CnpjEmpresa { get; set; }

        [Posicao(24, 33)]
        public DateTime DataInicialLancamentos { get; set; }

        [Posicao(34, 43)]
        public DateTime DataFinalLancamentos { get; set; }

        [Posicao(44, 44)]
        public string ValorFixo { get { return "N"; } }

        [Posicao(45, 46)]
        public TipoNota TipoNota { get; set; }

        [Posicao(47, 51)]
        public int Constante { get { return 0; } }

        [Posicao(52, 52)]
        public Sistema Sistema { get; set; }

        [Posicao(53, 54)]
        public string ValorFixo2 { get { return "17"; } }

        public LancamentoContabilLoteCabecalho()
            : this(new GerarLinha())
        {

        }

        IGerarLinha _gerarLinha;
        public LancamentoContabilLoteCabecalho(IGerarLinha gerarLinha)
        {
            _gerarLinha = gerarLinha;
        }

        public override string ToString()
        {
            return _gerarLinha.Gerar(this);            
        }
    }
}