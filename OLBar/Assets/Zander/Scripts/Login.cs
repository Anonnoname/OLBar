using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Net;

public class Login : MonoBehaviour
{
    public Button loginButton;
    public string username;
    // Start is called before the first frame update
    void GenerateRequest()
    {
        StartCoroutine(ProcessRequest());
    }

    IEnumerator ProcessRequest()
    {
        var input = gameObject.GetComponent<InputField>();

        WWWForm form = new WWWForm();
        form.AddField("uname", username);

        using (UnityWebRequest www = UnityWebRequest.Post("https://localhost:5000/add", form)) // local server run on port 5000
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Login Success!");
                Debug.Log(www.downloadHandler.text);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
