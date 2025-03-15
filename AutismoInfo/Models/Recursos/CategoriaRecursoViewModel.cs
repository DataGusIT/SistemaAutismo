using System.Collections.Generic;

namespace AutismoInfo.Models
{
    public class CategoriaRecursoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<RecursoViewModel> Recursos { get; set; }
    }
}
