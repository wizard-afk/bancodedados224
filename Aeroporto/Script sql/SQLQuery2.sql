CREATE DATABASE AEROPORTO;
GO

USE AEROPORTO;
GO

CREATE TABLE Aeronaves (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tipo NVARCHAR(50) NOT NULL,
    numero_poltronas INT NOT NULL
);
GO

CREATE TABLE Aeroportos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome NVARCHAR(100) NOT NULL,
    localizacao NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Pessoas (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    telefone NVARCHAR(20)
);
GO

CREATE TABLE Clientes (
    pessoa_id INT PRIMARY KEY,
    preferencial BIT DEFAULT 0,
    CONSTRAINT fk_cliente_pessoa FOREIGN KEY (pessoa_id) REFERENCES Pessoas(id)
);
GO

CREATE TABLE Pilotos (
    pessoa_id INT PRIMARY KEY,
    numero_licenca NVARCHAR(50) NOT NULL,
    CONSTRAINT fk_piloto_pessoa FOREIGN KEY (pessoa_id) REFERENCES Pessoas(id)
);
GO

CREATE TABLE Voos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    aeronave_id INT,
    aeroporto_origem INT,
    aeroporto_destino INT,
    horario_saida DATETIME NOT NULL,
    horario_previsto_chegada DATETIME NOT NULL,
    piloto_id INT,
    CONSTRAINT fk_voo_aeronave FOREIGN KEY (aeronave_id) REFERENCES Aeronaves(id),
    CONSTRAINT fk_voo_aeroporto_origem FOREIGN KEY (aeroporto_origem) REFERENCES Aeroportos(id),
    CONSTRAINT fk_voo_aeroporto_destino FOREIGN KEY (aeroporto_destino) REFERENCES Aeroportos(id),
    CONSTRAINT fk_voo_piloto FOREIGN KEY (piloto_id) REFERENCES Pilotos(pessoa_id)
);
GO

CREATE TABLE Escalas (
    id INT IDENTITY(1,1) PRIMARY KEY,
    voo_id INT,
    aeroporto_id INT,
    horario_saida DATETIME NOT NULL,
    horario_chegada DATETIME NOT NULL,
    CONSTRAINT fk_escala_voo FOREIGN KEY (voo_id) REFERENCES Voos(id),
    CONSTRAINT fk_escala_aeroporto FOREIGN KEY (aeroporto_id) REFERENCES Aeroportos(id)
);
GO

CREATE TABLE Poltronas (
    id INT IDENTITY(1,1) PRIMARY KEY,
    aeronave_id INT,
    numero NVARCHAR(10) NOT NULL,
    localizacao NVARCHAR(20) NOT NULL,
    disponivel BIT DEFAULT 1,
    UNIQUE (aeronave_id, numero),
    CONSTRAINT fk_poltrona_aeronave FOREIGN KEY (aeronave_id) REFERENCES Aeronaves(id)
);
GO

CREATE TABLE Reservas (
    id INT IDENTITY(1,1) PRIMARY KEY,
    cliente_id INT,
    voo_id INT,
    poltrona_id INT,
    data_reserva DATETIME DEFAULT GETDATE(),
    CONSTRAINT fk_reserva_cliente FOREIGN KEY (cliente_id) REFERENCES Clientes(pessoa_id),
    CONSTRAINT fk_reserva_voo FOREIGN KEY (voo_id) REFERENCES Voos(id),
    CONSTRAINT fk_reserva_poltrona FOREIGN KEY (poltrona_id) REFERENCES Poltronas(id)
);
GO

CREATE TABLE Horarios (
    id INT IDENTITY(1,1) PRIMARY KEY,
    voo_id INT,
    horario_saida DATETIME NOT NULL,
    horario_chegada DATETIME NOT NULL,
    CONSTRAINT fk_horario_voo FOREIGN KEY (voo_id) REFERENCES Voos(id)
);
GO