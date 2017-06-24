using HtmlAgilityPack;
using PitacoCrawler.Models;
using PitacoCrawler.Repositorios;
using System;
using System.IO;

namespace PitacoCrawler.Seekers
{
    class Megasena : LoteriaBase
    {
        public Megasena()
        {
            base.url = "http://www1.caixa.gov.br/loterias/_arquivos/loterias/D_megase.zip";
            base.referal = "http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/";
            base.pastaDestino = @"E:/Loteria/megasena/";
            this.destino = Path.GetFileName(url);
            base.arquivoHtml = "D_MEGA.HTM";
        }

        public override void interpretarHtml()
        {
            base.interpretarHtml();

            HtmlDocument doc = new HtmlDocument();
            doc.Load(pastaDestino + arquivoHtml);

            ResultadoRepositorio resultadoRepositorio = new ResultadoRepositorio();

            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
            {
                int i = 1;
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    if (i > 1)
                    {
                        if (row.SelectNodes("th|td").Count == 21)
                        {
                            Console.WriteLine("Megasena");

                            Resultado novo = new Resultado();

                            novo.concurso = int.Parse(row.SelectNodes("th|td")[0].InnerText);
                            novo.idLoteria = (int)JogosEnum.megasena;
                            novo.dataSorteio = DateTime.Parse(row.SelectNodes("th|td")[1].InnerText);
                            novo.bola01 = int.Parse(row.SelectNodes("th|td")[2].InnerText);
                            novo.bola02 = int.Parse(row.SelectNodes("th|td")[3].InnerText);
                            novo.bola03 = int.Parse(row.SelectNodes("th|td")[4].InnerText);
                            novo.bola04 = int.Parse(row.SelectNodes("th|td")[5].InnerText);
                            novo.bola05 = int.Parse(row.SelectNodes("th|td")[6].InnerText);
                            novo.bola06 = int.Parse(row.SelectNodes("th|td")[7].InnerText);
                            novo.arrecadacaoTotal = decimal.Parse(row.SelectNodes("th|td")[8].InnerText);
                            novo.ganhadores06 = int.Parse(row.SelectNodes("th|td")[9].InnerText);
                            novo.valorRateio06 = decimal.Parse(row.SelectNodes("th|td")[12].InnerText);
                            novo.ganhadores05 = int.Parse(row.SelectNodes("th|td")[13].InnerText);
                            novo.valorRateio05 = decimal.Parse(row.SelectNodes("th|td")[14].InnerText);
                            novo.ganhadores04 = int.Parse(row.SelectNodes("th|td")[15].InnerText);
                            novo.valorRateio04 = decimal.Parse(row.SelectNodes("th|td")[16].InnerText);
                            novo.acumulou = row.SelectNodes("th|td")[17].InnerText.ToUpper() == "SIM";
                            novo.valorAcumulado = decimal.Parse(row.SelectNodes("th|td")[18].InnerText);
                            novo.estimativaPremio = decimal.Parse(row.SelectNodes("th|td")[19].InnerText);
                            novo.acumuladoEspecial = decimal.Parse(row.SelectNodes("th|td")[20].InnerText);

                            gravarRegistro(novo);
                        }
                    }
                    i++;
                }
            }
        }
    }
}
