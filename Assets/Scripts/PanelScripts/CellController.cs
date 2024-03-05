using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

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
    [SerializeField] TextMeshProUGUI noText;//���ڵ�
    [SerializeField] TextMeshProUGUI speciesText;
    [SerializeField] TextMeshProUGUI companyText;
    [SerializeField] GameObject detailPanel;



    //�޾ƿ� ������ ������ �гο� �������� ����. ������ �������� �ҷ��� 10��° ������
    public static string FrmhsIdValue { get; private set; }
    public static float OutWsValue10 { get; private set; }
    public static float OutTpValue10 { get; private set; }
    public static float InCo2Value10 { get; private set; }
    public static float InTpValue10 { get; private set; }
    public static float InHdValue10 { get; private set; }
    public static string MeasDtSrValue10 { get; private set; }
    //ù��° ���� ��ȩ��° ������ ���� ���οµ�,���ν���,�����Ͻ� 3���� ������ ����.(�׷����� ����ϱ�����)
    /// <summary>
    /// �Ʒ� value1 staitc�������� ������. ���ĳ������͵鵵 static�� ����� �Ǳ��ҵ�
    /// </summary>
    public static float InTpValue1 { get; private set; }
    public static float InTpValue2 { get; private set; }
    public static float InTpValue3 { get; private set; }
    public static float InTpValue4 { get; private set; }
    public static float InTpValue5 { get; private set; }
    public static float InTpValue6 { get; private set; }
    public static float InTpValue7 { get; private set; }
    public static float InTpValue8 { get; private set; }
    public static float InTpValue9 { get; private set; }
    public static float InHdValue1 { get; private set; }
    public static float InHdValue2 { get; private set; }
    public static float InHdValue3 { get; private set; }
    public static float InHdValue4 { get; private set; }
    public static float InHdValue5 { get; private set; }
    public static float InHdValue6 { get; private set; }
    public static float InHdValue7 { get; private set; }
    public static float InHdValue8 { get; private set; }
    public static float InHdValue9 { get; private set; }
    public static string MeasDtSrValue1 { get; private set; }
    public static string MeasDtSrValue2 { get; private set; }
    public static string MeasDtSrValue3 { get; private set; }
    public static string MeasDtSrValue4 { get; private set; }
    public static string MeasDtSrValue5 { get; private set; }
    public static string MeasDtSrValue6 { get; private set; }
    public static string MeasDtSrValue7 { get; private set; }
    public static string MeasDtSrValue8 { get; private set; }
    public static string MeasDtSrValue9 { get; private set; }

    public static float OutWsValue1 { get; private set; }
    public static float OutWsValue2 { get; private set; }
    public static float OutWsValue3 { get; private set; }
    public static float OutWsValue4 { get; private set; }
    public static float OutWsValue5 { get; private set; }
    public static float OutWsValue6 { get; private set; }
    public static float OutWsValue7 { get; private set; }
    public static float OutWsValue8 { get; private set; }
    public static float OutWsValue9 { get; private set; }

    public static float OutTpValue1 { get; private set; }
    public static float OutTpValue2 { get; private set; }
    public static float OutTpValue3 { get; private set; }
    public static float OutTpValue4 { get; private set; }
    public static float OutTpValue5 { get; private set; }
    public static float OutTpValue6 { get; private set; }
    public static float OutTpValue7 { get; private set; }
    public static float OutTpValue8 { get; private set; }
    public static float OutTpValue9 { get; private set; }

    public static float InCo2Value1 { get; private set; }
    public static float InCo2Value2 { get; private set; }
    public static float InCo2Value3 { get; private set; }
    public static float InCo2Value4 { get; private set; }
    public static float InCo2Value5 { get; private set; }
    public static float InCo2Value6 { get; private set; }
    public static float InCo2Value7 { get; private set; }
    public static float InCo2Value8 { get; private set; }
    public static float InCo2Value9 { get; private set; }
    //�����ڵ庰 �����͸� �ҷ��������� ���� ����.Canvas�� �������г� ������ġ�� ���� ����
    private string apiUrl;
    public string formid;
    Canvas canvas;
    //������ ������ �ٷ� ������ ǥ���� �Ŷ�� cell���� ������ ���� ���� �־�����
 

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
                Transform panelInTmp = detailPanel.transform.Find("Panel_InTmp");
                Transform panelInHum  = detailPanel.transform.Find("Panel_InHum");

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
                                OutWsValue1 = measurementItem.outWs;
                                OutTpValue1 = measurementItem.outTp;
                                InCo2Value1 = measurementItem.inCo2;
                                Debug.Log($"Mes : {MeasDtSrValue1}, outws : {OutWsValue1}, InCo2 : {InCo2Value1}, outTp : {OutTpValue1}");
                                break;
                            case 1:
                                InTpValue2 = measurementItem.inTp;
                                InHdValue2 = measurementItem.inHd;
                                MeasDtSrValue2 = measurementItem.measDtStr;
                                OutWsValue2 = measurementItem.outWs;
                                OutTpValue2 = measurementItem.outTp;
                                InCo2Value2 = measurementItem.inCo2;
                                Debug.Log($"Mes : {MeasDtSrValue2}, outws : {OutWsValue2}, InCo2 : {InCo2Value2}, outTp : {OutTpValue2}");
                                break;
                            case 2:
                                InTpValue3 = measurementItem.inTp;
                                InHdValue3 = measurementItem.inHd;
                                MeasDtSrValue3 = measurementItem.measDtStr;
                                OutWsValue3 = measurementItem.outWs;
                                OutTpValue3 = measurementItem.outTp;
                                InCo2Value3 = measurementItem.inCo2;
                                Debug.Log($"Mes : {MeasDtSrValue3}, outws : {OutWsValue3}, InCo2 : {InCo2Value3}, outTp : {OutTpValue3}");
                                break;
                            case 3:
                                InTpValue4 = measurementItem.inTp;
                                InHdValue4 = measurementItem.inHd;
                                MeasDtSrValue4 = measurementItem.measDtStr;
                                OutWsValue4 = measurementItem.outWs;
                                OutTpValue4 = measurementItem.outTp;
                                InCo2Value4 = measurementItem.inCo2;
                                break;
                            case 4:
                                InTpValue5 = measurementItem.inTp;
                                InHdValue5 = measurementItem.inHd;
                                MeasDtSrValue5 = measurementItem.measDtStr;
                                OutWsValue5 = measurementItem.outWs;
                                OutTpValue5 = measurementItem.outTp;
                                InCo2Value5 = measurementItem.inCo2;
                                break;
                            case 5:
                                InTpValue6 = measurementItem.inTp;
                                InHdValue6 = measurementItem.inHd;
                                MeasDtSrValue6 = measurementItem.measDtStr;
                                OutWsValue6 = measurementItem.outWs;
                                OutTpValue6 = measurementItem.outTp;
                                InCo2Value6 = measurementItem.inCo2;
                                break;
                            case 6:
                                InTpValue7 = measurementItem.inTp;
                                InHdValue7 = measurementItem.inHd;
                                MeasDtSrValue7 = measurementItem.measDtStr;
                                OutWsValue7 = measurementItem.outWs;
                                OutTpValue7 = measurementItem.outTp;
                                InCo2Value7 = measurementItem.inCo2;
                                break;
                            case 7:
                                InTpValue8 = measurementItem.inTp;
                                InHdValue8 = measurementItem.inHd;
                                MeasDtSrValue8 = measurementItem.measDtStr;
                                OutWsValue8 = measurementItem.outWs;
                                OutTpValue8 = measurementItem.outTp;
                                InCo2Value8 = measurementItem.inCo2;
                                break;
                            case 8:
                                InTpValue9 = measurementItem.inTp;
                                InHdValue9 = measurementItem.inHd;
                                MeasDtSrValue9 = measurementItem.measDtStr;
                                OutWsValue9 = measurementItem.outWs;
                                OutTpValue9 = measurementItem.outTp;
                                InCo2Value9 = measurementItem.inCo2;
                                break;
                            // ������ ǰ��鿡 ���ؼ��� �����ϰ� ó��
                            default:
                                Debug.LogWarning("Too many measurement items. Ignoring the excess items.");
                                break;
                        }
                             

                    if (panelInTmp != null)
                    {
                        // Panel_InTmp�� ������ �ִ� �ڽ� ������Ʈ �� �̸��� "InTmp_HorizontlaLayout"�� ������Ʈ ã��
                        Transform inTmpHorizontalLayout = panelInTmp.Find("InTmp_HorizontlaLayout");

                        if (inTmpHorizontalLayout != null)
                        {
                            // InTmp_HorizontlaLayout�� ������ �ִ� �ڽ� ������Ʈ �� �̸��� "Slider"�� ������Ʈ ã��
                            Transform sliderTransforma = inTmpHorizontalLayout.Find("Slider0");
                            Transform sliderTransformb = inTmpHorizontalLayout.Find("Slider1");
                            Transform sliderTransformc = inTmpHorizontalLayout.Find("Slider2");
                            Transform sliderTransformd = inTmpHorizontalLayout.Find("Slider3");
                            Transform sliderTransforme = inTmpHorizontalLayout.Find("Slider4");
                            Transform sliderTransformf = inTmpHorizontalLayout.Find("Slider5");
                            Transform sliderTransformg = inTmpHorizontalLayout.Find("Slider6");
                            Transform sliderTransformh = inTmpHorizontalLayout.Find("Slider7");
                            Transform sliderTransformi = inTmpHorizontalLayout.Find("Slider8");
                            Transform sliderTransformj = inTmpHorizontalLayout.Find("Slider9");

                             if (sliderTransforma != null)
                             {
                                // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                Slider sliderComponent = sliderTransforma.GetComponent<Slider>();

                                if (sliderComponent != null)
                                {
                                    sliderComponent.value = InTpValue1;
                                   
                                }
                                else
                                {
                                    Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                }
                             }
                            if (sliderTransformb != null)
                            {
                                // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                Slider sliderComponent1 = sliderTransformb.GetComponent<Slider>();
                                if (sliderComponent1 != null)
                                {
                                    sliderComponent1.value = InTpValue2;
                                    
                                }
                                else
                                {
                                    Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                }
                            }
                                if (sliderTransformc != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent2 = sliderTransformc.GetComponent<Slider>();

                                    if (sliderComponent2 != null)
                                    {
                                        sliderComponent2.value = InTpValue3;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformd != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent3 = sliderTransformd.GetComponent<Slider>();
                                    if (sliderComponent3 != null)
                                    {
                                        sliderComponent3.value = InTpValue4;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransforme != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent4 = sliderTransforme.GetComponent<Slider>();

                                    if (sliderComponent4 != null)
                                    {
                                        sliderComponent4.value = InTpValue5;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformf != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent5 = sliderTransformf.GetComponent<Slider>();
                                    if (sliderComponent5 != null)
                                    {
                                        sliderComponent5.value = InTpValue6;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformg != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent6 = sliderTransformg.GetComponent<Slider>();

                                    if (sliderComponent6 != null)
                                    {
                                        sliderComponent6.value = InTpValue7;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformh != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent7 = sliderTransformh.GetComponent<Slider>();
                                    if (sliderComponent7 != null)
                                    {
                                        sliderComponent7.value = InTpValue8;
                                       
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformi != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent8 = sliderTransformi.GetComponent<Slider>();

                                    if (sliderComponent8 != null)
                                    {
                                        sliderComponent8.value = InTpValue9;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformj != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent9 = sliderTransformj.GetComponent<Slider>();
                                    if (sliderComponent9 != null)
                                    {
                                        sliderComponent9.value = InTpValue10;
                                       
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }

                            }
                        else
                        {
                            Debug.LogError("Panel_InTmp�� �ڽ� ������Ʈ 'InTmp_HorizontlaLayout'�� ã�� �� �����ϴ�.");
                        }
                    }
                    else
                    {
                        Debug.LogError("detailPanel�� �ڽ� ������Ʈ 'Panel_InTmp'�� ã�� �� �����ϴ�.");
                    }
                        //���� ���� ���

                        if (panelInHum != null)
                        {
                            // Panel_InTmp�� ������ �ִ� �ڽ� ������Ʈ �� �̸��� "InHum_HorizontalLayout"�� ������Ʈ ã��
                            Transform inTmpHorizontalLayout = panelInHum.Find("InHum_HorizontalLayout");

                            if (inTmpHorizontalLayout != null)
                            {
                                // InTmp_HorizontlaLayout�� ������ �ִ� �ڽ� ������Ʈ �� �̸��� "Slider"�� ������Ʈ ã��
                                Transform sliderTransforma = inTmpHorizontalLayout.Find("Slider0");
                                Transform sliderTransformb = inTmpHorizontalLayout.Find("Slider1");
                                Transform sliderTransformc = inTmpHorizontalLayout.Find("Slider2");
                                Transform sliderTransformd = inTmpHorizontalLayout.Find("Slider3");
                                Transform sliderTransforme = inTmpHorizontalLayout.Find("Slider4");
                                Transform sliderTransformf = inTmpHorizontalLayout.Find("Slider5");
                                Transform sliderTransformg = inTmpHorizontalLayout.Find("Slider6");
                                Transform sliderTransformh = inTmpHorizontalLayout.Find("Slider7");
                                Transform sliderTransformi = inTmpHorizontalLayout.Find("Slider8");
                                Transform sliderTransformj = inTmpHorizontalLayout.Find("Slider9");

                                if (sliderTransforma != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent = sliderTransforma.GetComponent<Slider>();

                                    if (sliderComponent != null)
                                    {
                                        sliderComponent.value = InHdValue1;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformb != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent1 = sliderTransformb.GetComponent<Slider>();
                                    if (sliderComponent1 != null)
                                    {
                                        sliderComponent1.value = InHdValue2;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformc != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent2 = sliderTransformc.GetComponent<Slider>();

                                    if (sliderComponent2 != null)
                                    {
                                        sliderComponent2.value = InHdValue3;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformd != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent3 = sliderTransformd.GetComponent<Slider>();
                                    if (sliderComponent3 != null)
                                    {
                                        sliderComponent3.value = InHdValue4;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransforme != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent4 = sliderTransforme.GetComponent<Slider>();

                                    if (sliderComponent4 != null)
                                    {
                                        sliderComponent4.value = InHdValue5;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformf != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent5 = sliderTransformf.GetComponent<Slider>();
                                    if (sliderComponent5 != null)
                                    {
                                        sliderComponent5.value = InHdValue6;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformg != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent6 = sliderTransformg.GetComponent<Slider>();

                                    if (sliderComponent6 != null)
                                    {
                                        sliderComponent6.value = InHdValue7;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformh != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent7 = sliderTransformh.GetComponent<Slider>();
                                    if (sliderComponent7 != null)
                                    {
                                        sliderComponent7.value = InHdValue8;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformi != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent8 = sliderTransformi.GetComponent<Slider>();

                                    if (sliderComponent8 != null)
                                    {
                                        sliderComponent8.value = InHdValue9;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }
                                if (sliderTransformj != null)
                                {
                                    // Slider ������Ʈ �������� (��: Slider ������Ʈ�� ���� �����ϰų� �̺�Ʈ�� ������ �� ����)
                                    Slider sliderComponent9 = sliderTransformj.GetComponent<Slider>();
                                    if (sliderComponent9 != null)
                                    {
                                        sliderComponent9.value = InHdValue10;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider ������Ʈ�� ã�� �� �����ϴ�.");
                                    }
                                }

                            }
                            else
                            {
                                Debug.LogError("Panel_InTmp�� �ڽ� ������Ʈ 'InTmp_HorizontlaLayout'�� ã�� �� �����ϴ�.");
                            }
                        }
                        else
                        {
                            Debug.LogError("detailPanel�� �ڽ� ������Ʈ 'Panel_InTmp'�� ã�� �� �����ϴ�.");
                        }
                    }
                    
                }

                GameObject instantiatedPanel = Instantiate(detailPanel, canvas.transform);

                TextMeshProUGUI[] textComponents = instantiatedPanel.GetComponentsInChildren<TextMeshProUGUI>();

                /* �Ⱦ��� �κ�
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
                        case "OutWsText":
                            textComponent.text = $"OutWs: {OutWsValue10}";
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
                */
            }
        }
    }

    public void OnClickButton()
    {
        formid = noText.text;
        StartCoroutine(GetApiData());
    }
}