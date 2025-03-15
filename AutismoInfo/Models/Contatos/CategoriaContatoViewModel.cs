using System.Collections.Generic;

namespace AutismoInfo.Models.Contatos
{
    public class CategoriaContatoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<ContatosViewModel> Contatos { get; set; }
    }
}
