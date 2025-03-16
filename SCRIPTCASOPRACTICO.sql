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


-- Various Inserts 
INSERT INTO G3Usuario (Nombre_Usuario, Contraseña) VALUES ('JuanPerez', 'contraseña123');
INSERT INTO G3Usuario (Nombre_Usuario, Contraseña) VALUES ('MariaGomez', 'maria456');
INSERT INTO G3Usuario (Nombre_Usuario, Contraseña) VALUES ('CarlosLopez', 'carlos789');
INSERT INTO G3Usuario (Nombre_Usuario, Contraseña) VALUES ('AnaMartinez', 'ana1011');
INSERT INTO G3Usuario (Nombre_Usuario, Contraseña) VALUES ('LuisFernandez', 'luis1213');


INSERT INTO G3Videojuego (Nombre_Videojuego, Categoria, Calificacion_Pegi) VALUES ('The Witcher 3', 'RPG', '18+');
INSERT INTO G3Videojuego (Nombre_Videojuego, Categoria, Calificacion_Pegi) VALUES ('FIFA 23', 'Deportes', '3+');
INSERT INTO G3Videojuego (Nombre_Videojuego, Categoria, Calificacion_Pegi) VALUES ('Call of Duty: Modern Warfare', 'Shooter', '18+');
INSERT INTO G3Videojuego (Nombre_Videojuego, Categoria, Calificacion_Pegi) VALUES ('Minecraft', 'Sandbox', '7+');
INSERT INTO G3Videojuego (Nombre_Videojuego, Categoria, Calificacion_Pegi) VALUES ('Super Mario Odyssey', 'Plataformas', '3+');

INSERT INTO G3Historial (Cantidad_Puntos, Duracion_Partida, Id_Usuario, Id_Videojuego) VALUES (1500, '2023-10-01 14:30:00', 1, 1);
INSERT INTO G3Historial (Cantidad_Puntos, Duracion_Partida, Id_Usuario, Id_Videojuego) VALUES (2000, '2023-10-02 16:45:00', 2, 2);
INSERT INTO G3Historial (Cantidad_Puntos, Duracion_Partida, Id_Usuario, Id_Videojuego) VALUES (3000, '2023-10-03 18:15:00', 3, 3);
INSERT INTO G3Historial (Cantidad_Puntos, Duracion_Partida, Id_Usuario, Id_Videojuego) VALUES (2500, '2023-10-04 20:00:00', 4, 4);
INSERT INTO G3Historial (Cantidad_Puntos, Duracion_Partida, Id_Usuario, Id_Videojuego) VALUES (1000, '2023-10-05 22:30:00', 5, 5);



-- Various Selects

select * from G3Historial;
