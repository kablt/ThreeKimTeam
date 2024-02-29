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
    Canvas canvas;






    void Awake()
    {
        //// �ؽ�Ʈ �ʱ�ȭ
        //noText.text = "";
        //speciesText.text = "";
        //companyText.text = "";
        // �������� null ���� Ȯ���ϰ� null �� �ƴϸ� �ؽ�Ʈ�� �ʱ�ȭ
        if (noText != null)
            noText.text = "";
        if (speciesText != null)
            speciesText.text = "";
        if (companyText != null)
            companyText.text = "";

    }

    public void SetData(Dictionary<string, string> data)
    {
        //noText.text = data["no"]; // Code Ű�� ������ �ִ� ���� ���
        //speciesText.text = data["species"];
        //companyText.text = data["company"];

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

                foreach (var measurementItem in jsonResponse.response.body.items.item)
                {
                    InTpValue = measurementItem.inTp;
                    InHdValue = measurementItem.inHd;
                    FrmhsIdValue = measurementItem.frmhsId;
                    OutWsValue = measurementItem.outWs;
                    MeasDtSrValue = measurementItem.measDtStr;
                    OutTpValue = measurementItem.outTp;
                    InCo2Value = measurementItem.inCo2;
                }
            }

            Debug.Log($"inTp: {InTpValue}, inHd: {InHdValue}, frmhsId: {FrmhsIdValue}, measDtStr: {MeasDtSrValue}, outWs: {OutWsValue}, outTp: {OutTpValue}, inCo2: {InCo2Value}");

            // Instantiate the detailPanel prefab
            GameObject instantiatedPanel = Instantiate(detailPanel, canvas.transform);  // Assuming scrollView is the Scroll View in your scene

            // Access TextMeshProUGUI components in the instantiatedPanel and update their values
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
        }
    }
    public void OnClickButton()
    {
        formid = noText.text;
        // Fetch API data when the button is clicked
        StartCoroutine(GetApiData());
        // Instantiate the detailPanel prefab

    }
}