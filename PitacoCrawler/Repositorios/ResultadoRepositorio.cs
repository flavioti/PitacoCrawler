using PitacoCrawler.Models;
using PitacoCrawler.repositorios;

namespace PitacoCrawler.Repositorios
{
    public class ResultadoRepositorio : BaseRepositorio
    {
        public void gravar(Resultado novo)
        {
            var existente = bancoDados.Resultado.Find(novo.idLoteria, novo.concurso);

            if (existente == null)
            {
                bancoDados.Resultado.Add(novo);
                bancoDados.SaveChangesAsync();
            }
        }
    }
}
