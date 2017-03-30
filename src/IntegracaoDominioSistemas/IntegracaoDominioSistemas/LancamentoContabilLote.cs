using System;
using System.Collections.Generic;

namespace IntegracaoDominioSistemas
{
    public class LancamentoContabilLote: ILinha
    {
        [Posicao(1, 2)]
        public string Identificador { get { return "02"; } }

        [Posicao(3, 9)]
        [Preencher(PreencherTipo.ZerosEsquerda)]
        public int CodigoSequencial { get; set; }

        [Posicao(10, 10)]
        public string Tipo { get; set; }

        [Posicao(11, 20)]
        [Formato("dd/MM/yyyy")]
        public DateTime DataLancamento { get; set; }

        [Posicao(21, 50)]
        [Preencher(PreencherTipo.BrancosDireita)]
        public string Usuario { get; set; }

        [Posicao(51, 150)]
        [Preencher(PreencherTipo.BrancosDireita)]
        public string Brancos { get { return ""; } }

        IGerarLinha _gerarLinha;
        public LancamentoContabilLote(IGerarLinha gerarLinha)
        {
            _gerarLinha = gerarLinha;
        }

        public LancamentoContabilLote()
            :this(new GerarLinha())
        {

        }

        public override string ToString()
        {
            return _gerarLinha.Gerar(this);
        }
    }
}