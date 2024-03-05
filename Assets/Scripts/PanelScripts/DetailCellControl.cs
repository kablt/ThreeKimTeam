using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailCellControl : MonoBehaviour
{
    [SerializeField] TMP_Text inTp;
    [SerializeField] TMP_Text inHd;
    [SerializeField] TMP_Text frmhsId;
    [SerializeField] TMP_Text outWs;
    [SerializeField] TMP_Text outTp;
    [SerializeField] TMP_Text inCo2;
    //그래프 아래 버튼 측정일수
    [SerializeField] TMP_Text mday1;
    [SerializeField] TMP_Text mday2;
    [SerializeField] TMP_Text mday3;
    [SerializeField] TMP_Text mday4;
    [SerializeField] TMP_Text mday5;
    [SerializeField] TMP_Text mday6;
    [SerializeField] TMP_Text mday7;
    [SerializeField] TMP_Text mday8;
    [SerializeField] TMP_Text mday9;
    [SerializeField] TMP_Text mday10;
    public CellController cellControl;
    [SerializeField] GameObject exittap;
    [SerializeField] TMP_Text SunSideOutTp;
    [SerializeField] TMP_Text RightUpDtr;
    [SerializeField] Slider Co2Slider;
    Canvas canvas;
    public string ymd;
    //co2패널 비활성화
    public GameObject MainPanel;


    //그래프 슬라이더의 Value값에 지정된 변수 넣기



    public void OnClickCloseButton()
    {
        DropdownManager.ActiveButton = true;
        Destroy(gameObject);
    }
          
    public void OnClickChangeOne(float num)
    {
  
        if(num == 1)
        {
            //cellcontroller에서 저장된값 static로 선언 
            inTp.text = (Mathf.Round(CellController.InTpValue1 * 10f) / 10f).ToString() + "°C";
            inHd.text = (Mathf.Round(CellController.InHdValue1 * 10f) / 10f).ToString() + "%";
            outWs.text = (Mathf.Round(CellController.OutWsValue1 * 10f) / 10f).ToString() + "m/s";
            outTp.text = (Mathf.Round(CellController.OutTpValue1 * 10f) / 10f).ToString() + "°C";
            SunSideOutTp.text = (Mathf.Round(CellController.OutTpValue1 * 10f) / 10f).ToString() + "°C";
            inCo2.text = Mathf.RoundToInt(CellController.InCo2Value1).ToString();
            Co2Slider.value = Mathf.RoundToInt(CellController.InCo2Value1);
        }
        else if (num ==2)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue2 * 10f) / 10f).ToString() + "°C";
            inHd.text = (Mathf.Round(CellController.InHdValue2 * 10f) / 10f).ToString() + "%";
            outWs.text = (Mathf.Round(CellController.OutWsValue2 * 10f) / 10f).ToString() + "m/s";
            outTp.text = (Mathf.Round(CellController.OutTpValue2 * 10f) / 10f).ToString() + "°C";
            SunSideOutTp.text = (Mathf.Round(CellController.OutTpValue2 * 10f) / 10f).ToString() + "°C";
            inCo2.text = Mathf.RoundToInt(CellController.InCo2Value2).ToString();
            Co2Slider.value = Mathf.RoundToInt(CellController.InCo2Value2);
        }
        else if(num == 3)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue3 * 10f) / 10f).ToString() + "°C";
            inHd.text = (Mathf.Round(CellController.InHdValue3 * 10f) / 10f).ToString() + "%";
            outWs.text = (Mathf.Round(CellController.OutWsValue3 * 10f) / 10f).ToString() + "m/s";
            outTp.text = (Mathf.Round(CellController.OutTpValue3 * 10f) / 10f).ToString() + "°C";
            SunSideOutTp.text = (Mathf.Round(CellController.OutTpValue3 * 10f) / 10f).ToString() + "°C";
            inCo2.text = Mathf.RoundToInt(CellController.InCo2Value3).ToString();
            Co2Slider.value = Mathf.RoundToInt(CellController.InCo2Value3);
        }
        else if (num == 4)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue4 * 10f) / 10f).ToString() + "°C";
            inHd.text = (Mathf.Round(CellController.InHdValue4 * 10f) / 10f).ToString() + "%";
            outWs.text = (Mathf.Round(CellController.OutWsValue4 * 10f) / 10f).ToString() + "m/s";
            outTp.text = (Mathf.Round(CellController.OutTpValue4 * 10f) / 10f).ToString() + "°C";
            SunSideOutTp.text = (Mathf.Round(CellController.OutTpValue4 * 10f) / 10f).ToString() + "°C";
            inCo2.text = Mathf.RoundToInt(CellController.InCo2Value4).ToString();
            Co2Slider.value = Mathf.RoundToInt(CellController.InCo2Value4);
        }
        else if (num == 5)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue5 * 10f) / 10f).ToString() + "°C";
            inHd.text = (Mathf.Round(CellController.InHdValue5 * 10f) / 10f).ToString() + "%";
            outWs.text = (Mathf.Round(CellController.OutWsValue5 * 10f) / 10f).ToString() + "m/s";
            outTp.text = (Mathf.Round(CellController.OutTpValue5 * 10f) / 10f).ToString() + "°C";
            SunSideOutTp.text = (Mathf.Round(CellController.OutTpValue5 * 10f) / 10f).ToString() + "°C";
            inCo2.text = Mathf.RoundToInt(CellController.InCo2Value5).ToString();
            Co2Slider.value = Mathf.RoundToInt(CellController.InCo2Value5);
        }
        else if (num == 6)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue6 * 10f) / 10f).ToString() + "°C";
            inHd.text = (Mathf.Round(CellController.InHdValue6 * 10f) / 10f).ToString() + "%";
            outWs.text = (Mathf.Round(CellController.OutWsValue6 * 10f) / 10f).ToString() + "m/s";
            outTp.text = (Mathf.Round(CellController.OutTpValue6 * 10f) / 10f).ToString() + "°C";
            SunSideOutTp.text = (Mathf.Round(CellController.OutTpValue6 * 10f) / 10f).ToString() + "°C";
            inCo2.text = Mathf.RoundToInt(CellController.InCo2Value6).ToString();
            Co2Slider.value = Mathf.RoundToInt(CellController.InCo2Value6);
        }
        else if (num == 7)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue7 * 10f) / 10f).ToString() + "°C";
            inHd.text = (Mathf.Round(CellController.InHdValue7 * 10f) / 10f).ToString() + "%";
            outWs.text = (Mathf.Round(CellController.OutWsValue7 * 10f) / 10f).ToString() + "m/s";
            outTp.text = (Mathf.Round(CellController.OutTpValue7 * 10f) / 10f).ToString() + "°C";
            SunSideOutTp.text = (Mathf.Round(CellController.OutTpValue7 * 10f) / 10f).ToString() + "°C";
            inCo2.text = Mathf.RoundToInt(CellController.InCo2Value7).ToString();
            Co2Slider.value = Mathf.RoundToInt(CellController.InCo2Value7);
        }
        else if (num == 8)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue8 * 10f) / 10f).ToString() + "°C";
            inHd.text = (Mathf.Round(CellController.InHdValue8 * 10f) / 10f).ToString() + "%";
            outWs.text = (Mathf.Round(CellController.OutWsValue8 * 10f) / 10f).ToString() + "m/s";
            outTp.text = (Mathf.Round(CellController.OutTpValue8 * 10f) / 10f).ToString() + "°C";
            SunSideOutTp.text = (Mathf.Round(CellController.OutTpValue8 * 10f) / 10f).ToString() + "°C";
            inCo2.text = Mathf.RoundToInt(CellController.InCo2Value8).ToString();
            Co2Slider.value = Mathf.RoundToInt(CellController.InCo2Value8);
        }
        else if (num == 9)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue9 * 10f) / 10f).ToString() + "°C";
            inHd.text = (Mathf.Round(CellController.InHdValue9 * 10f) / 10f).ToString() + "%";
            outWs.text = (Mathf.Round(CellController.OutWsValue9 * 10f) / 10f).ToString() + "m/s";
            outTp.text = (Mathf.Round(CellController.OutTpValue9 * 10f) / 10f).ToString() + "°C";
            SunSideOutTp.text = (Mathf.Round(CellController.OutTpValue9 * 10f) / 10f).ToString() + "°C";
            inCo2.text = Mathf.RoundToInt(CellController.InCo2Value9).ToString();
            Co2Slider.value = Mathf.RoundToInt(CellController.InCo2Value9);
        }
        else
        {
            inTp.text = (Mathf.Round(CellController.InTpValue10 * 10f) / 10f).ToString() + "°C";
            inHd.text = (Mathf.Round(CellController.InHdValue10 * 10f) / 10f).ToString() + "%";
            outWs.text = (Mathf.Round(CellController.OutWsValue10 * 10f) / 10f).ToString() + "m/s";
            outTp.text = (Mathf.Round(CellController.OutTpValue10 * 10f) / 10f).ToString() + "°C";
            SunSideOutTp.text = (Mathf.Round(CellController.OutTpValue10 * 10f) / 10f).ToString() + "°C";
            inCo2.text = Mathf.RoundToInt(CellController.InCo2Value10).ToString();
            Co2Slider.value = Mathf.RoundToInt(CellController.InCo2Value10);
        }

    }

    void Start()
    {
        Co2Slider.value = 0f;
        ymd = CellController.MeasDtSrValue10.ToString();
        DropdownManager.ActiveButton = false;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        //처음 생성시 정보. 그것은 10번쨰 데이터!
        //그래프 아래에 넣을 시간. 이거근데 너무 길어서 보기 흉함. 그걸 시간만 보여주는걸로 줄임
        RightUpDtr.text = ymd.Substring(0, 4) + "년" + ymd.Substring(4, 2) + "월" + ymd.Substring(6, 2) + "일";
        mday1.text = CellController.MeasDtSrValue1.Substring(8,2);
        mday2.text = CellController.MeasDtSrValue2.Substring(8, 2);
        mday3.text = CellController.MeasDtSrValue3.Substring(8, 2);
        mday4.text = CellController.MeasDtSrValue4.Substring(8, 2);
        mday5.text = CellController.MeasDtSrValue5.Substring(8, 2);
        mday6.text = CellController.MeasDtSrValue6.Substring(8, 2);
        mday7.text = CellController.MeasDtSrValue7.Substring(8, 2);
        mday8.text = CellController.MeasDtSrValue8.Substring(8, 2);
        mday9.text = CellController.MeasDtSrValue9.Substring(8, 2);
        mday10.text = CellController.MeasDtSrValue10.Substring(8, 2);
    }

    public void ExitButton()
    {
        Instantiate(exittap,canvas.transform);
    }

    void Update()
    {
        
    }
}