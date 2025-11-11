using FinalScore_Core.IRepositories;
using FinalScore_Data.Context;
using FinalScore_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalScore_Core.Repositories {
    
    internal class EquipoRepository : Repository<EquipoModel>, IEquipoRepository {
        private readonly ApplicationDbContext _db;

        public EquipoRepository(ApplicationDbContext db) : base(db)  {
            _db = db; 
        }

        public void Update(EquipoModel equipo) {
            EquipoModel equipoDb = GetById(equipo.Id);
            _db.Entry(equipoDb).CurrentValues.SetValues(equipo);
            _db.SaveChanges();
        }

        public IEnumerable<object> GetAllEquipos() {
            var equipos = GetAll(includeProps:"Liga")
                .Select( e => new {
                    e.Nombre,
                    e.Parque,
                    e.Ciudad,
                    liga = new {
                        e.Liga.Nombre,
                        e.Liga.Pais
                    }
                });
            return equipos;
        }

        
    }


}
