using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
public class SendData : MonoBehaviour
{

    public TextMeshProUGUI username;
    public TextMeshProUGUI email;

    private string Name;
    private string Email;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSegsL_rERxs2t-0ISa1EhfLKJEYIzrS76sYlO7YVJuWZp8FwQ/formResponse";

    IEnumerator Post(string name, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1505696049", name);
        form.AddField("entry.1864316246", email);

        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
    public void Send()
    {
        Name = username.text;
        Email = email.text;
        StartCoroutine(Post(Name, Email));

    }
}