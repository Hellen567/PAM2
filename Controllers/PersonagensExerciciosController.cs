using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPGAPI.Controllers;
using RPGAPI.Models;
using RPGAPI.Models.Enums;

namespace RPGAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensExerciciosController : ControllerBase
    {
        // Lista de Personagens
        private static List<Personagem> personagens = new List<Personagem>()
        {
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        // Métodos de A até F

        // Método A - GetByNome - Pesquisar personagem por nome
        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var lista = personagens.Where(p => p.Nome.Contains(nome));
            if (!lista.Any())
                return NotFound(new
                {
                    Mensagem = $"Não há personagens com o nome {nome}",
                    StatusCode = 404
                });
            return Ok(lista);
        }

        // Método B - GetClerigoMago - Remover cavaleiros e ordenar por pontos de vida
        [HttpGet("GetByClerigoMago")]
        public IActionResult GetByClerigoMago()
        {
            List<Personagem> lista = new List<Personagem>(personagens);
            lista.RemoveAll(p => p.Classe == ClasseEnum.Cavaleiro);
            lista = lista.OrderByDescending(p => p.PontosVida).ToList();
            return Ok(lista);
        }


        // Método C - GetEstatisticas - Número de personagens e a somatória das inteligências
        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            int inteligenciaSoma = personagens.Sum(p => p.Inteligencia);

            return Ok(new
            {
                Mensagem = $"Número de Personagens: {personagens.Count()}, Somatória das Inteligências: {inteligenciaSoma}",
                StatusCode = 200
            });
        }


        // Método D - PostValidacao - Não aceita personagem com defesa < 10 e inteligência > 30
        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem novoPersonagem)
        {
            if (novoPersonagem.Defesa < 10 || novoPersonagem.Inteligencia > 30)
            {
                return BadRequest(new
                {
                    Mensagem = "O personagem deve ter defesa > 10 e inteligência < 30.",
                    StatusCode = 404
                });
            }
            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }


        // Método E - PostValidacaoMago - Não aceita personagem do tipo MAGO com inteligência < 35
        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem novoPersonagem)
        {
            if (novoPersonagem.Classe == ClasseEnum.Mago && novoPersonagem.Inteligencia < 35)
            {
                return BadRequest(new
                {
                    Mensagem = "Mago deve ter inteligência > 35",
                    StatusCode = 404
                });
            }
            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }


        // Método F - GetByClasse - Seleciona lista de personagens pelo id
        [HttpGet("GetByClasse/{enumId}")]
        public IActionResult GetByClasse(int enumId)
        {
            // Verifica se o valor de enumId é válido para o enum ClasseEnum
            if (!Enum.IsDefined(typeof(ClasseEnum), enumId))
            {
                return BadRequest(new
                {
                    Mensagem = "Classe inválida.",
                    StatusCode = 400
                });
            }

            // Converte o enumId para o tipo ClasseEnum
            var classe = (ClasseEnum)enumId;

            // Filtra os personagens pela classe fornecida
            var lista = personagens.Where(p => p.Classe == classe).ToList();

            // Verifica se encontrou algum personagem
            if (lista.Count == 0)
            {
                return NotFound(new
                {
                    Mensagem = $"Não há personagens da classe {classe}.",
                    StatusCode = 404
                });
            }

            // Retorna a lista de personagens com a classe fornecida
            return Ok(lista);
        }


    }
}