SELECT equipe_id, SUM(pontos) AS total_pontos
FROM Pontuacao
WHERE torneio_id = 1
GROUP BY equipe_id
ORDER BY total_pontos DESC;

-- checar atleta disponivel
SELECT * FROM alocacao_atleta_partida
WHERE atleta_id = :atleta_id
AND (
    (horario_inicio <= :novo_horario_fim AND horario_fim >= :novo_horario_inicio)
);

-- lista todos os atletas de uma equipe especifica
SELECT a.*
FROM atleta a
JOIN equipe_atleta ea ON a.id_atleta = ea.id_atleta
WHERE ea.id_equipe = 1;

