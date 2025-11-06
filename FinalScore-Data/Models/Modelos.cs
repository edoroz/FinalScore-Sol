    
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalScore_Data.Models {

    public abstract class BaseEntity {
        public DateTime RegisterDate    { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdate      { get; set; } = DateTime.UtcNow;
        public string   RegisterUser    { get; set; } = "";
        public string   UserUpdate      { get; set; } = "";
        public bool     IsActive        { get; set; } = true;
    }

    public class LigaModel : BaseEntity {                                           
                                                                [Key]
        public int      Id      { get; set; }                   [Required] [StringLength(100)]
        public string   Nombre  { get; set; } = string.Empty;   [StringLength(50)]
        public string   Deporte { get; set; } = string.Empty;   [StringLength(50)]
        public string   Pais    { get; set; } = string.Empty;   [StringLength(30)]
        public string   Nivel   { get; set; } = string.Empty;

        public int?      Ciclo  { get; set; }
        public DateTime? FecIni { get; set; }
        public DateTime? FecFin { get; set; }                   [StringLength(250)]
        public string?   Desc   { get; set; }
        
        public ICollection<EquipoModel>? Equipos { get; set; }
    }

    public class EquipoModel : BaseEntity {                                           
                                                [Key]
        public int      Id      { get; set; }   [Required]  [StringLength(100)]
        public string   Nombre  { get; set; } = string.Empty;
        public string   Parque  { get; set; } = string.Empty;   
        public string   Dir     { get; set; } = string.Empty;   
        public string   Ciudad  { get; set; } = string.Empty;
        public string   Tel     { get; set; } = string.Empty;
        public DateTime Inicio  { get; set; } = DateTime.Now;
        public string   URLs    { get; set; } = string.Empty;

        public int      LigaId  { get; set; }   [ForeignKey("LigaId")]
        public LigaModel? Liga  { get; set; }

        public ICollection<JugadorModel>? Jugadores { get; set; }
    }

    public class JugadorModel : BaseEntity {                                               
                                                 [Key]
        public int      Id       { get; set; }   [Required]  [StringLength(100)]
        public string   Nombre   { get; set; } = string.Empty; 
        public string   Apodo    { get; set; } = string.Empty; 
        public DateTime FecNac   { get; set; } = DateTime.Now;   [StringLength(30)]
        public string   PaisNac  { get; set; } = string.Empty; 
        public string?  Posicion { get; set; }
        public int?     Numero   { get; set; }

        public int      EquipoId    { get; set; }   [ForeignKey("EquipoId")]
        public EquipoModel?Equipo   { get; set; }
    }

}
