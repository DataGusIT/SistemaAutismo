document.addEventListener("DOMContentLoaded", function () {
    const chatButton = document.getElementById("chatbot-button");
    const chatBox = document.getElementById("chatbot-box");
    const chatMessages = document.getElementById("chatbot-messages");
    const chatInput = document.getElementById("chatbot-input");
    const chatSend = document.getElementById("chatbot-send");
    const chatClose = document.getElementById("chatbot-close");

    chatButton.addEventListener("click", function () {
        chatBox.classList.toggle("hidden");
        chatBox.style.display = "flex";
        chatButton.style.display = "none";
    });

    chatClose.addEventListener("click", function () {
        chatBox.classList.add("hidden");
        chatBox.style.display = "none";
        chatButton.style.display = "block";
    });

    chatSend.addEventListener("click", sendMessage);
    chatInput.addEventListener("keypress", function (e) {
        if (e.key === "Enter") sendMessage();
    });

    async function sendMessage() {
        let userMessage = chatInput.value.trim();
        if (!userMessage) return;
    
        appendMessage("user", userMessage);
        chatInput.value = "";
    
        try {
            const response = await fetch("/Chat/EnviarMensagem", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ mensagem: userMessage })
            });
    
            const data = await response.json();
            appendMessage("bot", data.resposta);
        } catch (error) {
            appendMessage("bot", "Erro ao se comunicar com o servidor.");
        }
    }
    

    function appendMessage(sender, text) {
        let messageDiv = document.createElement("div");
        messageDiv.className = `chat-message ${sender}-message`;
        messageDiv.textContent = text;
        chatMessages.appendChild(messageDiv);
        chatMessages.scrollTop = chatMessages.scrollHeight;
    }
});
