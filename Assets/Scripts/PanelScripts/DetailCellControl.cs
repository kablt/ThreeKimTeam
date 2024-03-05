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
    //�׷��� �Ʒ� ��ư �����ϼ�
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



    //�׷��� �����̴��� Value���� ������ ���� �ֱ�



    public void OnClickCloseButton()
    {
        DropdownManager.ActiveButton = true;
        Destroy(gameObject);
    }
          
    public void OnClickChangeOne(float num)
    {
        if(num == 1)
        {
            //cellcontroller���� ����Ȱ� static�� ���� 
            inTp.text = (Mathf.Round(CellController.InTpValue1 * 10f) / 10f).ToString();
            inHd.text = (Mathf.Round(CellController.InHdValue1 * 10f) / 10f).ToString();
            outWs.text = (Mathf.Round(CellController.OutWsValue1 * 10f) / 10f).ToString();
            outTp.text = (Mathf.Round(CellController.OutTpValue1 * 10f) / 10f).ToString();
            inCo2.text = "Co2�� :" + Mathf.Round(CellController.InCo2Value1 * 10f) / 10f;
        }
        else if (num ==2)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue2 * 10f) / 10f).ToString();
            inHd.text = (Mathf.Round(CellController.InHdValue2 * 10f) / 10f).ToString();
            outWs.text = (Mathf.Round(CellController.OutWsValue2 * 10f) / 10f).ToString();
            outTp.text = (Mathf.Round(CellController.OutTpValue2 * 10f) / 10f).ToString();
            inCo2.text = "Co2�� :" + Mathf.Round(CellController.InCo2Value2 * 10f) / 10f;
        }
        else if(num == 3)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue3 * 10f) / 10f).ToString();
            inHd.text = (Mathf.Round(CellController.InHdValue3 * 10f) / 10f).ToString();
            outWs.text = (Mathf.Round(CellController.OutWsValue3 * 10f) / 10f).ToString();
            outTp.text = (Mathf.Round(CellController.OutTpValue3 * 10f) / 10f).ToString();
            inCo2.text = "Co2�� :" + Mathf.Round(CellController.InCo2Value3 * 10f) / 10f;
        }
        else if (num == 4)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue4 * 10f) / 10f).ToString();
            inHd.text = (Mathf.Round(CellController.InHdValue4 * 10f) / 10f).ToString();
            outWs.text = (Mathf.Round(CellController.OutWsValue4 * 10f) / 10f).ToString();
            outTp.text = (Mathf.Round(CellController.OutTpValue4 * 10f) / 10f).ToString();
            inCo2.text = "Co2�� :" + Mathf.Round(CellController.InCo2Value4 * 10f) / 10f;
        }
        else if (num == 5)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue5 * 10f) / 10f).ToString();
            inHd.text = (Mathf.Round(CellController.InHdValue5 * 10f) / 10f).ToString();
            outWs.text = (Mathf.Round(CellController.OutWsValue5 * 10f) / 10f).ToString();
            outTp.text = (Mathf.Round(CellController.OutTpValue5 * 10f) / 10f).ToString();
            inCo2.text = "Co2�� :" + Mathf.Round(CellController.InCo2Value5 * 10f) / 10f;
        }
        else if (num == 6)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue6 * 10f) / 10f).ToString();
            inHd.text = (Mathf.Round(CellController.InHdValue6 * 10f) / 10f).ToString();
            outWs.text = (Mathf.Round(CellController.OutWsValue6 * 10f) / 10f).ToString();
            outTp.text = (Mathf.Round(CellController.OutTpValue6 * 10f) / 10f).ToString();
            inCo2.text = "Co2�� :" + Mathf.Round(CellController.InCo2Value6 * 10f) / 10f;
        }
        else if (num == 7)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue7 * 10f) / 10f).ToString();
            inHd.text = (Mathf.Round(CellController.InHdValue7 * 10f) / 10f).ToString();
            outWs.text = (Mathf.Round(CellController.OutWsValue7 * 10f) / 10f).ToString();
            outTp.text = (Mathf.Round(CellController.OutTpValue7 * 10f) / 10f).ToString();
            inCo2.text = "Co2�� :" + Mathf.Round(CellController.InCo2Value7 * 10f) / 10f;
        }
        else if (num == 8)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue8 * 10f) / 10f).ToString();
            inHd.text = (Mathf.Round(CellController.InHdValue8 * 10f) / 10f).ToString();
            outWs.text = (Mathf.Round(CellController.OutWsValue8 * 10f) / 10f).ToString();
            outTp.text = (Mathf.Round(CellController.OutTpValue8 * 10f) / 10f).ToString();
            inCo2.text = "Co2�� :" + Mathf.Round(CellController.InCo2Value8 * 10f) / 10f;
        }
        else if (num == 9)
        {
            inTp.text = (Mathf.Round(CellController.InTpValue9 * 10f) / 10f).ToString();
            inHd.text = (Mathf.Round(CellController.InHdValue9 * 10f) / 10f).ToString();
            outWs.text = (Mathf.Round(CellController.OutWsValue9 * 10f) / 10f).ToString();
            outTp.text = (Mathf.Round(CellController.OutTpValue9 * 10f) / 10f).ToString();
            inCo2.text = "Co2�� :" + Mathf.Round(CellController.InCo2Value9 * 10f) / 10f;
        }
        else
        {
            inTp.text = (Mathf.Round(CellController.InTpValue10 * 10f) / 10f).ToString();
            inHd.text = (Mathf.Round(CellController.InHdValue10 * 10f) / 10f).ToString();
            outWs.text = (Mathf.Round(CellController.OutWsValue10 * 10f) / 10f).ToString();
            outTp.text = (Mathf.Round(CellController.OutTpValue10 * 10f) / 10f).ToString();
            inCo2.text = "Co2�� : " +Mathf.Round(CellController.InCo2Value10 * 10f) / 10f + "ppm";
        }

    }

    void Start()
    {
        DropdownManager.ActiveButton = false;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        //ó�� ������ ����. �װ��� 10���� ������!
        inTp.text = (Mathf.Round(CellController.InTpValue10 * 10f) / 10f).ToString();
        inHd.text = (Mathf.Round(CellController.InHdValue10 * 10f) / 10f).ToString();
        outWs.text = (Mathf.Round(CellController.OutWsValue10 * 10f) / 10f).ToString();
        outTp.text = (Mathf.Round(CellController.OutTpValue10 * 10f) / 10f).ToString();
        inCo2.text = "Co2�� : " + Mathf.Round(CellController.InCo2Value10 * 10f) / 10f + "ppm";
        //�׷��� �Ʒ��� ���� �ð�. �̰űٵ� �ʹ� �� ���� ����.
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