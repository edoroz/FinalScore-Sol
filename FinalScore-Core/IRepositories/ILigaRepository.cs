

using FinalScore_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalScore_Core.IRepositories {
    public interface ILigaRepository : IRepository<LigaModel> {
        void Update(LigaModel liga);
    }
}
