CREATE VIEW vw_partida_individual AS
SELECT 
    p.id_partida_individual,
    a1.nome_atleta AS nome_atleta1,
    a2.nome_atleta AS nome_atleta2,
    p.resultado_partida
FROM 
    partida_individual p
LEFT JOIN 
    atleta a1 ON p.id_atleta1 = a1.id_atleta
LEFT JOIN 
    atleta a2 ON p.id_atleta2 = a2.id_atleta;


ALTER VIEW vw_partida_individual AS
SELECT 
    pi.id_partida_individual,
    pi.id_atleta1,
    pi.id_atleta2,
    a1.nome_atleta AS nome_atleta1,
    a2.nome_atleta AS nome_atleta2,
    pi.resultado_partida
FROM partida_individual pi
LEFT JOIN atleta a1 ON pi.id_atleta1 = a1.id_atleta
LEFT JOIN atleta a2 ON pi.id_atleta2 = a2.id_atleta;

CREATE VIEW vw_partida_equipe AS
SELECT 
    p.id_partida_equipe,
    p.id_equipe1,
    p.id_equipe2,
    p.resultado,
    f1.fase_partida AS fase_equipe1,
    f2.fase_partida AS fase_equipe2
FROM 
    partida_equipe p
LEFT JOIN fase_equipe f1 ON p.id_equipe1 = f1.id_equipe
LEFT JOIN fase_equipe f2 ON p.id_equipe2 = f2.id_equipe
WHERE 
    f1.id_competicao = 1; -- Substitua pelo ID da competição

select * from vw_partida_equipe;






