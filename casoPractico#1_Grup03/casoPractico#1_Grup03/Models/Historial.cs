namespace casoPractico_1_Grup03.Models
{
    public class Historial
    {
        public int ID { get; set; }
        public int cantidad_puntos { get; set; }
        public DateTime duracion_partida { get; set; }
        public int id_usuario { get; set; }
        public int id_videojuego { get; set; }
    }
}
