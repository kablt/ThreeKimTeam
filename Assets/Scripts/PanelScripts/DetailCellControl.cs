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
    Canvas canvas;



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
            inTp.text = "내부온도 :" + Mathf.Round(CellController.InTpValue1*10f)/10f;
            inHd.text = "내부습도 :" + Mathf.Round(CellController.InHdValue1*10f)/10f;
            outWs.text = "풍속 :" + Mathf.Round(CellController.OutWsValue1*10f)/10f;
            outTp.text = "외부 온도 : " + Mathf.Round(CellController.OutTpValue1*10f)/10f;
            inCo2.text = "Co2농도 :" + Mathf.Round(CellController.InCo2Value1*10f)/10f;
        }
        else if (num ==2)
        {
            inTp.text = "내부온도 :" + CellController.InTpValue2;
            inHd.text = "내부습도 :" + CellController.InHdValue2;
            outWs.text = "풍속 :" + CellController.OutWsValue2;
            outTp.text = "외부 온도 : " + CellController.OutTpValue2;
            inCo2.text = "Co2농도 :" + CellController.InCo2Value2;
        }
        else if(num == 3)
        {
            inTp.text = "내부온도 :" + CellController.InTpValue3;
            inHd.text = "내부습도 :" + CellController.InHdValue3;
            outWs.text = "풍속 :" + CellController.OutWsValue3;
            outTp.text = "외부 온도 : " + CellController.OutTpValue3;
            inCo2.text = "Co2농도 :" + CellController.InCo2Value3;
        }
        else if (num == 4)
        {
            inTp.text = "내부온도 :" + CellController.InTpValue4;
            inHd.text = "내부습도 :" + CellController.InHdValue4;
            outWs.text = "풍속 :" + CellController.OutWsValue4;
            outTp.text = "외부 온도 : " + CellController.OutTpValue4;
            inCo2.text = "Co2농도 :" + CellController.InCo2Value4;
        }
        else if (num == 5)
        {
            inTp.text = "내부온도 :" + CellController.InTpValue5;
            inHd.text = "내부습도 :" + CellController.InHdValue5;
            outWs.text = "풍속 :" + CellController.OutWsValue5;
            outTp.text = "외부 온도 : " + CellController.OutTpValue5;
            inCo2.text = "Co2농도 :" + CellController.InCo2Value5;
        }
        else if (num == 6)
        {
            inTp.text = "내부온도 :" + CellController.InTpValue6;
            inHd.text = "내부습도 :" + CellController.InHdValue6;
            outWs.text = "풍속 :" + CellController.OutWsValue6;
            outTp.text = "외부 온도 : " + CellController.OutTpValue6;
            inCo2.text = "Co2농도 :" + CellController.InCo2Value6;
        }
        else if (num == 7)
        {
            inTp.text = "내부온도 :" + CellController.InTpValue7;
            inHd.text = "내부습도 :" + CellController.InHdValue7;
            outWs.text = "풍속 :" + CellController.OutWsValue7;
            outTp.text = "외부 온도 : " + CellController.OutTpValue7;
            inCo2.text = "Co2농도 :" + CellController.InCo2Value7;
        }
        else if (num == 8)
        {
            inTp.text = "내부온도 :" + CellController.InTpValue8;
            inHd.text = "내부습도 :" + CellController.InHdValue8;
            outWs.text = "풍속 :" + CellController.OutWsValue8;
            outTp.text = "외부 온도 : " + CellController.OutTpValue8;
            inCo2.text = "Co2농도 :" + CellController.InCo2Value8;
        }
        else if (num == 9)
        {
            inTp.text = "내부온도 :" + CellController.InTpValue9;
            inHd.text = "내부습도 :" + CellController.InHdValue9;
            outWs.text = "풍속 :" + CellController.OutWsValue9;
            outTp.text = "외부 온도 : " + CellController.OutTpValue9;
            inCo2.text = "Co2농도 :" + CellController.InCo2Value9;
        }
        else
        {
            inTp.text = "내부온도 :" + CellController.InTpValue10;
            inHd.text = "내부습도 :" + CellController.InHdValue10;
            outWs.text = "풍속 :" + CellController.OutWsValue10;
            outTp.text = "외부 온도 : " + CellController.OutTpValue10;
            inCo2.text = "Co2농도 :" + CellController.InCo2Value10;
        }

    }

    void Start()
    {
        DropdownManager.ActiveButton = false;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        //처음 생성시 정보. 그것은 10번쨰 데이터!
        inTp.text = "내부온도 :" + CellController.InTpValue10;
        inHd.text = "내부습도 :" + CellController.InHdValue10;
        outWs.text = "풍속 :" + CellController.OutWsValue10;
        outTp.text = "외부 온도 : " + CellController.OutTpValue10;
        inCo2.text = "Co2농도 :" + CellController.InCo2Value10;
        //그래프 아래에 넣을 시간. 이거근데 너무 길어서 보기 흉함.
        mday1.text = "측정시간 :" + CellController.MeasDtSrValue1;
        mday2.text = "측정시간 :" + CellController.MeasDtSrValue2;
        mday3.text = "측정시간 :" + CellController.MeasDtSrValue3;
        mday4.text = "측정시간 :" + CellController.MeasDtSrValue4;
        mday5.text = "측정시간 :" + CellController.MeasDtSrValue5;
        mday6.text = "측정시간 :" + CellController.MeasDtSrValue6;
        mday7.text = "측정시간 :" + CellController.MeasDtSrValue7;
        mday8.text = "측정시간 :" + CellController.MeasDtSrValue8;
        mday9.text = "측정시간 :" + CellController.MeasDtSrValue9;
        mday10.text = "측정시간 :" + CellController.MeasDtSrValue10;
    }

    public void ExitButton()
    {
        Instantiate(exittap,canvas.transform);
    }

    void Update()
    {
        
    }
}