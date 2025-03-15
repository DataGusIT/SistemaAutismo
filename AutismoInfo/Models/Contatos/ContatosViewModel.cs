namespace AutismoInfo.Models.Contatos
{
    public class ContatosViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string HorarioAtendimento { get; set; }
        public string Servicos { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
