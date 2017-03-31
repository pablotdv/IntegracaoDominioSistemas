using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace IntegracaoDominioSistemas.Tests
{
    [TestClass]
    public class LancamentoContabilTests
    {
        [TestMethod]
        public void LancamentoContabil_GerarTxt()
        {
            LancamentoContabil lancamentoContabil = new LancamentoContabil();

            lancamentoContabil.Cabecalho = new LancamentoContabilCabecalho()
            {
                CodigoEmpresa = 3,
                CnpjEmpresa = "85844000000120",
                DataInicialLancamentos = new DateTime(2017, 03, 20),
                DataFinalLancamentos = new DateTime(2017, 03, 29),
                TipoNota = TipoNota.ContabilidadeLancamentosLotes,
                Sistema = Sistema.Outro
            };

            lancamentoContabil.Lotes.Add(new LancamentoContabilLote()
            {
                CodigoSequencial = 1,
                Tipo = "X",
                DataLancamento = new DateTime(2017, 03, 20),
                Usuario = "USUSARIO.TESTE",
                Lancamentos = new List<LancamentoContabilLoteLancamento>()
                {
                    new LancamentoContabilLoteLancamento()
                    {
                        CodigoSequencial = 2,
                        ContaDebito = 1500,
                        ContaCredito = 1700,
                        ValorLancamento = 55.00M,
                        CodigoHistorico = 0,
                        Historico = "VLR REF",
                        CodigoFilial = 3
                    }
                }
            });

            StringBuilder experado = new StringBuilder();
            experado.AppendLine("0100000038584400000012020/03/201729/03/2017N0500000017");
            experado.AppendLine("020000001X20/03/2017USUSARIO.TESTE                                                                                                                    ");
            experado.AppendLine("030000002000150000017000000000000055000000000VLR REF                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         0000003                                                                                                    ");

            var retornado = lancamentoContabil.GerarTxt();

            using (StreamWriter sw = File.CreateText("d:\\experado.txt"))
            {
                sw.Write(experado.ToString());
            }

            using (StreamWriter sw = File.CreateText("d:\\retornado.txt"))
            {
                sw.Write(retornado.ToString());
            }

            
            Assert.AreEqual(experado.ToString(), retornado.ToString());

            var originalHash = GetFileHash("d:\\retornado.txt");
            var copiedHash = GetFileHash("d:\\experado.txt");

            Assert.AreEqual(copiedHash, originalHash);
        }

        public string GetFileHash(string filename)
        {
            var hash = new SHA1Managed();
            var clearBytes = File.ReadAllBytes(filename);
            var hashedBytes = hash.ComputeHash(clearBytes);
            return ConvertBytesToHex(hashedBytes);
        }

        public string ConvertBytesToHex(byte[] bytes)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x"));
            }
            return sb.ToString();
        }
    }
}
