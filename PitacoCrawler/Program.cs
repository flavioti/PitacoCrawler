using PitacoCrawler.Seekers;
using System.Threading.Tasks;

namespace PitacoCrawler
{
    class Program
    {
        static void Main(string[] args)
        {

            Task taskLotofacil = Task.Run(() =>
            {
                LoteriaBase lotoFacil = new Lotofacil();
                lotoFacil.executar();
            });

            Task taskMegasena = Task.Run(() =>
            {
                LoteriaBase megasena = new Megasena();
                megasena.executar();
            });

            taskLotofacil.Wait();
            taskMegasena.Wait();

        }
    }
}
