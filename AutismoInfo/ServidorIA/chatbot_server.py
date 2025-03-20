
from flask import Flask, request, jsonify
from chatterbot import ChatBot
from chatterbot.trainers import ChatterBotCorpusTrainer

app = Flask(__name__)

# Criar o chatbot
chatbot = ChatBot("AssistenteAutismo")
trainer = ChatterBotCorpusTrainer(chatbot)

# Treinar com base em diálogos pré-definidos
trainer.train("chatterbot.corpus.portuguese")

trainer.train(
        "chatterbot.corpus.portuguese",
        "Corpus/diagnostico_autismo.yml",
        "Corpus/tratamentos_terapias.yml",
        "Corpus/intervencao_educacional.yml",
        "Corpus/suporte_familiar.yml",
        "Corpus/compreensao_autismo.yml",
        "Corpus/interacoes_sociais_comportamento.yml"
)

@app.route("/chat", methods=["POST"])
def chat():
    user_message = request.json.get("message")
    if not user_message:
        return jsonify({"response": "Por favor, envie uma mensagem válida!"})

    bot_response = chatbot.get_response(user_message)
    return jsonify({"response": str(bot_response)})

if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000)
