using PitacoCrawler.Models;
using RestSharp;
using RestSharp.Extensions;
using System;
using System.IO;

namespace PitacoCrawler.Seekers
{
    public abstract class LoteriaBase
    {
        private Contexto contexto = null;
        private readonly object ZipFile;

        protected string pastaDestino { get; set; }
        protected string destino { get; set; }
        protected string arquivoHtml { get; set; }
        protected string url { get; set; }
        protected string referal { get; set; }

        public LoteriaBase()
        {
            contexto = new Contexto();
        }

        public Contexto bancoDados { get { return contexto; } }

        public virtual void interpretarHtml()
        {
            if (!File.Exists(pastaDestino + arquivoHtml))
            {
                throw new Exception(string.Format("{0}{1} {2}",
                    pastaDestino, arquivoHtml, "Não existe."));
            }
        }

        protected void gravarRegistro(Resultado novo)
        {
            var existente = bancoDados.Resultado.Find(novo.idLoteria, novo.concurso);

            if (existente == null)
            {
                bancoDados.Resultado.Add(novo);
                bancoDados.SaveChangesAsync();
            }
        }

        public bool executar()
        {
            if (!Directory.Exists(pastaDestino))
            {
                Directory.CreateDirectory(pastaDestino);
            }

            string[] arquivos = Directory.GetFiles(pastaDestino);

            if (arquivos.Length > 10)
            {
                throw new System.Exception("A pasta destino tem mais de 10 arquivos a serem apagados.");
            }

            foreach (string s in arquivos)
            {
                File.Delete(s);
            }

            if (baixarArquivo(url, referal))
            {
                if (descompactarArquivo())
                {
                    interpretarHtml();
                }
            }
            return true;
        }

        public bool baixarArquivo(string url, string referal)
        {
            bool resultado = false;

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

            request.AddHeader("Upgrade-Insecure-Requests", "1");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36");
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            request.AddHeader("Referer", referal);
            request.AddHeader("Accept-Encoding", "gzip, deflate, sdch");
            request.AddHeader("Accept-Language", "pt-BR,pt;q=0.8,en-US;q=0.6,en;q=0.4,es;q=0.2");

            try
            {
                client.DownloadData(request).SaveAs(pastaDestino + destino);
                resultado = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                resultado = false;
            }

            return resultado;
        }

        public bool descompactarArquivo()
        {
            bool resultado = false;
            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(
                    pastaDestino + destino, pastaDestino
                    );

                resultado = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                resultado = false;
            }

            return resultado;
        }
    }
}
