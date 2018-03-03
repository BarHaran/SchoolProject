using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestScript : MonoBehaviour
{
    public string url;

    void Start()
    {
        SendForm();
    }

    void Update()
    {

    }

    void SendForm()
    {
        WWWForm form = new WWWForm();
        form.AddField("sinput", "asd");
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.data);
            }
        }
    }
}
