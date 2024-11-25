CREATE DATABASE OrganizadorJogos;
USE OrganizadorJogos;

CREATE TABLE campeonato (
    id_campeonato INT IDENTITY(1,1) PRIMARY KEY,
    nome_campeonato NVARCHAR(255) NOT NULL,
    data_inicio DATE NULL, 
    data_fim DATE NULL,   
    status_campeonato NVARCHAR(20) CHECK (status_campeonato IN ('nao_iniciado', 'em_andamento', 'finalizado')) DEFAULT 'nao_iniciado',
    descricao NVARCHAR(MAX) NULL -- Opcional: para descrever o campeonato
);

CREATE TABLE modalidade (
    id_modalidade INT IDENTITY(1,1) PRIMARY KEY,
    id_campeonato INT NOT NULL, -- Relacionamento com o campeonato
    nome_modalidade NVARCHAR(100) NOT NULL,
    tipo_modalidade NVARCHAR(20) CHECK (tipo_modalidade IN ('individual', 'equipe')) NOT NULL,
    qtd_minima_atletas INT NULL, -- Só será usado para modalidades em equipe
    qtd_maxima_atletas INT NULL,
    CONSTRAINT FK_modalidade_campeonato FOREIGN KEY (id_campeonato) REFERENCES campeonato(id_campeonato)
);

CREATE TABLE atleta (
    id_atleta INT IDENTITY(1,1) PRIMARY KEY,
    id_campeonato INT NOT NULL, 
    nome_atleta NVARCHAR(100) NOT NULL,
    data_nascimento DATE NOT NULL,
    id_modalidade INT NOT NULL, -- Cada atleta pertence a uma modalidade
    CONSTRAINT FK_atleta_campeonato FOREIGN KEY (id_campeonato) REFERENCES campeonato(id_campeonato),
    CONSTRAINT FK_atleta_modalidade FOREIGN KEY (id_modalidade) REFERENCES modalidade(id_modalidade),
    CONSTRAINT UQ_atleta_modalidade UNIQUE (id_atleta, id_modalidade) -- Um atleta só pode participar de uma modalidade
);

CREATE TABLE equipe (
    id_equipe INT IDENTITY(1,1) PRIMARY KEY,
    id_campeonato INT NOT NULL,
    id_modalidade INT NOT NULL,
    nome_equipe NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_equipe_campeonato FOREIGN KEY (id_campeonato) REFERENCES campeonato(id_campeonato),
    CONSTRAINT FK_equipe_modalidade FOREIGN KEY (id_modalidade) REFERENCES modalidade(id_modalidade)
);

CREATE TABLE equipe_atleta (
    id_equipe INT NOT NULL,
    id_atleta INT NOT NULL,
    PRIMARY KEY (id_equipe, id_atleta), -- Garante que o mesmo atleta não possa estar na mesma equipe mais de uma vez
    CONSTRAINT FK_equipe_atleta_equipe FOREIGN KEY (id_equipe) REFERENCES equipe(id_equipe),
    CONSTRAINT FK_equipe_atleta_atleta FOREIGN KEY (id_atleta) REFERENCES atleta(id_atleta)
);

-- competição por modalidade
CREATE TABLE competicao (
    id_competicao INT IDENTITY(1,1) PRIMARY KEY,
    id_modalidade INT NOT NULL,
    status_competicao NVARCHAR(20) CHECK (status_competicao IN ('pendente', 'em_andamento', 'finalizado')) DEFAULT 'pendente',
    CONSTRAINT FK_competicao_modalidade FOREIGN KEY (id_modalidade) REFERENCES modalidade(id_modalidade)
);

-- Tabela de Partidas Individuais
CREATE TABLE partida_individual (
    id_partida_individual INT IDENTITY(1,1) PRIMARY KEY,
    id_competicao INT NOT NULL,
    id_atleta1 INT NOT NULL,
    id_atleta2 INT NULL, -- possibilita bye
    resultado_partida NVARCHAR(20) CHECK (resultado_partida IN ('atleta1', 'atleta2', 'empate', 'bye')) DEFAULT NULL,
    CONSTRAINT FK_partida_individual_competicao FOREIGN KEY (id_competicao) REFERENCES competicao(id_competicao),
    CONSTRAINT FK_partida_individual_atleta1 FOREIGN KEY (id_atleta1) REFERENCES atleta(id_atleta),
    CONSTRAINT FK_partida_individual_atleta2 FOREIGN KEY (id_atleta2) REFERENCES atleta(id_atleta)
);

CREATE TABLE pontuacao_individual (
    id_pontuacao INT IDENTITY(1,1) PRIMARY KEY,
    id_competicao INT NOT NULL,
    id_atleta INT NOT NULL,
    pontos FLOAT DEFAULT 0,
    byes INT DEFAULT 0,
    CONSTRAINT FK_pontuacao_individual_competicao FOREIGN KEY (id_competicao) REFERENCES competicao(id_competicao),
    CONSTRAINT FK_pontuacao_individual_atleta FOREIGN KEY (id_atleta) REFERENCES atleta(id_atleta),
    CONSTRAINT UQ_pontuacao_competicao_atleta UNIQUE (id_competicao, id_atleta) -- Apenas uma pontuação por competição por atleta
);
ALTER TABLE pontuacao_individual
DROP COLUMN byes; 
ALTER TABLE pontuacao_individual
ADD byes BIT DEFAULT 0;
ALTER TABLE pontuacao_individual
ALTER COLUMN pontos INT;

CREATE TABLE partida_equipe (
    id_partida_equipe INT IDENTITY(1,1) PRIMARY KEY,
    id_competicao INT NOT NULL,
    id_equipe1 INT NOT NULL,
    id_equipe2 INT NULL,
    resultado NVARCHAR(10) CHECK (resultado IN ('equipe1', 'equipe2')) NULL,
    CONSTRAINT FK_partida_equipe_competicao FOREIGN KEY (id_competicao) REFERENCES competicao(id_competicao),
    CONSTRAINT FK_partida_equipe_equipe1 FOREIGN KEY (id_equipe1) REFERENCES equipe(id_equipe),
    CONSTRAINT FK_partida_equipe_equipe2 FOREIGN KEY (id_equipe2) REFERENCES equipe(id_equipe)
);


CREATE TABLE fase_equipe (
    id_fase_equipe INT IDENTITY(1,1) PRIMARY KEY,
    id_equipe INT NOT NULL, -- Relaciona com a equipe
    fase_partida NVARCHAR(20) CHECK (fase_partida IN ('classificatorias', 'oitavas', 'quartas', 'semi', 'final')) NOT NULL,
    id_competicao INT NOT NULL, -- Relaciona com a competição
    CONSTRAINT FK_fase_equipe_equipe FOREIGN KEY (id_equipe) REFERENCES equipe(id_equipe),
    CONSTRAINT FK_fase_equipe_competicao FOREIGN KEY (id_competicao) REFERENCES competicao(id_competicao)
);


-- querys

select * from partida_individual;
DELETE FROM equipe_atleta;

-- resetar id
DBCC CHECKIDENT ('atleta', RESEED, 0);

ALTER TABLE partida_equipe
DROP CONSTRAINT CK__partida_e__fase___5535A963;


