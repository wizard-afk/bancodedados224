-- Inserir Modalidades
INSERT INTO Modalidade (nome, tipo) VALUES 
('Futebol', 'Equipe'),
('Tênis', 'Individual'),
('Vôlei', 'Equipe'),
('Xadrez', 'Individual');

-- Inserir Equipes
INSERT INTO Equipe (nome, cidade, modalidade_id) VALUES
('Time A', 'Cidade A', 1),
('Time B', 'Cidade B', 1),
('Time C', 'Cidade C', 3);

-- Inserir Atletas
INSERT INTO Atleta (nome, data_nascimento, modalidade_id) VALUES
('João Silva', '1990-05-12', 2),
('Maria Santos', '1995-08-20', 4);

-- Inserir Torneios
INSERT INTO Torneio (nome, modalidade_id, tipo_torneio) VALUES
('Copa Regional de Futebol', 1, 'Eliminatório'),
('Torneio de Xadrez', 4, 'Pontos Corridos');

-- Inserir Partidas
INSERT INTO Partida (torneio_id, data, local, fase, equipe1_id, equipe2_id, placar_equipe1, placar_equipe2) VALUES
(1, '2024-01-15', 'Estádio Municipal', 'Classificatória', 1, 2, 3, 1);
