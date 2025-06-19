using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class MyGPT : MonoBehaviour
{
    public TMP_InputField userInputField;
    public Transform chatContentTransform;
    public GameObject chatMessagePrefab;

    private string apiKey = "Your Api-key";
    private string apiUrl = "https://api.openai.com/v1/chat/completions";

    public void OnSendClicked()
    {
        string userInput = userInputField.text;
        if (!string.IsNullOrEmpty(userInput))
        {
            AddMessageToChat("나", userInput);
            StartCoroutine(SendToGPT(userInput));
            userInputField.text = "";
        }
    }

    void AddMessageToChat(string sender, string message)
    {
        GameObject msgObj = Instantiate(chatMessagePrefab, chatContentTransform);
        TMP_Text text = msgObj.GetComponentInChildren<TMP_Text>();
        if (text == null)
        {
            Debug.LogError("TMP_Text를 찾을 수 없습니다. 프리팹을 확인하세요.");
            return;
        }

        text.text = $"<b>{sender}:</b> {message}";
        Debug.Log($"[UI] {sender}: {message}");
    }

    IEnumerator SendToGPT(string input)
    {
        string json = "{\"model\":\"gpt-3.5-turbo\",\"messages\":[{\"role\":\"user\",\"content\":\"" + input + "\"}]}";
        byte[] data = System.Text.Encoding.UTF8.GetBytes(json);

        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        request.uploadHandler = new UploadHandlerRaw(data);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API 요청 실패: " + request.error);
            AddMessageToChat("에러", request.error);
        }
        else
        {
            string jsonResponse = request.downloadHandler.text;
            Debug.Log("GPT 응답: " + jsonResponse);

            ChatGPTResponse parsed = JsonUtility.FromJson<ChatGPTResponse>(jsonResponse);
            string reply = parsed.choices[0].message.content;
            AddMessageToChat("지피티", reply);
        }
    }
}

[System.Serializable]
public class ChatGPTResponse
{
    public Choice[] choices;
}

[System.Serializable]
public class Choice
{
    public Message message;
}

[System.Serializable]
public class Message
{
    public string content;
}
