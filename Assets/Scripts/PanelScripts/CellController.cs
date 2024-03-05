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
    [SerializeField] TextMeshProUGUI noText;//농가코드
    [SerializeField] TextMeshProUGUI speciesText;
    [SerializeField] TextMeshProUGUI companyText;
    [SerializeField] GameObject detailPanel;



    //받아온 데이터 디테일 패널에 쓰기위해 저장. 위에건 마지막에 불러온 10번째 데이터
    public static string FrmhsIdValue { get; private set; }
    public static float OutWsValue10 { get; private set; }
    public static float OutTpValue10 { get; private set; }
    public static float InCo2Value10 { get; private set; }
    public static float InTpValue10 { get; private set; }
    public static float InHdValue10 { get; private set; }
    public static string MeasDtSrValue10 { get; private set; }
    //첫번째 부터 아홉번째 데이터 까지 내부온도,내부습도,측정일시 3가지 데이터 저장.(그래프에 사용하기위해)
    /// <summary>
    /// 아래 value1 staitc선언으로 값전달. 이후나머지것들도 static로 만들면 되긴할듯
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
    //농장코드별 데이터를 불러오기위한 변수 선언.Canvas는 디테일패널 생성위치를 위해 선언
    private string apiUrl;
    public string formid;
    Canvas canvas;
    //디테일 생성시 바로 정보를 표기할 거라면 cell에서 변수를 만들어서 값을 넣어주자
 

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
                Transform panelInTmp = detailPanel.transform.Find("Panel_InTmp");
                Transform panelInHum  = detailPanel.transform.Find("Panel_InHum");

                for (int i = 0; i < jsonResponse.response.body.items.item.Length; i++)
                {
                    MeasurementItem measurementItem = jsonResponse.response.body.items.item[i];

                    if (i == 9) // 마지막 10번째 품목인 경우
                    {
                        InTpValue10 = measurementItem.inTp;
                        InHdValue10 = measurementItem.inHd;
                        FrmhsIdValue = measurementItem.frmhsId;
                        OutWsValue10 = measurementItem.outWs;
                        MeasDtSrValue10 = measurementItem.measDtStr;
                        OutTpValue10 = measurementItem.outTp;
                        InCo2Value10 = measurementItem.inCo2;
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
                            // 나머지 품목들에 대해서도 동일하게 처리
                            default:
                                Debug.LogWarning("Too many measurement items. Ignoring the excess items.");
                                break;
                        }
                             

                    if (panelInTmp != null)
                    {
                        // Panel_InTmp이 가지고 있는 자식 오브젝트 중 이름이 "InTmp_HorizontlaLayout"인 오브젝트 찾기
                        Transform inTmpHorizontalLayout = panelInTmp.Find("InTmp_HorizontlaLayout");

                        if (inTmpHorizontalLayout != null)
                        {
                            // InTmp_HorizontlaLayout이 가지고 있는 자식 오브젝트 중 이름이 "Slider"인 오브젝트 찾기
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
                                // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                Slider sliderComponent = sliderTransforma.GetComponent<Slider>();

                                if (sliderComponent != null)
                                {
                                    sliderComponent.value = InTpValue1;
                                   
                                }
                                else
                                {
                                    Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                }
                             }
                            if (sliderTransformb != null)
                            {
                                // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                Slider sliderComponent1 = sliderTransformb.GetComponent<Slider>();
                                if (sliderComponent1 != null)
                                {
                                    sliderComponent1.value = InTpValue2;
                                    
                                }
                                else
                                {
                                    Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                }
                            }
                                if (sliderTransformc != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent2 = sliderTransformc.GetComponent<Slider>();

                                    if (sliderComponent2 != null)
                                    {
                                        sliderComponent2.value = InTpValue3;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformd != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent3 = sliderTransformd.GetComponent<Slider>();
                                    if (sliderComponent3 != null)
                                    {
                                        sliderComponent3.value = InTpValue4;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransforme != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent4 = sliderTransforme.GetComponent<Slider>();

                                    if (sliderComponent4 != null)
                                    {
                                        sliderComponent4.value = InTpValue5;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformf != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent5 = sliderTransformf.GetComponent<Slider>();
                                    if (sliderComponent5 != null)
                                    {
                                        sliderComponent5.value = InTpValue6;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformg != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent6 = sliderTransformg.GetComponent<Slider>();

                                    if (sliderComponent6 != null)
                                    {
                                        sliderComponent6.value = InTpValue7;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformh != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent7 = sliderTransformh.GetComponent<Slider>();
                                    if (sliderComponent7 != null)
                                    {
                                        sliderComponent7.value = InTpValue8;
                                       
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformi != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent8 = sliderTransformi.GetComponent<Slider>();

                                    if (sliderComponent8 != null)
                                    {
                                        sliderComponent8.value = InTpValue9;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformj != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent9 = sliderTransformj.GetComponent<Slider>();
                                    if (sliderComponent9 != null)
                                    {
                                        sliderComponent9.value = InTpValue10;
                                       
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }

                            }
                        else
                        {
                            Debug.LogError("Panel_InTmp의 자식 오브젝트 'InTmp_HorizontlaLayout'을 찾을 수 없습니다.");
                        }
                    }
                    else
                    {
                        Debug.LogError("detailPanel의 자식 오브젝트 'Panel_InTmp'을 찾을 수 없습니다.");
                    }
                        //습도 넣을 장소

                        if (panelInHum != null)
                        {
                            // Panel_InTmp이 가지고 있는 자식 오브젝트 중 이름이 "InHum_HorizontalLayout"인 오브젝트 찾기
                            Transform inTmpHorizontalLayout = panelInHum.Find("InHum_HorizontalLayout");

                            if (inTmpHorizontalLayout != null)
                            {
                                // InTmp_HorizontlaLayout이 가지고 있는 자식 오브젝트 중 이름이 "Slider"인 오브젝트 찾기
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
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent = sliderTransforma.GetComponent<Slider>();

                                    if (sliderComponent != null)
                                    {
                                        sliderComponent.value = InHdValue1;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformb != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent1 = sliderTransformb.GetComponent<Slider>();
                                    if (sliderComponent1 != null)
                                    {
                                        sliderComponent1.value = InHdValue2;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformc != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent2 = sliderTransformc.GetComponent<Slider>();

                                    if (sliderComponent2 != null)
                                    {
                                        sliderComponent2.value = InHdValue3;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformd != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent3 = sliderTransformd.GetComponent<Slider>();
                                    if (sliderComponent3 != null)
                                    {
                                        sliderComponent3.value = InHdValue4;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransforme != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent4 = sliderTransforme.GetComponent<Slider>();

                                    if (sliderComponent4 != null)
                                    {
                                        sliderComponent4.value = InHdValue5;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformf != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent5 = sliderTransformf.GetComponent<Slider>();
                                    if (sliderComponent5 != null)
                                    {
                                        sliderComponent5.value = InHdValue6;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformg != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent6 = sliderTransformg.GetComponent<Slider>();

                                    if (sliderComponent6 != null)
                                    {
                                        sliderComponent6.value = InHdValue7;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformh != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent7 = sliderTransformh.GetComponent<Slider>();
                                    if (sliderComponent7 != null)
                                    {
                                        sliderComponent7.value = InHdValue8;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformi != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent8 = sliderTransformi.GetComponent<Slider>();

                                    if (sliderComponent8 != null)
                                    {
                                        sliderComponent8.value = InHdValue9;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }
                                if (sliderTransformj != null)
                                {
                                    // Slider 컴포넌트 가져오기 (예: Slider 컴포넌트로 값을 조작하거나 이벤트를 연결할 수 있음)
                                    Slider sliderComponent9 = sliderTransformj.GetComponent<Slider>();
                                    if (sliderComponent9 != null)
                                    {
                                        sliderComponent9.value = InHdValue10;
                                        
                                    }
                                    else
                                    {
                                        Debug.LogError("Slider 컴포넌트를 찾을 수 없습니다.");
                                    }
                                }

                            }
                            else
                            {
                                Debug.LogError("Panel_InTmp의 자식 오브젝트 'InTmp_HorizontlaLayout'을 찾을 수 없습니다.");
                            }
                        }
                        else
                        {
                            Debug.LogError("detailPanel의 자식 오브젝트 'Panel_InTmp'을 찾을 수 없습니다.");
                        }
                    }
                    
                }

                GameObject instantiatedPanel = Instantiate(detailPanel, canvas.transform);

                TextMeshProUGUI[] textComponents = instantiatedPanel.GetComponentsInChildren<TextMeshProUGUI>();

                /* 안쓰는 부분
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