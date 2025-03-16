using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace casoPractico_1_Grup03.Models
{
    public class Videojuego
    {
        [Key]
        public int Id { get; set; }
        public string Nombre_Videojuego { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Calificacion_Pegi { get; set; } = string.Empty;



    }
}
