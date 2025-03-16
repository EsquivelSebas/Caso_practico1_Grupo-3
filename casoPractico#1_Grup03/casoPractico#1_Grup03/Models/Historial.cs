<<<<<<< HEAD
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


=======
﻿namespace casoPractico_1_Grup03.Models
{
    public class Historial
    {
        public int ID { get; set; }
        public int cantidad_puntos { get; set; }
        public DateTime duracion_partida { get; set; }
        public int id_usuario { get; set; }
        public int id_videojuego { get; set; }
>>>>>>> 160fc3dfb9e7b559a845deabc4cf0ca0747c645e
    }
}
