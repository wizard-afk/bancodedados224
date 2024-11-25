CREATE DATABASE OrganizadorCampeonato;
USE OrganizadorCampeonato;

CREATE TABLE campeonato (
    id_campeonato INT AUTO_INCREMENT PRIMARY KEY,
    nome_campeonato VARCHAR(255) NOT NULL,
    data_inicio DATE DEFAULT NULL, -- Data de início do campeonato
    data_fim DATE DEFAULT NULL,   -- Data de finalização (se aplicável)
    status_campeonato ENUM('nao_iniciado', 'em_andamento', 'finalizado') DEFAULT 'nao_iniciado', -- Status atual
    descricao TEXT DEFAULT NULL -- Opcional: para descrever o campeonato
);

CREATE TABLE modalidade (
    id_modalidade INT AUTO_INCREMENT PRIMARY KEY,
    id_campeonato INT NOT NULL, -- Relacionamento com o campeonato
    nome_modalidade VARCHAR(100) NOT NULL,
    tipo_modalidade ENUM('individual', 'equipe') NOT NULL,
    qtd_minima_atletas INT DEFAULT NULL, -- Só será usado para modalidades em equipe
    qtd_maxima_atletas INT DEFAULT NULL,
    FOREIGN KEY (id_campeonato) REFERENCES campeonato(id_campeonato)
);

CREATE TABLE atleta (
    id_atleta INT AUTO_INCREMENT PRIMARY KEY,
    id_campeonato INT NOT NULL, -- Relacionamento com o campeonato
    nome_atleta VARCHAR(100) NOT NULL,
    data_nascimento DATE NOT NULL,
    id_modalidade INT NOT NULL, -- Cada atleta pertence a uma modalidade
    FOREIGN KEY (id_campeonato) REFERENCES campeonato(id_campeonato),
    FOREIGN KEY (id_modalidade) REFERENCES modalidade(id_modalidade),
    UNIQUE (id_atleta, id_modalidade) -- Um atleta só pode participar de uma modalidade
);

CREATE TABLE equipe (
    id_equipe INT AUTO_INCREMENT PRIMARY KEY,
    id_campeonato INT NOT NULL, -- Relacionamento com o campeonato
    id_modalidade INT NOT NULL, -- Relacionamento com a modalidade
    nome_equipe VARCHAR(100) NOT NULL,
    FOREIGN KEY (id_campeonato) REFERENCES campeonato(id_campeonato),
    FOREIGN KEY (id_modalidade) REFERENCES modalidade(id_modalidade)
);

CREATE TABLE equipe_atleta (
    id_equipe INT NOT NULL,
    id_atleta INT NOT NULL,
    PRIMARY KEY (id_equipe, id_atleta), -- Garante que o mesmo atleta não possa estar na mesma equipe mais de uma vez
    FOREIGN KEY (id_equipe) REFERENCES equipe(id_equipe),
    FOREIGN KEY (id_atleta) REFERENCES atleta(id_atleta)
);

-- competição por modalidade
CREATE TABLE competicao (
    id_competicao INT AUTO_INCREMENT PRIMARY KEY,
    id_modalidade INT NOT NULL,
    status_competicao ENUM('pendente', 'em_andamento', 'finalizado') DEFAULT 'pendente',
    FOREIGN KEY (id_modalidade) REFERENCES modalidade(id_modalidade)
);

-- Tabela de Partidas Individuais
CREATE TABLE partida_individual (
    id_partida_individual INT AUTO_INCREMENT PRIMARY KEY,
    id_competicao INT NOT NULL,
    id_atleta1 INT NOT NULL,
    id_atleta2 INT NULL, -- possibilita bye
    resultado_partida ENUM('atleta1', 'atleta2', 'empate', 'bye') DEFAULT NULL,
    FOREIGN KEY (id_competicao) REFERENCES competicao(id_competicao),
    FOREIGN KEY (id_atleta1) REFERENCES atleta(id_atleta),
    FOREIGN KEY (id_atleta2) REFERENCES atleta(id_atleta)
);

CREATE TABLE pontuacao_individual (
    id_pontuacao INT AUTO_INCREMENT PRIMARY KEY,
    id_competicao INT NOT NULL,
    id_atleta INT NOT NULL,
    pontos FLOAT DEFAULT 0,
    byes INT DEFAULT 0,
    FOREIGN KEY (id_competicao) REFERENCES competicao(id_competicao),
    FOREIGN KEY (id_atleta) REFERENCES atleta(id_atleta),
    UNIQUE (id_competicao, id_atleta) -- Apenas uma pontuação por competição por atleta
);

CREATE TABLE partida_equipe (
    id_partida_equipe INT AUTO_INCREMENT PRIMARY KEY,
    id_competicao INT NOT NULL,
    id_equipe1 INT NOT NULL,
    id_equipe2 INT NULL,
    fase_partida ENUM('classificatorias', 'oitavas', 'quartas', 'semi', 'final') NOT NULL,
    resultado_partida ENUM('equipe1', 'equipe2', 'empate', 'bye') DEFAULT NULL,
    FOREIGN KEY (id_competicao) REFERENCES competicao(id_competicao),
    FOREIGN KEY (id_equipe1) REFERENCES equipe(id_equipe),
    FOREIGN KEY (id_equipe2) REFERENCES equipe(id_equipe)
);

CREATE TABLE fase_equipe (
    id_fase INT AUTO_INCREMENT PRIMARY KEY,
    id_competicao INT NOT NULL,
    fase ENUM('classificatorias', 'oitavas', 'quartas', 'semi', 'final') NOT NULL,
    FOREIGN KEY (id_competicao) REFERENCES competicao(id_competicao)
);



