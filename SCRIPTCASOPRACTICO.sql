-- Script for practical case #1 (group work)
-- Solved by Group #3
USE u484426513_pa125;

-- Users Table
CREATE TABLE G3Usuario (
    Id INT AUTO_INCREMENT PRIMARY KEY UNIQUE,
    Nombre_Usuario VARCHAR(50),
    Contraseña VARCHAR(50),
    Imagen VARCHAR(255) 
);

-- Video Games Table
CREATE TABLE G3Videojuego (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre_Videojuego VARCHAR(50),
    Categoria VARCHAR(50),
    Calificacion_Pegi VARCHAR(20)
);

-- History Table
CREATE TABLE G3Historial (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Cantidad_Puntos INT,
    Duracion_Partida DATETIME,
    Id_Usuario INT,
    Id_Videojuego INT,
    FOREIGN KEY (Id_Usuario) REFERENCES G3Usuario(Id),
    FOREIGN KEY (Id_Videojuego) REFERENCES G3Videojuego(Id)
);

-- Inserts for the G3Usuario table
INSERT INTO G3Usuario (Nombre_Usuario, Contraseña, Imagen) VALUES ('JuanPerez', 'contraseña123', 'juan_perez.jpg');
INSERT INTO G3Usuario (Nombre_Usuario, Contraseña, Imagen) VALUES ('MariaGomez', 'maria456', 'maria_gomez.jpg');
INSERT INTO G3Usuario (Nombre_Usuario, Contraseña, Imagen) VALUES ('CarlosLopez', 'carlos789', 'carlos_lopez.jpg');
INSERT INTO G3Usuario (Nombre_Usuario, Contraseña, Imagen) VALUES ('AnaMartinez', 'ana1011', 'ana_martinez.jpg');
INSERT INTO G3Usuario (Nombre_Usuario, Contraseña, Imagen) VALUES ('LuisFernandez', 'luis1213', 'luis_fernandez.jpg');

-- Inserts for the G3Videojuego table
INSERT INTO G3Videojuego (Nombre_Videojuego, Categoria, Calificacion_Pegi) VALUES ('The Witcher 3', 'RPG', '18+');
INSERT INTO G3Videojuego (Nombre_Videojuego, Categoria, Calificacion_Pegi) VALUES ('FIFA 23', 'Deportes', '3+');
INSERT INTO G3Videojuego (Nombre_Videojuego, Categoria, Calificacion_Pegi) VALUES ('Call of Duty: Modern Warfare', 'Shooter', '18+');
INSERT INTO G3Videojuego (Nombre_Videojuego, Categoria, Calificacion_Pegi) VALUES ('Minecraft', 'Sandbox', '7+');
INSERT INTO G3Videojuego (Nombre_Videojuego, Categoria, Calificacion_Pegi) VALUES ('Super Mario Odyssey', 'Plataformas', '3+');

-- Inserts for the G3Historial table
INSERT INTO G3Historial (Cantidad_Puntos, Duracion_Partida, Id_Usuario, Id_Videojuego) VALUES (1500, '2023-10-01 14:30:00', 1, 1);
INSERT INTO G3Historial (Cantidad_Puntos, Duracion_Partida, Id_Usuario, Id_Videojuego) VALUES (2000, '2023-10-02 16:45:00', 2, 2);
INSERT INTO G3Historial (Cantidad_Puntos, Duracion_Partida, Id_Usuario, Id_Videojuego) VALUES (3000, '2023-10-03 18:15:00', 3, 3);
INSERT INTO G3Historial (Cantidad_Puntos, Duracion_Partida, Id_Usuario, Id_Videojuego) VALUES (2500, '2023-10-04 20:00:00', 4, 4);
INSERT INTO G3Historial (Cantidad_Puntos, Duracion_Partida, Id_Usuario, Id_Videojuego) VALUES (1000, '2023-10-05 22:30:00', 5, 5);

-- Updated Selects
-- Select all users with their images
SELECT * FROM G3Videojuego;
SELECT * FROM G3Usuario;
SELECT * FROM G3Historial;

-- Drops to update in case of needed
DROP TABLE G3Historial;
DROP TABLE G3Usuario;
DROP TABLE G3Videojuego;