namespace IntegracaoDominioSistemas
{
    public class LancamentoContabilLoteLancamento : ILinha
    {
        [Posicao(1, 2)]
        public string Identificador { get { return "03"; } }

        [Posicao(3, 9)]
        [Preencher(PreencherTipo.ZerosEsquerda)]
        public int CodigoSequencial { get; set; }

        [Posicao(10, 16)]
        [Preencher(PreencherTipo.ZerosEsquerda)]
        public int ContaDebito { get; set; }

        [Posicao(17, 23)]
        [Preencher(PreencherTipo.ZerosEsquerda)]
        public int ContaCredito { get; set; }

        [Posicao(24, 38)]
        [Preencher(PreencherTipo.ZerosEsquerda)]
        [Numerico(13, 2)]
        public decimal ValorLancamento { get; set; }

        [Posicao(39, 45)]
        [Preencher(PreencherTipo.ZerosEsquerda)]
        public int CodigoHistorico { get; set; }

        [Posicao(46, 557)]
        [Preencher(PreencherTipo.BrancosDireita)]
        public string Historico { get; set; }

        [Posicao(558, 564)]
        [Preencher(PreencherTipo.ZerosEsquerda)]
        public int CodigoFilial { get; set; }

        [Posicao(565, 664)]
        [Preencher(PreencherTipo.BrancosDireita)]
        public string Brancos { get { return ""; } }

        IGerarLinha _gerarLinha;

        public LancamentoContabilLoteLancamento(IGerarLinha gerarLinha)
        {
            _gerarLinha = gerarLinha;
        }

        public LancamentoContabilLoteLancamento()
            : this(new GerarLinha())
        {

        }

        public override string ToString()
        {
            return _gerarLinha.Gerar(this);
        }
    }
}