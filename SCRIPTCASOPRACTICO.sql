-- Script del caso practico #1 grupal
-- Resuelto por
USE u484426513_pa125;

CREATE TABLE G3Usuario (
Id INT AUTO_INCREMENT PRIMARY KEY,
Nombre_Usuario VARCHAR(50),
Contraseña VARCHAR(50)
);

CREATE TABLE G3Videojuego (
Id INT AUTO_INCREMENT PRIMARY KEY,
Nombre_Videojuego VARCHAR(50),
Categoria VARCHAR(50),
Calificacion_Pegi VARCHAR(20)
);

CREATE TABLE G3Historial (
Id INT AUTO_INCREMENT PRIMARY KEY,
Cantidad_Puntos INT,
Duracion_Partida DATETIME,
Id_Usuario INT,
Id_Videojuego INT,
FOREIGN KEY (Id_Usuario) REFERENCES G3Usuario(Id),
FOREIGN KEY (Id_Videojuego) REFERENCES G3Videojuego(Id)
);





