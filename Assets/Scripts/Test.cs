using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestExample : MonoBehaviour
{
    string url = "https://apis.data.go.kr/1390000/SmartFarmdata/envdatarqst";
    void Start()
    {
        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                // ���������� �����͸� �޾ƿ� ���
                Debug.Log("Received: " + webRequest.downloadHandler.text);
            }
        }
    }
}
