using PitacoCrawler;

namespace PitacoCrawler.repositorios
{
    public class BaseRepositorio
    {
        private Contexto contexto = null;

        public BaseRepositorio()
        {
            contexto = new Contexto();
        }

        protected Contexto bancoDados
        {
            get
            {
                return contexto;
            }
        }

    }
}
