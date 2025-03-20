using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FocusAcademy.Controllers
{
    public class ChatController : Controller
    {
        private readonly HttpClient _httpClient;

        public ChatController()
        {
            _httpClient = new HttpClient();
        }

        [HttpPost]
        public async Task<IActionResult> EnviarMensagem(string mensagem)
        {
            var json = $"{{\"message\": \"{mensagem}\"}}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var resposta = await _httpClient.PostAsync("http://127.0.0.1:5000/chat", content);
            var respostaTexto = await resposta.Content.ReadAsStringAsync();

            // Corrigir extração do JSON corretamente
            var respostaJson = JsonSerializer.Deserialize<JsonElement>(respostaTexto);
            var respostaFinal = respostaJson.GetProperty("response").GetString();

            return Json(new { resposta = respostaFinal });
}

    }
}
