using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutismoInfo.Models;
using AutismoInfo.Models.FAQ;

namespace AutismoInfo.Controllers.FAQ
{
    public class DuvidasController : Controller
    {
        public IActionResult Index()
        {
            var categorias = new List<CategoriaDuvidaViewModel>
            {
                new CategoriaDuvidaViewModel
                {
                    Id = 1,
                    Nome = "Informações Básicas sobre TEA",
                    Duvidas = new List<DuvidaViewModel>
                    {
                        new DuvidaViewModel
                        {
                            Id = 1,
                            Pergunta = "O que é TEA (Transtorno do Espectro Autista)?",
                            Resposta = "O Transtorno do Espectro Autista (TEA) é uma condição neurodesenvolvimental caracterizada por diferenças na comunicação social, comportamentos repetitivos e interesses restritos. O termo 'espectro' indica a ampla variação de desafios e habilidades que as pessoas com TEA podem apresentar.",
                            LinkArtigo = "https://www.exemplo.com/artigo-sobre-tea",
                            TituloArtigo = "Compreendendo o TEA: Uma Visão Geral"
                        },
                        new DuvidaViewModel
                        {
                            Id = 2,
                            Pergunta = "Quais são os sinais de autismo em crianças pequenas?",
                            Resposta = "Os sinais de autismo em crianças pequenas podem incluir: atraso ou ausência de linguagem verbal, dificuldade em manter contato visual, reduzido interesse em interações sociais, movimentos repetitivos (como balançar o corpo ou girar objetos), reações incomuns a estímulos sensoriais, rotinas rígidas e interesse intenso em assuntos específicos. É importante ressaltar que cada criança é única e pode apresentar diferentes combinações desses sinais.",
                            LinkArtigo = "https://www.exemplo.com/sinais-tea-criancas",
                            TituloArtigo = "Identificando Sinais Precoces do TEA"
                        }
                    }
                },
                new CategoriaDuvidaViewModel
                {
                    Id = 2,
                    Nome = "Diagnóstico e Avaliação",
                    Duvidas = new List<DuvidaViewModel>
                    {
                        new DuvidaViewModel
                        {
                            Id = 3,
                            Pergunta = "Como é feito o diagnóstico de autismo?",
                            Resposta = "O diagnóstico de autismo é realizado por uma equipe multidisciplinar, geralmente incluindo neurologistas, psiquiatras, psicólogos e fonoaudiólogos. O processo envolve observação clínica, entrevistas com cuidadores, histórico de desenvolvimento e, muitas vezes, instrumentos específicos de avaliação. Não existe um exame laboratorial ou de imagem que diagnostique o TEA, sendo o diagnóstico essencialmente clínico.",
                            LinkArtigo = "https://www.exemplo.com/processo-diagnostico-tea",
                            TituloArtigo = "O Processo de Diagnóstico do TEA"
                        },
                        new DuvidaViewModel
                        {
                            Id = 4,
                            Pergunta = "Qual a idade ideal para o diagnóstico de TEA?",
                            Resposta = "Embora os primeiros sinais do TEA possam ser observados a partir dos 12-18 meses, o diagnóstico confiável geralmente ocorre por volta dos 2-3 anos de idade. No entanto, algumas crianças, especialmente aquelas com sintomas mais sutis ou com alto funcionamento, podem ser diagnosticadas mais tarde. É importante buscar avaliação profissional assim que surgirem as primeiras preocupações, pois a intervenção precoce está associada a melhores resultados.",
                            LinkArtigo = "https://www.exemplo.com/diagnostico-precoce",
                            TituloArtigo = "A Importância do Diagnóstico Precoce no TEA"
                        }
                    }
                },
                new CategoriaDuvidaViewModel
                {
                    Id = 3,
                    Nome = "Tratamentos e Intervenções",
                    Duvidas = new List<DuvidaViewModel>
                    {
                        new DuvidaViewModel
                        {
                            Id = 5,
                            Pergunta = "Quais são as principais abordagens terapêuticas para o TEA?",
                            Resposta = "Existem diversas abordagens terapêuticas para o TEA, incluindo: Análise do Comportamento Aplicada (ABA), Terapia Fonoaudiológica, Terapia Ocupacional, Integração Sensorial, PECS (Sistema de Comunicação por Troca de Figuras), TEACCH (Tratamento e Educação para Autistas e Crianças com Déficits relacionados à Comunicação), e intervenções baseadas em DIR/Floortime. O tratamento ideal geralmente envolve uma combinação personalizada dessas abordagens, adaptadas às necessidades específicas de cada pessoa.",
                            LinkArtigo = "https://www.exemplo.com/terapias-tea",
                            TituloArtigo = "Guia Completo de Terapias para TEA"
                        },
                        new DuvidaViewModel
                        {
                            Id = 6,
                            Pergunta = "Existe cura para o autismo?",
                            Resposta = "O autismo não tem cura, pois não é uma doença, mas uma condição neurodesenvolvimental que acompanha a pessoa por toda a vida. No entanto, com intervenções adequadas e suporte apropriado, pessoas com TEA podem desenvolver habilidades, superar desafios e ter uma vida plena e satisfatória. O foco do tratamento não é 'curar' o autismo, mas promover o desenvolvimento de habilidades, a autonomia e a qualidade de vida.",
                            LinkArtigo = "https://www.exemplo.com/compreendendo-tea",
                            TituloArtigo = "Compreendendo o TEA como uma Neurodiversidade"
                        }
                    }
                }
            };

            return View(categorias);
        }
    }
}

