
INSERT INTO modalidade (id_campeonato, nome_modalidade, tipo_modalidade, qtd_minima_atletas, qtd_maxima_atletas)
VALUES
(1, 'futsal', 'equipe', 5, 14),
(1, 'Volei', 'equipe', 6, 15),
(1, 'Xadrez', 'individual', NULL, NULL),
(1, 'Tenis de Mesa', 'individual', NULL, NULL);

INSERT INTO competicao(id_modalidade, status_competicao)
VALUES
(1, 'pendente'),
(2, 'pendente'),
(3, 'em_andamento'),
(4, 'pendente');

INSERT INTO partida_individual(id_competicao, id_atleta1, id_atleta2, resultado_partida)
VALUES
(3, '77', '78', NULL),
(3, '79', '80', NULL),
(3, '81', '82', NULL),
(3, '83', '84', NULL),
(3, '85', '86', NULL),
(3, '87', '88', NULL);

INSERT INTO pontuacao_individual(id_competicao, id_atleta, pontos, byes)
VALUES
(3, 77, null, 0),
(3, 78, null, 0),
(3, 79, null, 0),
(3, 80, null, 0),
(3, 81, null, 0),
(3, 82, null, 0),
(3, 83, null, 0),
(3, 84, null, 0),
(3, 85, null, 0),
(3, 86, null, 0),
(3, 87, null, 0),
(3, 88, null, 0);

UPDATE pontuacao_individual
SET pontos = '0'
WHERE pontos IS NULL;

INSERT INTO partida_equipe (id_competicao, id_equipe1, id_equipe2, fase_partida)
VALUES (1, 1, 2, 'classificatorias'), 
       (1, 3, 4, 'classificatorias'),
       (1, 5, 6, 'classificatorias'),
       (1, 7, 8, 'classificatorias');

select * from fase_equipe;

INSERT INTO fase_equipe(id_equipe, fase_partida,id_competicao)
VALUES (1, 'classificatorias', 1),
	   (2, 'classificatorias', 1),
	   (3, 'classificatorias', 1),
	   (4, 'classificatorias', 1),
	   (5, 'classificatorias', 1),
	   (6, 'classificatorias', 1),
	   (7, 'classificatorias', 1),
	   (8, 'classificatorias', 1);

-- Move a equipe para a próxima fase (oitavas)
UPDATE fase_equipe
SET fase_partida = 'oitavas'
WHERE id_equipe = 2;

-- Futsal
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta1_Futsal', '2000-01-01', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta2_Futsal', '2000-01-02', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta3_Futsal', '2000-01-03', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta4_Futsal', '2000-01-04', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta5_Futsal', '2000-01-05', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta6_Futsal', '2000-01-06', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta7_Futsal', '2000-01-07', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta8_Futsal', '2000-01-08', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta9_Futsal', '2000-01-09', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta10_Futsal', '2000-01-10', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta11_Futsal', '2000-01-11', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta12_Futsal', '2000-01-12', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta13_Futsal', '2000-01-13', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta14_Futsal', '2000-01-14', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta15_Futsal', '2000-01-15', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta16_Futsal', '2000-01-16', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta17_Futsal', '2000-01-17', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta18_Futsal', '2000-01-18', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta19_Futsal', '2000-01-19', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta20_Futsal', '2000-01-20', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta21_Futsal', '2000-01-21', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta22_Futsal', '2000-01-22', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta23_Futsal', '2000-01-23', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta24_Futsal', '2000-01-24', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta25_Futsal', '2000-01-25', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta26_Futsal', '2000-01-26', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta27_Futsal', '2000-01-27', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta28_Futsal', '2000-01-28', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta29_Futsal', '2000-01-29', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta30_Futsal', '2000-01-30', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta31_Futsal', '2000-01-31', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta32_Futsal', '2000-02-01', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta33_Futsal', '2000-02-02', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta34_Futsal', '2000-02-03', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta35_Futsal', '2000-02-04', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta36_Futsal', '2000-02-05', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta37_Futsal', '2000-02-06', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta38_Futsal', '2000-02-07', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta39_Futsal', '2000-02-08', 1);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta40_Futsal', '2000-02-09', 1);

-- volei
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta41_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta42_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta43_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta44_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta45_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta46_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta47_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta48_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta49_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta50_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta51_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta52_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta53_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta54_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta55_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta56_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta57_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta58_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta59_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta60_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta61_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta62_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta63_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta64_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta65_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta66_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta67_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta68_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta69_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta70_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta71_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta72_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta73_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta74_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta75_Volei', '2000-01-01', 2);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta76_Volei', '2000-01-01', 2);

-- xadrez
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta77_Xadrez', '2000-01-01', 3);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta78_Xadrez', '2000-01-01', 3);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta79_Xadrez', '2000-01-01', 3);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta80_Xadrez', '2000-01-01', 3);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta81_Xadrez', '2000-01-01', 3);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta82_Xadrez', '2000-01-01', 3);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta83_Xadrez', '2000-01-01', 3);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta84_Xadrez', '2000-01-01', 3);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta85_Xadrez', '2000-01-01', 3);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta86_Xadrez', '2000-01-01', 3);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta87_Xadrez', '2000-01-01', 3);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta88_Xadrez', '2000-01-01', 3);

-- tenis de mesa
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta89_Tenis', '2000-01-01', 4);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta90_Tenis', '2000-01-01', 4);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta91_Tenis', '2000-01-01', 4);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta92_Tenis', '2000-01-01', 4);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta93_Tenis', '2000-01-01', 4);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta94_Tenis', '2000-01-01', 4);
INSERT INTO atleta (id_campeonato, nome_atleta, data_nascimento, id_modalidade) VALUES (1, 'Atleta95_Tenis', '2000-01-01', 4);

-- Equipes de Futsal
INSERT INTO equipe (id_campeonato, id_modalidade, nome_equipe) VALUES (1, 1, 'Equipe1_Futsal');
INSERT INTO equipe (id_campeonato, id_modalidade, nome_equipe) VALUES (1, 1, 'Equipe2_Futsal');
INSERT INTO equipe (id_campeonato, id_modalidade, nome_equipe) VALUES (1, 1, 'Equipe3_Futsal');
INSERT INTO equipe (id_campeonato, id_modalidade, nome_equipe) VALUES (1, 1, 'Equipe4_Futsal');
INSERT INTO equipe (id_campeonato, id_modalidade, nome_equipe) VALUES (1, 1, 'Equipe5_Futsal');
INSERT INTO equipe (id_campeonato, id_modalidade, nome_equipe) VALUES (1, 1, 'Equipe6_Futsal');
INSERT INTO equipe (id_campeonato, id_modalidade, nome_equipe) VALUES (1, 1, 'Equipe7_Futsal');
INSERT INTO equipe (id_campeonato, id_modalidade, nome_equipe) VALUES (1, 1, 'Equipe8_Futsal');

-- Atletas equipes futsal

-- Equipe1
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (1, 1);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (1, 2);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (1, 3);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (1, 4);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (1, 5);

-- Equipe2
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (2, 6);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (2, 7);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (2, 8);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (2, 9);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (2, 10);

-- Equipe3
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (3, 11);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (3, 12);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (3, 13);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (3, 14);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (3, 15);

-- Equipe4
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (4, 16);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (4, 17);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (4, 18);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (4, 19);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (4, 20);

-- Equipe5
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (5, 21);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (5, 22);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (5, 23);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (5, 24);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (5, 25);

-- Equipe6
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (6, 26);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (6, 27);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (6, 28);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (6, 29);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (6, 30);

-- Equipe7
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (7, 31);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (7, 32);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (7, 33);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (7, 34);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (7, 35);

-- Equipe8
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (7, 31);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (7, 32);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (7, 33);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (7, 34);
INSERT INTO equipe_atleta (id_equipe, id_atleta) VALUES (7, 35);