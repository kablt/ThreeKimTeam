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
public class CellController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI noText;
    [SerializeField] TextMeshProUGUI speciesText;
    [SerializeField] TextMeshProUGUI companyText;
    [SerializeField] GameObject detailPanel;


//�޾ƿ� ������ ������ �гο� �������� ����. ������ �������� �ҷ��� 10��° ������
public string FrmhsIdValue { get; private set; }
    public float OutWsValue10 { get; private set; }
    public float OutTpValue10 { get; private set; }
    public float InCo2Value10 { get; private set; }
    public float InTpValue10 { get; private set; }
    public float InHdValue10 { get; private set; }
    public string MeasDtSrValue10 { get; private set; }
    //ù��° ���� ��ȩ��° ������ ���� ���οµ�,���ν���,�����Ͻ� 3���� ������ ����.(�׷����� ����ϱ�����)
    public float InTpValue1 { get; private set; }
    public float InTpValue2 { get; private set; }
    public float InTpValue3 { get; private set; }
    public float InTpValue4 { get; private set; }
    public float InTpValue5 { get; private set; }
    public float InTpValue6 { get; private set; }
    public float InTpValue7 { get; private set; }
    public float InTpValue8 { get; private set; }
    public float InTpValue9 { get; private set; }
    public float InHdValue1 { get; private set; }
    public float InHdValue2 { get; private set; }
    public float InHdValue3 { get; private set; }
    public float InHdValue4 { get; private set; }
    public float InHdValue5 { get; private set; }
    public float InHdValue6 { get; private set; }
    public float InHdValue7 { get; private set; }
    public float InHdValue8 { get; private set; }
    public float InHdValue9 { get; private set; }
    public string MeasDtSrValue1 { get; private set; }
    public string MeasDtSrValue2 { get; private set; }
    public string MeasDtSrValue3 { get; private set; }
    public string MeasDtSrValue4 { get; private set; }
    public string MeasDtSrValue5 { get; private set; }
    public string MeasDtSrValue6 { get; private set; }
    public string MeasDtSrValue7 { get; private set; }
    public string MeasDtSrValue8 { get; private set; }
    public string MeasDtSrValue9 { get; private set; }
    //�����ڵ庰 �����͸� �ҷ��������� ���� ����.Canvas�� �������г� ������ġ�� ���� ����
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

        // null üũ�� �߰��Ͽ� ������ null�� �ƴ� ��쿡�� ���� �����մϴ�.
        if (noText != null && data.ContainsKey("no"))
            noText.text = data["no"]; // Code Ű�� ������ �ִ� ���� ���

        if (speciesText != null && data.ContainsKey("species"))
            speciesText.text = data["species"];

        if (companyText != null && data.ContainsKey("company"))
            companyText.text = data["company"];
    }

    public void Start()
    {
        // ��ũ��Ʈ���� Scroll View ã�Ƽ� �Ҵ�
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

    }

    public void Update()
    {

    }

    IEnumerator GetApiData()
    {

        apiUrl = $"<http://apis.data.go.kr/1390000/SmartFarmdata/envdatarqst?serviceKey=ndExmAZPa6Z1SBWydoZsH8RFcdL6XjiFlmZ4Qe0LVdu6WyGJJpkvYMB5ecMII4AIXi0P%2BYcuqLKslBw6ILFgbA%3D%3D&searchFrmhsCode={formid}&returnType=json>";
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

                    if (i == 9) // ������ 10��° ǰ���� ���
                    {
                        InTpValue10 = measurementItem.inTp;
                        InHdValue10 = measurementItem.inHd;
                        FrmhsIdValue = measurementItem.frmhsId;
                        OutWsValue10 = measurementItem.outWs;
                        MeasDtSrValue10 = measurementItem.measDtStr;
                        OutTpValue10 = measurementItem.outTp;
                        InCo2Value10 = measurementItem.inCo2;
                    }
                    else // ������ 10��° ǰ���� ������ ���
                    {
                        // ������ ǰ��鿡 ���ؼ��� ���� �ٸ� ������ ���� ����
                        switch (i)
                        {
                            case 0:
                                InTpValue1 = measurementItem.inTp;
                                InHdValue1 = measurementItem.inHd;
                                MeasDtSrValue1 = measurementItem.measDtStr;
                                Debug.Log(InTpValue1);
                                break;
                            case 1:
                                InTpValue2 = measurementItem.inTp;
                                InHdValue2 = measurementItem.inHd;
                                MeasDtSrValue2 = measurementItem.measDtStr;
                                Debug.Log(InTpValue2);
                                break;
                            case 2:
                                InTpValue3 = measurementItem.inTp;
                                InHdValue3 = measurementItem.inHd;
                                MeasDtSrValue3 = measurementItem.measDtStr;
                                Debug.Log(InTpValue3);
                                break;
                            case 3:
                                InTpValue4 = measurementItem.inTp;
                                InHdValue4 = measurementItem.inHd;
                                MeasDtSrValue4 = measurementItem.measDtStr;
                                break;
                            case 4:
                                InTpValue5 = measurementItem.inTp;
                                InHdValue5 = measurementItem.inHd;
                                MeasDtSrValue5 = measurementItem.measDtStr;
                                break;
                            case 5:
                                InTpValue6 = measurementItem.inTp;
                                InHdValue6 = measurementItem.inHd;
                                MeasDtSrValue6 = measurementItem.measDtStr;
                                break;
                            case 6:
                                InTpValue7 = measurementItem.inTp;
                                InHdValue7 = measurementItem.inHd;
                                MeasDtSrValue7 = measurementItem.measDtStr;
                                break;
                            case 7:
                                InTpValue8 = measurementItem.inTp;
                                InHdValue8 = measurementItem.inHd;
                                MeasDtSrValue8 = measurementItem.measDtStr;
                                break;
                            case 8:
                                InTpValue9 = measurementItem.inTp;
                                InHdValue9 = measurementItem.inHd;
                                MeasDtSrValue9 = measurementItem.measDtStr;
                                break;
                            // ������ ǰ��鿡 ���ؼ��� �����ϰ� ó��
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
                            textComponent.text = $"InTp: {InTpValue10}";
                            break;
                        case "InHdText":
                            textComponent.text = $"InHd: {InHdValue10}";
                            break;
                        case "FrmhsIdText":
                            textComponent.text = $"FrmhsId: {FrmhsIdValue}";
                            break;
                        case "OutWsText":
                            textComponent.text = $"OutWs: {OutWsValue10}";
                            break;
                        case "MeasDtStrText":
                            textComponent.text = $"MeasDtStr: {MeasDtSrValue10}";
                            break;
                        case "OutTpText":
                            textComponent.text = $"OutTp: {OutTpValue10}";
                            break;
                        case "InCo2Text":
                            textComponent.text = $"InCo2: {InCo2Value10}";
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