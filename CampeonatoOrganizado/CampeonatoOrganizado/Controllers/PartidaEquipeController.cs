using CampeonatoOrganizado.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CampeonatoOrganizado.Controllers
{
    public class PartidaEquipeController : Controller
    {
        private readonly BancoDadosContext _context;

        public PartidaEquipeController(BancoDadosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                var partidasComFase = _context.PartidaEquipes
                    .Join(_context.FaseEquipes,
                        partida => partida.IdEquipe1,
                        fase => fase.IdEquipe,
                        (partida, fase) => new
                        {
                            partida.IdPartidaEquipe,
                            partida.IdCompeticao,
                            partida.IdEquipe1,
                            partida.IdEquipe2,
                            partida.Resultado,
                            fase.FasePartida
                        })
                    .ToList();

                var modelo = partidasComFase.Select(p => new PartidaEquipeViewModel
                {
                    IdPartidaEquipe = p.IdPartidaEquipe,
                    IdCompeticao = p.IdCompeticao,
                    IdEquipe1 = p.IdEquipe1,
                    IdEquipe2 = p.IdEquipe2,
                    Resultado = p.Resultado.HasValue ? p.Resultado.Value.ToString() : "Sem Resultado",
                    Fase = p.FasePartida.ToString()
                }).ToList();


                return View("~/Views/PartidaEquipe/Index.cshtml", modelo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar index de PartidaEquipe: {ex.Message}");
                return StatusCode(500, "Erro interno ao carregar as partidas.");
            }
        }

        public IActionResult RegistrarVencedor(int idPartida, string vencedor)
        {
            if (idPartida <= 0)
            {
                return BadRequest("ID da partida inválido.");
            }

            try
            {
                var partida = _context.PartidaEquipes.FirstOrDefault(p => p.IdPartidaEquipe == idPartida);

                if (partida == null)
                {
                    return NotFound($"Partida com ID {idPartida} não encontrada.");
                }

                if (string.IsNullOrWhiteSpace(vencedor))
                {
                    return BadRequest("O vencedor deve ser especificado.");
                }

                // Converte o vencedor para ResultadoPartida
                if (Enum.TryParse<ResultadoPartida>(vencedor, true, out var resultado))
                {
                    partida.Resultado = resultado;
                }
                else
                {
                    return BadRequest("O vencedor especificado é inválido.");
                }

                _context.SaveChanges();

                int equipeVencedora = resultado == ResultadoPartida.Equipe1 ? partida.IdEquipe1 : partida.IdEquipe2.Value;

                var faseAtual = _context.FaseEquipes.FirstOrDefault(f => f.IdEquipe == equipeVencedora);
                if (faseAtual != null)
                {
                    faseAtual.FasePartida = AvancarFase(faseAtual.FasePartida);
                    _context.SaveChanges();
                }

                VerificarRodada();
                TempData["Mensagem"] = "Vencedor registrado e nova rodada verificada com sucesso.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao registrar vencedor: {ex.Message}");
                return StatusCode(500, "Erro ao registrar o vencedor.");
            }

            return RedirectToAction("Index");
        }

        private Fase AvancarFase(Fase faseAtual)
        {
            return faseAtual switch
            {
                Fase.Classificatorias => Fase.Oitavas,
                Fase.Oitavas => Fase.Quartas,
                Fase.Quartas => Fase.Semi,
                Fase.Semi => Fase.Final,
                _ => faseAtual
            };
        }

        private void VerificarRodada()
        {
            try
            {
                var fasesAgrupadas = _context.FaseEquipes
                    ?.GroupBy(f => f.FasePartida)
                    ?.ToList();

                if (fasesAgrupadas == null || !fasesAgrupadas.Any())
                {
                    TempData["Mensagem"] = "Nenhuma rodada disponível para verificação.";
                    return;
                }

                foreach (var fase in fasesAgrupadas)
                {
                    var faseAtual = fase.Key;
                    var equipesNaFase = fase.ToList();

                    bool todasFinalizadas = equipesNaFase.All(eq =>
                        _context.PartidaEquipes.Any(p =>
                            (p.IdEquipe1 == eq.IdEquipe || p.IdEquipe2 == eq.IdEquipe) && p.Resultado != null));

                    if (todasFinalizadas)
                    {
                        CriarNovasPartidas(equipesNaFase);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao verificar rodada: {ex.Message}");
                TempData["Mensagem"] = "Erro ao verificar rodada.";
            }
        }

        private void CriarNovasPartidas(List<FaseEquipe> equipes)
        {
            try
            {
                if (equipes == null || !equipes.Any())
                {
                    TempData["Mensagem"] = "Nenhuma equipe disponível para criar novas partidas.";
                    return;
                }

                for (int i = 0; i < equipes.Count; i += 2)
                {
                    if (i + 1 < equipes.Count)
                    {
                        _context.PartidaEquipes.Add(new PartidaEquipe
                        {
                            IdCompeticao = equipes[i].IdCompeticao,
                            IdEquipe1 = equipes[i].IdEquipe,
                            IdEquipe2 = equipes[i + 1].IdEquipe,
                            Resultado = null
                        });

                        Console.WriteLine($"Criando partida entre {equipes[i].IdEquipe} e {equipes[i + 1].IdEquipe}");
                    }
                }

                _context.SaveChanges();
                TempData["Mensagem"] = "Novas partidas criadas com sucesso.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar novas partidas: {ex.Message}");
                TempData["Mensagem"] = "Erro ao criar novas partidas.";
            }
        }
    }
}
