using CampeonatoOrganizado.Models;
using Microsoft.EntityFrameworkCore;

public class PontuacaoService
{
    private readonly BancoDadosContext _context;

    public PontuacaoService(BancoDadosContext context)
    {
        _context = context;
    }

    public async Task AtualizarPontuacaoAsync(PartidaIndividual partida)
    {
        // Verificar atleta 1
        var pontuacaoAtleta1 = await _context.PontuacaoIndividual
            .FirstOrDefaultAsync(p => p.id_atleta == partida.id_atleta1 && p.id_competicao == partida.id_competicao);

        // Verificar atleta 2
        var pontuacaoAtleta2 = partida.id_atleta2.HasValue
            ? await _context.PontuacaoIndividual
                .FirstOrDefaultAsync(p => p.id_atleta == partida.id_atleta2 && p.id_competicao == partida.id_competicao)
            : null;

        // Atualizar pontuação com base no resultado
        switch (partida.resultado_partida)
        {
            case "atleta1":
                if (pontuacaoAtleta1 != null) pontuacaoAtleta1.pontos += 3;
                break;
            case "atleta2":
                if (pontuacaoAtleta2 != null) pontuacaoAtleta2.pontos += 3;
                break;
            case "empate":
                if (pontuacaoAtleta1 != null) pontuacaoAtleta1.pontos += 1;
                if (pontuacaoAtleta2 != null) pontuacaoAtleta2.pontos += 1;
                break;
            case "bye":
                if (pontuacaoAtleta1 != null)
                {
                    pontuacaoAtleta1.pontos += 3;
                    pontuacaoAtleta1.byes = true; // Marca que o atleta recebeu o bye
                }
                else
                {
                    throw new InvalidOperationException($"O atleta já recebeu um bye.");
                }
                break;
        }

        // Salvar mudanças no banco de dados
        await _context.SaveChangesAsync();
    }
}
