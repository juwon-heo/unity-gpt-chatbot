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
            AddMessageToChat("��", userInput);
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
            Debug.LogError("TMP_Text�� ã�� �� �����ϴ�. �������� Ȯ���ϼ���.");
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
            Debug.LogError("API ��û ����: " + request.error);
            AddMessageToChat("����", request.error);
        }
        else
        {
            string jsonResponse = request.downloadHandler.text;
            Debug.Log("GPT ����: " + jsonResponse);

            ChatGPTResponse parsed = JsonUtility.FromJson<ChatGPTResponse>(jsonResponse);
            string reply = parsed.choices[0].message.content;
            AddMessageToChat("����Ƽ", reply);
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
