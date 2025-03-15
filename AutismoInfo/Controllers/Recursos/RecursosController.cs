using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutismoInfo.Models;

namespace AutismoInfo.Controllers
{
    public class RecursosController : Controller
    {
        public IActionResult Index()
        {
            var categorias = new List<CategoriaRecursoViewModel>
            {
                new CategoriaRecursoViewModel
                {
                    Id = 1,
                    Nome = "Artigos Científicos",
                    Descricao = "Artigos científicos sobre TEA (Transtorno do Espectro Autista)",
                    Recursos = new List<RecursoViewModel>
                    {
                        new RecursoViewModel
                        {
                            Id = 1,
                            Titulo = "Avanços na Compreensão do TEA",
                            Descricao = "Artigo que aborda os avanços científicos na compreensão do Transtorno do Espectro Autista nos últimos 10 anos.",
                            TipoArquivo = "PDF",
                            Tamanho = "2.3 MB",
                            Url = "/arquivos/artigo-avancos-tea.pdf",
                            DataPublicacao = "10/01/2024"
                        },
                        new RecursoViewModel
                        {
                            Id = 2,
                            Titulo = "Intervenções Precoces em TEA",
                            Descricao = "Estudo sobre os benefícios das intervenções precoces em crianças com TEA.",
                            TipoArquivo = "PDF",
                            Tamanho = "1.8 MB",
                            Url = "/arquivos/intervencoes-precoces.pdf",
                            DataPublicacao = "05/03/2024"
                        }
                    }
                },
                new CategoriaRecursoViewModel
                {
                    Id = 2,
                    Nome = "Cartilhas Educativas",
                    Descricao = "Cartilhas e guias para pais, educadores e profissionais",
                    Recursos = new List<RecursoViewModel>
                    {
                        new RecursoViewModel
                        {
                            Id = 3,
                            Titulo = "Guia para Pais de Crianças com TEA",
                            Descricao = "Guia completo com orientações para pais de crianças recém-diagnosticadas com autismo.",
                            TipoArquivo = "PDF",
                            Tamanho = "4.5 MB",
                            Url = "/arquivos/guia-pais-tea.pdf",
                            DataPublicacao = "15/02/2024"
                        },
                        new RecursoViewModel
                        {
                            Id = 4,
                            Titulo = "Autismo na Escola: Guia para Educadores",
                            Descricao = "Material didático para professores e educadores sobre inclusão escolar de alunos com TEA.",
                            TipoArquivo = "PDF",
                            Tamanho = "3.2 MB",
                            Url = "/arquivos/autismo-escola.pdf",
                            DataPublicacao = "20/02/2024"
                        }
                    }
                },
                new CategoriaRecursoViewModel
                {
                    Id = 3,
                    Nome = "Vídeos e Webinários",
                    Descricao = "Conteúdo audiovisual sobre TEA",
                    Recursos = new List<RecursoViewModel>
                    {
                        new RecursoViewModel
                        {
                            Id = 5,
                            Titulo = "Webinário: Autismo e as Relações Familiares",
                            Descricao = "Webinário com especialistas discutindo como o TEA afeta as relações familiares e estratégias de apoio.",
                            TipoArquivo = "Vídeo",
                            Tamanho = "45 min",
                            Url = "https://youtube.com/embed/exemplo",
                            DataPublicacao = "10/03/2024"
                        },
                        new RecursoViewModel
                        {
                            Id = 6,
                            Titulo = "Série: Desenvolvimento de Habilidades Sociais",
                            Descricao = "Série de vídeos com técnicas e atividades para desenvolvimento de habilidades sociais em pessoas com TEA.",
                            TipoArquivo = "Playlist",
                            Tamanho = "5 vídeos",
                            Url = "https://youtube.com/playlist?list=exemplo",
                            DataPublicacao = "01/02/2024"
                        }
                    }
                }
            };

            return View(categorias);
        }

        public IActionResult Detalhes(int id)
        {
            // Na versão final, você buscaria o recurso do banco de dados
            // Isso é apenas um exemplo
            var recurso = new RecursoViewModel
            {
                Id = id,
                Titulo = "Título do Recurso " + id,
                Descricao = "Descrição detalhada do recurso selecionado.",
                TipoArquivo = "PDF",
                Tamanho = "2.5 MB",
                Url = "/arquivos/recurso-" + id + ".pdf",
                DataPublicacao = "10/03/2024",
                ConteudoCompleto = "Este é um exemplo de conteúdo completo do recurso. Em um sistema real, este conteúdo seria obtido do banco de dados."
            };

            return View(recurso);
        }
    }
}