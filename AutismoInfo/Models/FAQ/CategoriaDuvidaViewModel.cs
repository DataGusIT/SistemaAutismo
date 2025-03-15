using System.Collections.Generic;

namespace AutismoInfo.Models.FAQ
{
    public class CategoriaDuvidaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<DuvidaViewModel> Duvidas { get; set; }
    }
}
