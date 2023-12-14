using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChatManager : MonoBehaviour
{
    public TMP_Text chatText;
    public TMP_InputField inputField;
    public ScrollRect scrollRect;

    public void SendMessage()
    {
        string playerName = "Player"; // Lấy tên người chơi từ nơi nào đó (ví dụ: nhập từ người chơi)
        string message = inputField.text;

        string formattedMessage = $"{playerName}: {message}\n";

        chatText.text += formattedMessage;

        // Cuộn xuống cuối cùng của ScrollView
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;

        // Xóa nội dung trong InputField
        inputField.text = "";
    }
}
