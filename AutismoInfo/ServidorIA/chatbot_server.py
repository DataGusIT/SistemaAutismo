from flask import Flask, request, jsonify
from chatterbot import ChatBot
from chatterbot.trainers import ChatterBotCorpusTrainer

app = Flask(__name__)

chatbot = ChatBot("AssistenteAutismo")
trainer = ChatterBotCorpusTrainer(chatbot)

trainer.train("chatterbot.corpus.portuguese")
trainer.train("Corpus/diagnostico_autismo.yml")
trainer.train("Corpus/tratamentos_terapias.yml")
trainer.train("Corpus/intervencao_educacional.yml")
trainer.train("Corpus/suporte_familiar.yml")
trainer.train("Corpus/compreensao_autismo.yml")
trainer.train("Corpus/interacoes_sociais_comportamento.yml")


@app.route("/chat", methods=["POST"])
def chat():
    user_message = request.json.get("message")
    if not user_message:
        return jsonify({"response": "Oi! Sou um assistente sobre autismo. Você pode me perguntar sobre sinais do autismo, diagnóstico, tratamentos, ou como apoiar alguém com autismo. Como posso te ajudar hoje?"})

    bot_response = chatbot.get_response(user_message)
    return jsonify({"response": str(bot_response)})

    if bot_response.confidence < 0.5:
        return jsonify({"response": "Não entendi sua pergunta. Tente perguntar algo como: 'Quais são os sinais do autismo?' ou 'Como posso ajudar alguém com autismo?'"})

    if user_message.lower() in ["oi", "olá", "oi chatbot", "como vai"]:
        return jsonify({"response": "Olá! Como posso ajudar você? Pergunte sobre: 'sinais do autismo', 'tratamentos', ou 'diagnóstico'. O que você gostaria de saber?"})

if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000)
