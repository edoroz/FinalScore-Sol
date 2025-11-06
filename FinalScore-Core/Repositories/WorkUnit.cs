
using FinalScore_Core.IRepositories;
using FinalScore_Data.Context;


namespace FinalScore_Core.Repositories {
    public class WorkUnit : IWorkUnit {
        private readonly ApplicationDbContext _db;
        

        public WorkUnit(ApplicationDbContext db) { 
            _db = db; 
            Liga = new LigaRepository(_db);
            Equipo = new EquipoRepository(_db);
        }

        public ILigaRepository Liga { get; private set; }

        public IEquipoRepository Equipo { get; private set; }

        public void Save() {
            _db.SaveChanges();
        }

        public void Dispose() {
            _db.Dispose();
        }
    }
}
