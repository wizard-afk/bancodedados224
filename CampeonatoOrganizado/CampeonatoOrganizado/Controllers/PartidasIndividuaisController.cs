using Microsoft.AspNetCore.Mvc;
using CampeonatoOrganizado.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CampeonatoOrganizado.Controllers
{
    public class PartidasController : Controller
    {
        private readonly BancoDadosContext _context;
        private readonly PontuacaoService _pontuacaoService;

        public PartidasController(BancoDadosContext context, PontuacaoService pontuacaoService)
        {
            _context = context;
            _pontuacaoService = pontuacaoService;
        }

        public IActionResult Index()
        {
            try
            {
                // Carregar todas as pontuações previamente
                var pontuacoes = _context.PontuacaoIndividual
                    ?.ToDictionary(p => p.id_atleta, p => p.pontos) ?? new Dictionary<int, int>();

                // Montar a lista de partidas
                var partidas = _context.PartidaIndividualView
                    ?.Select(p => new PartidaIndividualView
                    {
                        nome_atleta1 = p.nome_atleta1,
                        pontuacao_atleta1 = pontuacoes.ContainsKey(p.id_atleta1) ? pontuacoes[p.id_atleta1] : 0,
                        nome_atleta2 = p.id_atleta2 != null ? p.nome_atleta2 : "N/A",
                        pontuacao_atleta2 = p.id_atleta2 != null && pontuacoes.ContainsKey((int)p.id_atleta2)
                            ? pontuacoes[(int)p.id_atleta2]
                            : 0,
                        resultado_partida = p.resultado_partida,
                        id_partida_individual = p.id_partida_individual
                    })
                    .ToList() ?? new List<PartidaIndividualView>();

                return View("~/Views/PartidasIndividuais/Index.cshtml", partidas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar partidas: {ex.Message}");
                return StatusCode(500, "Erro interno ao carregar partidas.");
            }
        }

        // Atualizar ou inserir resultado de uma partida
        public IActionResult AtualizarResultado(int idPartida, string resultado)
        {
            if (idPartida <= 0)
            {
                return BadRequest("ID da partida inválido.");
            }

            var partida = _context.PartidaIndividual
                .Include(p => p.atleta1)
                .Include(p => p.atleta2)
                .FirstOrDefault(p => p.id_partida_individual == idPartida);

            if (partida == null)
            {
                return NotFound($"Partida com ID {idPartida} não encontrada.");
            }

            partida.resultado_partida = resultado;

            try
            {
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar resultado da partida: {ex.Message}");
                return StatusCode(500, "Erro ao atualizar resultado da partida.");
            }
        }

        // Criar nova partida e atualizar pontuações
        [HttpPost]
        public async Task<IActionResult> CriarPartida([FromBody] PartidaIndividual partida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Adicionar a nova partida ao banco
                _context.PartidaIndividual.Add(partida);
                await _context.SaveChangesAsync();

                // Atualizar pontuação via serviço injetado
                await _pontuacaoService.AtualizarPontuacaoAsync(partida);

                return Ok(partida);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar partida: {ex.Message}");
                return StatusCode(500, "Erro ao criar nova partida.");
            }
        }
    }
}
