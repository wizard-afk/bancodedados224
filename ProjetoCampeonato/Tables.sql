CREATE DATABASE ProjetoCampeonato;
USE ProjetoCampeonato;
-- Tabela de Equipes
CREATE TABLE Equipe (
    ID_Equipe INT PRIMARY KEY AUTO_INCREMENT,
    Nome_Equipe VARCHAR(255) NOT NULL
);

-- Tabela de Atletas
CREATE TABLE Atleta (
    ID_Atleta INT PRIMARY KEY AUTO_INCREMENT,
    Nome_Atleta VARCHAR(255) NOT NULL,
    ID_Equipe INT,  -- Se o atleta fizer parte de uma equipe
    FOREIGN KEY (ID_Equipe) REFERENCES Equipe(ID_Equipe)
);

-- Tabela de Modalidades (pode ser por equipe ou individual)
CREATE TABLE Modalidade (
    ID_Modalidade INT PRIMARY KEY AUTO_INCREMENT,
    Nome_Modalidade VARCHAR(255) NOT NULL,
    Tipo ENUM('Equipe', 'Individual') NOT NULL  -- Define se é competição por equipe ou individual
);

-- Tabela de Competições (diferentes modalidades de torneios)
CREATE TABLE Competicao (
    ID_Competicao INT PRIMARY KEY AUTO_INCREMENT,
    Nome_Competicao VARCHAR(255) NOT NULL,
    ID_Modalidade INT,
    FOREIGN KEY (ID_Modalidade) REFERENCES Modalidade(ID_Modalidade)
);

-- Tabela de Torneios (cada competição pode ter um ou mais torneios)
CREATE TABLE Torneio (
    ID_Torneio INT PRIMARY KEY AUTO_INCREMENT,
    Nome_Torneio VARCHAR(255) NOT NULL,
    Tipo_Torneio ENUM('Grupos', 'Pontos Corridos') NOT NULL,  -- Tipo de torneio
    ID_Competicao INT,
    FOREIGN KEY (ID_Competicao) REFERENCES Competicao(ID_Competicao)
);

-- Tabela de Grupos (usado se o torneio for por grupos)
CREATE TABLE Grupo (
    ID_Grupo INT PRIMARY KEY AUTO_INCREMENT,
    Nome_Grupo VARCHAR(255),
    ID_Torneio INT,
    FOREIGN KEY (ID_Torneio) REFERENCES Torneio(ID_Torneio)
);

-- Tabela de Partidas
CREATE TABLE Partida (
    ID_Partida INT PRIMARY KEY AUTO_INCREMENT,
    Data_Partida DATE NOT NULL,
    ID_Torneio INT,
    ID_Grupo INT NULL,  -- Só será utilizado se for torneio em grupos
    ID_Equipe1 INT,  -- Equipe 1 (ou Atleta 1, se for individual)
    ID_Equipe2 INT,  -- Equipe 2 (ou Atleta 2, se for individual)
    FOREIGN KEY (ID_Torneio) REFERENCES Torneio(ID_Torneio),
    FOREIGN KEY (ID_Grupo) REFERENCES Grupo(ID_Grupo),
    FOREIGN KEY (ID_Equipe1) REFERENCES Equipe(ID_Equipe),
    FOREIGN KEY (ID_Equipe2) REFERENCES Equipe(ID_Equipe)
);

-- Tabela de Resultados (armazena o resultado de cada partida)
CREATE TABLE Resultado (
    ID_Resultado INT PRIMARY KEY AUTO_INCREMENT,
    ID_Partida INT,
    Pontos_Equipe1 INT,
    Pontos_Equipe2 INT,
    Vencedor INT NULL,  -- ID da equipe vencedora ou NULL em caso de empate
    FOREIGN KEY (ID_Partida) REFERENCES Partida(ID_Partida),
    FOREIGN KEY (Vencedor) REFERENCES Equipe(ID_Equipe)
);

-- Tabela de Classificação (armazena as classificações das equipes ou atletas)
CREATE TABLE Classificacao (
    ID_Classificacao INT PRIMARY KEY AUTO_INCREMENT,
    ID_Torneio INT,
    ID_Equipe INT,  -- Referência para equipe ou atleta (individual ou em grupo)
    Pontos_Total INT DEFAULT 0,
    Vitorias INT DEFAULT 0,
    Empates INT DEFAULT 0,
    Derrotas INT DEFAULT 0,
    Jogos_Disputados INT DEFAULT 0,
    FOREIGN KEY (ID_Torneio) REFERENCES Torneio(ID_Torneio),
    FOREIGN KEY (ID_Equipe) REFERENCES Equipe(ID_Equipe)
);

-- Tabela de Participações (registra a participação de equipes e atletas nas competições)
CREATE TABLE Participacao (
    ID_Participacao INT PRIMARY KEY AUTO_INCREMENT,
    ID_Equipe INT NULL,  -- Equipe ou Atleta
    ID_Atleta INT NULL,
    ID_Torneio INT,
    FOREIGN KEY (ID_Equipe) REFERENCES Equipe(ID_Equipe),
    FOREIGN KEY (ID_Atleta) REFERENCES Atleta(ID_Atleta),
    FOREIGN KEY (ID_Torneio) REFERENCES Torneio(ID_Torneio)
);

