DROP DATABASE IF EXISTS NetflixLibrosBD;
CREATE DATABASE NetflixLibroBD;
USE NetflixLibroBD;

CREATE TABLE Genero(
    idGenero TINYINT UNSIGNED,
    genero VARCHAR(45) NOT NULL,
    CONSTRAINT PK_Genero PRIMARY KEY (idGenero)
);


CREATE TABLE Autor(
    idAutor INT UNSIGNED,
    nombre VARCHAR(45) NOT NULL,
    bibliografia VARCHAR(500) NOT NULL,
    nacimiento DATE NOT NULL,
    fallecimiento DATE,
    CONSTRAINT PK_Genero PRIMARY KEY (idAutor),
    CONSTRAINT CHK_Autor CHECK (fallecimiento IS NULL OR fallecimiento > nacimiento)
);

CREATE TABLE Usuario(
    nombre VARCHAR(45) NOT NULL,
    apellido VARCHAR(45) NOT NULL,
    correoElectronico VARCHAR(64) NOT NULL,
    idUsuario INT UNSIGNED NOT NULL,
    CONSTRAINT Pk_Usuario PRIMARY KEY (idUsuario)
);

CREATE TABLE Libro(
    ISBN INT UNSIGNED,
    idAutor INT UNSIGNED,
    idGenero TINYINT UNSIGNED,
    titulo VARCHAR(45) NOT NULL,
    publicacion DATE NOT NULL,
    calificacion DECIMAL(10,2) NOT NULL DEFAULT 0,
        CONSTRAINT PK_Libro PRIMARY KEY (ISBN),
    CONSTRAINT FK_Libro_Autor FOREIGN KEY (idAutor)
        REFERENCES Autor (idAutor),
	CONSTRAINT FK_Libro_Genero FOREIGN KEY (idGenero)
        REFERENCES Genero (idGenero)
);





CREATE TABLE Calificacion(
    idCalificacion INT UNSIGNED,
    ISBN INT UNSIGNED,
    idUsuario INT UNSIGNED,
    calificacion TINYINT UNSIGNED,
    CONSTRAINT PK_Calificacion PRIMARY KEY (idCalificacion),
    CONSTRAINT FK_Calificacion_Libro FOREIGN KEY (ISBN)
        REFERENCES Libro (ISBN),
    CONSTRAINT FK_Calificacion_Usuario FOREIGN KEY (idUsuario)
        REFERENCES Usuario (idUsuario),
    CONSTRAINT CHK_Calificacion CHECK (calificacion BETWEEN 0 AND 10)
);
