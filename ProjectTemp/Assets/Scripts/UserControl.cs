using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Web;
using UnityEngine.Networking;

public static class UserControl
{
    private static string username;
    private static string url;

    public static string Username
    {
        get { return username; }
    }

    public static bool GetUser()
    {
        if (File.Exists(Application.persistentDataPath + "/user.gd"))
        {
            BinaryFormatter binform = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/user.gd", FileMode.Open);
            username = (string)binform.Deserialize(file);
            file.Close();
            return true;
        }
        username = null;
        return false;
    }

    public static bool LogIn(string Username, string Password)
    {
        WWWForm form = new WWWForm();
        form.AddField("Username", Username);
        form.AddField("Password", Password);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                DownloadHandler downhandler = www.downloadHandler;
                if (downhandler.text == true.ToString())
                {
                    username = Username;
                    BinaryFormatter binform = new BinaryFormatter();
                    FileStream file = File.Open(Application.persistentDataPath + "/user.gd", FileMode.OpenOrCreate);
                    binform.Serialize(file, username);
                    file.Close();
                    return true;
                }
            }
        }

        return false;
    }
}
