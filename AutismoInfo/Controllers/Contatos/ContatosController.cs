using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutismoInfo.Models;
using AutismoInfo.Models.Contatos;

namespace AutismoInfo.Controllers.Contatos
{
    public class ContatosController : Controller
    {
        public IActionResult Index()
        {
            var categoriasContato = new List<CategoriaContatoViewModel>
            {
                new CategoriaContatoViewModel
                {
                    Id = 1,
                    Nome = "Clínicas Especializadas",
                    Contatos = new List<ContatosViewModel>
                    {
                        new ContatosViewModel
                        {
                            Id = 1,
                            Nome = "Centro de Desenvolvimento Infantil Crescer",
                            Descricao = "Clínica especializada em diagnóstico e intervenção precoce para TEA com equipe multidisciplinar.",
                            Endereco = "Av. Principal, 1000 - Centro",
                            Cidade = "São Paulo",
                            Estado = "SP",
                            Telefone = "(11) 3333-4444",
                            Email = "contato@crescer.com.br",
                            Website = "https://www.crescer.com.br",
                            HorarioAtendimento = "Segunda a Sexta: 8h às 18h",
                            Servicos = "Diagnóstico, ABA, Fonoaudiologia, Terapia Ocupacional, Psicologia"
                        },
                        new ContatosViewModel
                        {
                            Id = 2,
                            Nome = "Instituto Neurodesenvolvimental Integrar",
                            Descricao = "Equipe multidisciplinar focada no atendimento personalizado para pessoas com TEA de todas as idades.",
                            Endereco = "Rua das Flores, 500 - Jardim",
                            Cidade = "Rio de Janeiro",
                            Estado = "RJ",
                            Telefone = "(21) 2222-3333",
                            Email = "contato@integrar.com.br",
                            Website = "https://www.integrar.com.br",
                            HorarioAtendimento = "Segunda a Sexta: 8h às 19h | Sábado: 8h às 12h",
                            Servicos = "Neurologia, Psiquiatria, ABA, Fonoaudiologia, Psicologia, Grupos de habilidades sociais"
                        }
                    }
                },
                new CategoriaContatoViewModel
                {
                    Id = 2,
                    Nome = "ONGs e Associações",
                    Contatos = new List<ContatosViewModel>
                    {
                        new ContatosViewModel
                        {
                            Id = 3,
                            Nome = "Associação Amigos do Autismo (AMA)",
                            Descricao = "ONG pioneira no Brasil dedicada ao atendimento de pessoas com TEA e apoio às famílias.",
                            Endereco = "Rua do Apoio, 750 - Centro",
                            Cidade = "São Paulo",
                            Estado = "SP",
                            Telefone = "(11) 5555-6666",
                            Email = "contato@ama.org.br",
                            Website = "https://www.ama.org.br",
                            HorarioAtendimento = "Segunda a Sexta: 9h às 17h",
                            Servicos = "Atendimento educacional, grupos de apoio para famílias, capacitação profissional"
                        },
                        new ContatosViewModel
                        {
                            Id = 4,
                            Nome = "Instituto Neurodiversidade",
                            Descricao = "Organização dedicada à promoção da inclusão e da autonomia de pessoas autistas, com foco em adolescentes e adultos.",
                            Endereco = "Av. da Inclusão, 180 - Boa Vista",
                            Cidade = "Belo Horizonte",
                            Estado = "MG",
                            Telefone = "(31) 4444-5555",
                            Email = "contato@neurodiversidade.org.br",
                            Website = "https://www.neurodiversidade.org.br",
                            HorarioAtendimento = "Segunda a Sexta: 8h30 às 17h30",
                            Servicos = "Mentoria profissional, autoadvocacia, grupos de apoio, cursos e workshops"
                        }
                    }
                },
                new CategoriaContatoViewModel
                {
                    Id = 3,
                    Nome = "Centros de Apoio",
                    Contatos = new List<ContatosViewModel>
                    {
                        new ContatosViewModel
                        {
                            Id = 5,
                            Nome = "Centro de Atenção Psicossocial Infantojuvenil (CAPSi)",
                            Descricao = "Serviço público especializado em saúde mental para crianças e adolescentes com TEA e outros transtornos.",
                            Endereco = "Rua da Saúde, 400 - Setor Sul",
                            Cidade = "Brasília",
                            Estado = "DF",
                            Telefone = "(61) 3333-2222",
                            Email = "capsi@saude.gov.br",
                            Website = "https://www.saude.gov.br/capsi",
                            HorarioAtendimento = "Segunda a Sexta: 7h às 19h",
                            Servicos = "Avaliação, acompanhamento terapêutico, grupos de socialização, atendimento familiar"
                        },
                        new ContatosViewModel
                        {
                            Id = 6,
                            Nome = "Centro de Referência em Autismo (CRA)",
                            Descricao = "Centro público especializado no atendimento integral a pessoas com TEA, com foco em diagnóstico e intervenção precoce.",
                            Endereco = "Av. da Esperança, 300 - Centro",
                            Cidade = "Salvador",
                            Estado = "BA",
                            Telefone = "(71) 2222-1111",
                            Email = "cra@saude.ba.gov.br",
                            Website = "https://www.saude.ba.gov.br/cra",
                            HorarioAtendimento = "Segunda a Sexta: 8h às 17h",
                            Servicos = "Diagnóstico, intervenção precoce, apoio educacional, orientação familiar"
                        }
                    }
                }
            };

            return View(categoriasContato);
        }

        public IActionResult Detalhes(int id)
        {
            // Na versão final, você buscaria o contato do banco de dados
            // Isso é apenas um exemplo
            var contato = new ContatosViewModel
            {
                Id = id,
                Nome = "Nome do Contato " + id,
                Descricao = "Descrição detalhada do contato selecionado.",
                Endereco = "Endereço completo",
                Cidade = "Cidade",
                Estado = "UF",
                Telefone = "(00) 0000-0000",
                Email = "contato@exemplo.com",
                Website = "https://www.exemplo.com",
                HorarioAtendimento = "Segunda a Sexta: 8h às 18h",
                Servicos = "Lista de serviços oferecidos",
                Latitude = -23.550520,
                Longitude = -46.633309
            };

            return View(contato);
        }
    }
}
        
    

