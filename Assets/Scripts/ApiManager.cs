
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

[System.Serializable]
public class MeasurementItem
{
    public float inTp;       // 내부온도
    public float inHd;       // 내부습도
    public string frmhsId;   // 농장코드
    public string measDtStr; // 측정일시
    public float outWs;      // 풍속
    public float outTp;      // 외부온도
    public float inCo2;      // 내부 이산화탄소
}


[System.Serializable]
public class JsonResponse
{
    public Response response;
}

[System.Serializable]
public class Response
{
    public Body body;
}

[System.Serializable]
public class Body
{
    public Items items;
}

[System.Serializable]
public class Items
{
    public MeasurementItem[] item;
}

public class ApiManager : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    // Public properties to access values
    public float InTpValue { get; private set; }
    public float InHdValue { get; private set; }
    public string FrmhsIdValue { get; private set; }
    public string MeasDtSrValue { get; private set; }
    public float OutWsValue { get; private set; }
    public float OutTpValue { get; private set; }   // New variable
    public float InCo2Value { get; private set; }  // New variable
    private string apiUrl;
    public string formid;

    void Start()
    {

    }

    IEnumerator GetApiData()
    {
        
        apiUrl = $"http://apis.data.go.kr/1390000/SmartFarmdata/envdatarqst?serviceKey=ndExmAZPa6Z1SBWydoZsH8RFcdL6XjiFlmZ4Qe0LVdu6WyGJJpkvYMB5ecMII4AIXi0P%2BYcuqLKslBw6ILFgbA%3D%3D&searchFrmhsCode={formid}&returnType=json";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                string apiResponse = webRequest.downloadHandler.text;
                Debug.Log("API Response: " + apiResponse);

                JsonResponse jsonResponse = JsonUtility.FromJson<JsonResponse>(apiResponse);

                foreach (var measurementItem in jsonResponse.response.body.items.item)
                {
                    InTpValue = measurementItem.inTp;
                    InHdValue = measurementItem.inHd;
                    FrmhsIdValue = measurementItem.frmhsId;
                    OutWsValue = measurementItem.outWs;
                    MeasDtSrValue = measurementItem.measDtStr; // 수정: 변수명을 맞춤
                    OutTpValue = measurementItem.outTp;
                    InCo2Value = measurementItem.inCo2;

                    Debug.Log($"inTp: {InTpValue}, inHd: {InHdValue}, frmhsId: {FrmhsIdValue}, measDtStr: {MeasDtSrValue}, outWs: {OutWsValue}, outTp: {OutTpValue}, inCo2: {InCo2Value}");

                    displayText.text = $"내부온도: {InTpValue}\n내부습도: {InHdValue}\n농가코드: {FrmhsIdValue}\n측정 시간: {MeasDtSrValue}\n외부 풍속: {OutWsValue}\n외부온도: {OutTpValue}\n내부 이산화탄소: {InCo2Value}";
                }
            }
        }
    }
    public void OnClickButton()
    {
        // Fetch API data when the button is clicked
        StartCoroutine(GetApiData());
    }
}