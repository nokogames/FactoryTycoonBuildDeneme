using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace _Main.Project.Scripts
{
    public class TelegramDataFetcher : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(GetUserDataFromServer());
        }

        IEnumerator GetUserDataFromServer()
        {
            UnityWebRequest www = UnityWebRequest.Get("http://3.85.20.195:3000/get-user-data");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string jsonData = www.downloadHandler.text;
                Debug.Log("User Data: " + jsonData);
            }
            else
            {
                Debug.LogError("Error: " + www.error);
            }
        }
    }
}