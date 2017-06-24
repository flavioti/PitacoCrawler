using HtmlAgilityPack;
using PitacoCrawler.Models;
using System;
using System.IO;

namespace PitacoCrawler.Seekers
{
    public class Lotofacil : LoteriaBase
    {
        public Lotofacil() : base()
        {
            base.url = "http://www1.caixa.gov.br/loterias/_arquivos/loterias/D_lotfac.zip";
            base.referal = "http://loterias.caixa.gov.br/wps/portal/loterias/landing/lotofacil/";
            base.pastaDestino = @"E:/Loteria/lotofacil/";
            this.destino = Path.GetFileName(url);
            base.arquivoHtml = "D_LOTFAC.HTM";
        }

        public override void interpretarHtml()
        {
            base.interpretarHtml();

            HtmlDocument doc = new HtmlDocument();
            doc.Load(pastaDestino + arquivoHtml);

            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
            {
                int i = 1;
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    if (i > 1)
                    {
                        //int qtdColunas = row.SelectNodes("th|td").Count;
                        //foreach (HtmlNode cell in row.SelectNodes("th|td"))
                        //{
                        //    qtdColunas++;
                        //    Console.WriteLine("Indice: " + qtdColunas + " cell: " + cell.InnerText);
                        //}
                        //if (qtdColunas == 2)
                        //{
                        //    // loop de cidade, vou implementar
                        //    continue;
                        //}
                        if (row.SelectNodes("th|td").Count == 33)
                        {
                            Console.WriteLine("Lotofacil");

                            Resultado novo = new Resultado();

                            novo.concurso = int.Parse(row.SelectNodes("th|td")[0].InnerText);
                            novo.idLoteria = (int)JogosEnum.lotofacil;
                            novo.dataSorteio = DateTime.Parse(row.SelectNodes("th|td")[1].InnerText);
                            novo.bola01 = int.Parse(row.SelectNodes("th|td")[2].InnerText);
                            novo.bola02 = int.Parse(row.SelectNodes("th|td")[3].InnerText);
                            novo.bola03 = int.Parse(row.SelectNodes("th|td")[4].InnerText);
                            novo.bola04 = int.Parse(row.SelectNodes("th|td")[5].InnerText);
                            novo.bola05 = int.Parse(row.SelectNodes("th|td")[6].InnerText);
                            novo.bola06 = int.Parse(row.SelectNodes("th|td")[7].InnerText);
                            novo.bola07 = int.Parse(row.SelectNodes("th|td")[8].InnerText);
                            novo.bola08 = int.Parse(row.SelectNodes("th|td")[9].InnerText);
                            novo.bola09 = int.Parse(row.SelectNodes("th|td")[10].InnerText);
                            novo.bola10 = int.Parse(row.SelectNodes("th|td")[11].InnerText);
                            novo.bola11 = int.Parse(row.SelectNodes("th|td")[12].InnerText);
                            novo.bola12 = int.Parse(row.SelectNodes("th|td")[13].InnerText);
                            novo.bola13 = int.Parse(row.SelectNodes("th|td")[14].InnerText);
                            novo.bola14 = int.Parse(row.SelectNodes("th|td")[15].InnerText);
                            novo.bola15 = int.Parse(row.SelectNodes("th|td")[16].InnerText);
                            novo.arrecadacaoTotal = decimal.Parse(row.SelectNodes("th|td")[17].InnerText);
                            novo.ganhadores15 = int.Parse(row.SelectNodes("th|td")[18].InnerText);
                            novo.ganhadores14 = int.Parse(row.SelectNodes("th|td")[21].InnerText);
                            novo.ganhadores13 = int.Parse(row.SelectNodes("th|td")[22].InnerText);
                            novo.ganhadores12 = int.Parse(row.SelectNodes("th|td")[23].InnerText);
                            novo.ganhadores11 = int.Parse(row.SelectNodes("th|td")[24].InnerText);
                            novo.valorRateio15 = decimal.Parse(row.SelectNodes("th|td")[25].InnerText);
                            novo.valorRateio14 = decimal.Parse(row.SelectNodes("th|td")[26].InnerText);
                            novo.valorRateio13 = decimal.Parse(row.SelectNodes("th|td")[27].InnerText);
                            novo.valorRateio12 = decimal.Parse(row.SelectNodes("th|td")[28].InnerText);
                            novo.valorRateio11 = decimal.Parse(row.SelectNodes("th|td")[29].InnerText);
                            novo.valorAcumulado = decimal.Parse(row.SelectNodes("th|td")[30].InnerText);
                            novo.estimativaPremio = decimal.Parse(row.SelectNodes("th|td")[31].InnerText);
                            novo.acumuladoEspecial = decimal.Parse(row.SelectNodes("th|td")[32].InnerText);

                            gravarRegistro(novo);
                        }
                        //else
                        //{
                        //    throw new Exception("Quantidade de colunas diferente do esperado.");
                        //}
                    }
                    i++;
                }
            }
        }
    }
}
