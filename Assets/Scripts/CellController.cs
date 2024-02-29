using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.UIElements;


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
public class CellController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI noText;
    [SerializeField] TextMeshProUGUI speciesText;
    [SerializeField] TextMeshProUGUI companyText;
    [SerializeField] GameObject detailPanel;

    public string FrmhsIdValue { get; private set; }
    public float OutWsValue { get; private set; }
    public float OutTpValue { get; private set; }
    public float InCo2Value { get; private set; }
    public float InTpValue { get; private set; }
    public float InHdValue { get; private set; }
    public string MeasDtSrValue { get; private set; }
    public float InTpValue1 { get; private set; }
    public float InHdValue1 { get; private set; }
    public float InTpValue2 { get; private set; }
    public float InHdValue2 { get; private set; }
    public string MeasDtSrValue1 { get; private set; }
    public string MeasDtSrValue2 { get; private set; }
    private string apiUrl;
    public string formid;
    Canvas canvas;


    void Awake()
    {
        if (noText != null)
            noText.text = "";
        if (speciesText != null)
            speciesText.text = "";
        if (companyText != null)
            companyText.text = "";

    }

    public void SetData(Dictionary<string, string> data)
    {

        // null 체크를 추가하여 변수가 null이 아닌 경우에만 값을 설정합니다.
        if (noText != null && data.ContainsKey("no"))
            noText.text = data["no"]; // Code 키를 가지고 있는 값을 출력

        if (speciesText != null && data.ContainsKey("species"))
            speciesText.text = data["species"];

        if (companyText != null && data.ContainsKey("company"))
            companyText.text = data["company"];
    }

    public void Start()
    {
        // 스크립트에서 Scroll View 찾아서 할당
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

    }

    public void Update()
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
                JsonResponse jsonResponse = JsonUtility.FromJson<JsonResponse>(apiResponse);

                for (int i = 0; i < jsonResponse.response.body.items.item.Length; i++)
                {
                    MeasurementItem measurementItem = jsonResponse.response.body.items.item[i];

                    if (i == 9) // 마지막 10번째 품목인 경우
                    {
                        InTpValue = measurementItem.inTp;
                        InHdValue = measurementItem.inHd;
                        FrmhsIdValue = measurementItem.frmhsId;
                        OutWsValue = measurementItem.outWs;
                        MeasDtSrValue = measurementItem.measDtStr;
                        OutTpValue = measurementItem.outTp;
                        InCo2Value = measurementItem.inCo2;
                        Debug.Log($"InTpValue: {InTpValue}, InHdValue: {InHdValue}");
                    }
                    else // 마지막 10번째 품목을 제외한 경우
                    {
                        // 나머지 품목들에 대해서는 서로 다른 변수에 값을 저장
                        switch (i)
                        {
                            case 0:
                                InTpValue1 = measurementItem.inTp;
                                InHdValue1 = measurementItem.inHd;
                                MeasDtSrValue1 = measurementItem.measDtStr;
                                Debug.Log($"InTpValue1: {InTpValue1}, InHdValue1: {InHdValue1}, MeasDtSrValue1 ={MeasDtSrValue1} ");
                                break;
                            case 1:
                                InTpValue2 = measurementItem.inTp;
                                InHdValue2 = measurementItem.inHd;
                                MeasDtSrValue2 = measurementItem.measDtStr;
                                Debug.Log($"InTpValue3: {InTpValue2}, InHdValue3: {InHdValue2}, MeasDtSrValue2 ={MeasDtSrValue2}");
                                break;
                            // 나머지 품목들에 대해서도 동일하게 처리
                            default:
                                Debug.LogWarning("Too many measurement items. Ignoring the excess items.");
                                break;
                        }
                    }
                }


                GameObject instantiatedPanel = Instantiate(detailPanel, canvas.transform);

                TextMeshProUGUI[] textComponents = instantiatedPanel.GetComponentsInChildren<TextMeshProUGUI>();

                // Update text values based on the fetched API data
                foreach (TextMeshProUGUI textComponent in textComponents)
                {
                    switch (textComponent.name)
                    {
                        case "InTpText":
                            textComponent.text = $"InTp: {InTpValue}";
                            break;
                        case "InHdText":
                            textComponent.text = $"InHd: {InHdValue}";
                            break;
                        case "FrmhsIdText":
                            textComponent.text = $"FrmhsId: {FrmhsIdValue}";
                            break;
                        case "OutWsText":
                            textComponent.text = $"OutWs: {OutWsValue}";
                            break;
                        case "MeasDtStrText":
                            textComponent.text = $"MeasDtStr: {MeasDtSrValue}";
                            break;
                        case "OutTpText":
                            textComponent.text = $"OutTp: {OutTpValue}";
                            break;
                        case "InCo2Text":
                            textComponent.text = $"InCo2: {InCo2Value}";
                            break;
                        default:
                            break;
                    }
                }
                DropdownManager.ActiveButton = false;
            }
        }
    }
    public void OnClickButton()
    {
        formid = noText.text;
        StartCoroutine(GetApiData());
    }
}