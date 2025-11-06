using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalScore_Core.IRepositories {
    public interface IWorkUnit : IDisposable {
        ILigaRepository     Liga    { get; }
        IEquipoRepository   Equipo  { get; }

        void Save();
    }
}
