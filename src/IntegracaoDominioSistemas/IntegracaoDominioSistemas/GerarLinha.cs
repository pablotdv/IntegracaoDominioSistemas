using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoDominioSistemas
{
    public class GerarLinha : IGerarLinha
    {
        public string Gerar(ILinha obj)
        {
            string retorno = "";
            var properties = obj.GetType().GetProperties().Where(a => a.GetCustomAttributes(typeof(PosicaoAttribute), true).Count() > 0)
                .OrderBy(a => ((PosicaoAttribute)a.GetCustomAttributes(typeof(PosicaoAttribute), true)[0]).Inicial)
                .ToList();

            if (!properties.Any(a => ((PosicaoAttribute)a.GetCustomAttributes(typeof(PosicaoAttribute), true)[0]).Inicial == 1))
                throw new PosicaoInvalidaException("Não existe nenhuma propriedade que começa na posição inicial 1");

            for (int i = 0; i < properties.Count; i++)
            {
                PropertyInfo property = properties[i];
                PosicaoAttribute posicao = property.GetCustomAttribute<PosicaoAttribute>(true);
                PreencherAttribute preencher = property.GetCustomAttribute<PreencherAttribute>(true);
                FormatoAttribute formato = property.GetCustomAttribute<FormatoAttribute>(true);
                NumericoAttribute numerico = property.GetCustomAttribute<NumericoAttribute>(true);

                if (i > 0)
                {
                    var posicaoAnterior = properties[i - 1].GetCustomAttribute<PosicaoAttribute>(true);

                    if (posicaoAnterior.Final + 1 != posicao.Inicial)
                        throw new PosicaoInvalidaException($"As posição inicial da propriedade {property.Name} não é valida");
                }

                if (posicao.Final < posicao.Inicial)
                    throw new PosicaoInvalidaException($"A posição final da propriedade {property.Name} deve ser maior que a inicial");

                int tamanho = posicao.Final - posicao.Inicial + 1;

                string valor = property.GetValue(obj).ToString();

                if (property.PropertyType.IsEnum)
                {
                    var fields = property.PropertyType.GetFields(BindingFlags.Public | BindingFlags.Static);

                    foreach(var field in fields)
                    {
                        if (valor == field.Name)
                        {
                            valor = ((int)field.GetValue(obj)).ToString();
                            break;
                        }
                    }
                }

                if (numerico != null)
                {
                    valor = valor.Replace(",", "");
                }

                if (preencher != null)
                {
                    switch (preencher.Tipo)
                    {
                        case PreencherTipo.ZerosEsquerda: valor = valor.PadLeft(tamanho, '0'); break;
                        case PreencherTipo.ZerosDireita: valor = valor.PadRight(tamanho, '0'); break;
                    }
                }

                if (formato != null)
                {
                    if (property.PropertyType == typeof(DateTime))
                    {
                        var data = Convert.ToDateTime(property.GetValue(obj));
                        valor = data.ToString(formato.Formato);
                    }
                }

                retorno += valor;
            }


            return retorno;
        }
    }
}
