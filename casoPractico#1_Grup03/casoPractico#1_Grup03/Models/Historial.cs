
﻿using System.ComponentModel.DataAnnotations;

namespace casoPractico_1_Grup03.Models
{
    public class Historial
    {
        //Attributes
        [Key]
        public int Id { get; set; }
        public int Cantidad_Puntos { get; set; }
        public DateTime Duracion_Partida { get; set; }
        public int Id_Usuario { get; set; } //foreign key

        public int Id_Videojuego { get; set; } //foreign key



    }
}
