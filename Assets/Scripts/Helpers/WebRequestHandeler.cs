using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class WebRequestHandeler : MonoBehaviour
{

    #region Static
    public static WebRequestHandeler sInstance;
    #endregion

    #region Events
    public delegate void StringResponseEventHandler(string data);
    #endregion

    #region Unity Methods
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        sInstance = this;
    }
    #endregion

    #region Methods

    public IEnumerator HttpsPost(string uri, WWWForm postData, StringResponseEventHandler callback)
    {
        UnityWebRequest www = UnityWebRequest.Post(uri, postData);
        www.SetRequestHeader("content-type", "application/x-www-form-urlencoded");
        yield return www.SendWebRequest();
        if (www.error != null)
        {
            Debug.LogWarning(www.error);
            Debug.LogWarning(www.downloadHandler.text);
            if (callback != null)
                callback(www.error);
        }
        else
        {
            if (callback != null)
                callback(www.downloadHandler.text);
        }

        www.Dispose();
    }

    #endregion
}
