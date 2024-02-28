using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

[System.Serializable]
public class MeasurementItem
{
    public float inTp;       // ���οµ�
    public float inHd;       // ���ν���
    public string frmhsId;   // �����ڵ�
    public string measDtStr; // �����Ͻ�
    public float outWs;      // ǳ��
    public float outTp;      // �ܺοµ�
    public float inCo2;      // ���� �̻�ȭź��
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
    private string apiUrl = "http://apis.data.go.kr/1390000/SmartFarmdata/envdatarqst?serviceKey=ndExmAZPa6Z1SBWydoZsH8RFcdL6XjiFlmZ4Qe0LVdu6WyGJJpkvYMB5ecMII4AIXi0P%2BYcuqLKslBw6ILFgbA%3D%3D&searchFrmhsCode=81&returnType=json";

    // Public properties to access values
    public float InTpValue { get; private set; }
    public float InHdValue { get; private set; }
    public string FrmhsIdValue { get; private set; }
    public string MeasDtSrValue { get; private set; }
    public float OutWsValue { get; private set; }
    public float OutTpValue { get; private set; }   // New variable
    public float InCo2Value { get; private set; }  // New variable

    void Start()
    {
        // Fetch API data immediately when the script starts
        StartCoroutine(GetApiData());

        // Start the coroutine to update every 10 seconds
        StartCoroutine(UpdateApiDataPeriodically());
    }

    IEnumerator UpdateApiDataPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f); // Wait for 10 seconds

            yield return StartCoroutine(GetApiData()); // Fetch API data

            // Optionally, you can add any additional logic or debug statements here
            Debug.Log("API data updated at: " + Time.time);
        }
    }

    IEnumerator GetApiData()
    {
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
                    MeasDtSrValue = measurementItem.measDtStr; // ����: �������� ����
                    OutTpValue = measurementItem.outTp;
                    InCo2Value = measurementItem.inCo2;

                    Debug.Log($"inTp: {InTpValue}, inHd: {InHdValue}, frmhsId: {FrmhsIdValue}, measDtStr: {MeasDtSrValue}, outWs: {OutWsValue}, outTp: {OutTpValue}, inCo2: {InCo2Value}");

                    displayText.text = $"���οµ�: {InTpValue}\n���ν���: {InHdValue}\n���ڵ�: {FrmhsIdValue}\n���� �ð�: {MeasDtSrValue}\n�ܺ� ǳ��: {OutWsValue}\n�ܺοµ�: {OutTpValue}\n���� �̻�ȭź��: {InCo2Value}";
                }
            }
        }
    }
}