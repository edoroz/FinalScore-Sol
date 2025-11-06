

using FinalScore_Core.IRepositories;
using FinalScore_Data.Context;
using FinalScore_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalScore_Core.Repositories {
    internal class LigaRepository : Repository<LigaModel>, ILigaRepository {
        private readonly ApplicationDbContext _db;

        public LigaRepository(ApplicationDbContext db) : base(db) {
            _db = db; 
        }

        public void Update(LigaModel liga) {
            LigaModel ligaDb = GetById(liga.Id);
            _db.Entry(ligaDb).CurrentValues.SetValues(liga);
            _db.SaveChanges();
        }
    }
}
