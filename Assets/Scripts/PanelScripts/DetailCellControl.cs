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
            inTp.text = "���οµ� :" + Mathf.Round(CellController.InTpValue1*10f)/10f;
            inHd.text = "���ν��� :" + Mathf.Round(CellController.InHdValue1*10f)/10f;
            outWs.text = "ǳ�� :" + Mathf.Round(CellController.OutWsValue1*10f)/10f;
            outTp.text = "�ܺ� �µ� : " + Mathf.Round(CellController.OutTpValue1*10f)/10f;
            inCo2.text = "Co2�� :" + Mathf.Round(CellController.InCo2Value1*10f)/10f;
        }
        else if (num ==2)
        {
            inTp.text = "���οµ� :" + CellController.InTpValue2;
            inHd.text = "���ν��� :" + CellController.InHdValue2;
            outWs.text = "ǳ�� :" + CellController.OutWsValue2;
            outTp.text = "�ܺ� �µ� : " + CellController.OutTpValue2;
            inCo2.text = "Co2�� :" + CellController.InCo2Value2;
        }
        else if(num == 3)
        {
            inTp.text = "���οµ� :" + CellController.InTpValue3;
            inHd.text = "���ν��� :" + CellController.InHdValue3;
            outWs.text = "ǳ�� :" + CellController.OutWsValue3;
            outTp.text = "�ܺ� �µ� : " + CellController.OutTpValue3;
            inCo2.text = "Co2�� :" + CellController.InCo2Value3;
        }
        else if (num == 4)
        {
            inTp.text = "���οµ� :" + CellController.InTpValue4;
            inHd.text = "���ν��� :" + CellController.InHdValue4;
            outWs.text = "ǳ�� :" + CellController.OutWsValue4;
            outTp.text = "�ܺ� �µ� : " + CellController.OutTpValue4;
            inCo2.text = "Co2�� :" + CellController.InCo2Value4;
        }
        else if (num == 5)
        {
            inTp.text = "���οµ� :" + CellController.InTpValue5;
            inHd.text = "���ν��� :" + CellController.InHdValue5;
            outWs.text = "ǳ�� :" + CellController.OutWsValue5;
            outTp.text = "�ܺ� �µ� : " + CellController.OutTpValue5;
            inCo2.text = "Co2�� :" + CellController.InCo2Value5;
        }
        else if (num == 6)
        {
            inTp.text = "���οµ� :" + CellController.InTpValue6;
            inHd.text = "���ν��� :" + CellController.InHdValue6;
            outWs.text = "ǳ�� :" + CellController.OutWsValue6;
            outTp.text = "�ܺ� �µ� : " + CellController.OutTpValue6;
            inCo2.text = "Co2�� :" + CellController.InCo2Value6;
        }
        else if (num == 7)
        {
            inTp.text = "���οµ� :" + CellController.InTpValue7;
            inHd.text = "���ν��� :" + CellController.InHdValue7;
            outWs.text = "ǳ�� :" + CellController.OutWsValue7;
            outTp.text = "�ܺ� �µ� : " + CellController.OutTpValue7;
            inCo2.text = "Co2�� :" + CellController.InCo2Value7;
        }
        else if (num == 8)
        {
            inTp.text = "���οµ� :" + CellController.InTpValue8;
            inHd.text = "���ν��� :" + CellController.InHdValue8;
            outWs.text = "ǳ�� :" + CellController.OutWsValue8;
            outTp.text = "�ܺ� �µ� : " + CellController.OutTpValue8;
            inCo2.text = "Co2�� :" + CellController.InCo2Value8;
        }
        else if (num == 9)
        {
            inTp.text = "���οµ� :" + CellController.InTpValue9;
            inHd.text = "���ν��� :" + CellController.InHdValue9;
            outWs.text = "ǳ�� :" + CellController.OutWsValue9;
            outTp.text = "�ܺ� �µ� : " + CellController.OutTpValue9;
            inCo2.text = "Co2�� :" + CellController.InCo2Value9;
        }
        else
        {
            inTp.text = "���οµ� :" + CellController.InTpValue10;
            inHd.text = "���ν��� :" + CellController.InHdValue10;
            outWs.text = "ǳ�� :" + CellController.OutWsValue10;
            outTp.text = "�ܺ� �µ� : " + CellController.OutTpValue10;
            inCo2.text = "Co2�� :" + CellController.InCo2Value10;
        }

    }

    void Start()
    {
        DropdownManager.ActiveButton = false;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        //ó�� ������ ����. �װ��� 10���� ������!
        inTp.text = "���οµ� :" + CellController.InTpValue10;
        inHd.text = "���ν��� :" + CellController.InHdValue10;
        outWs.text = "ǳ�� :" + CellController.OutWsValue10;
        outTp.text = "�ܺ� �µ� : " + CellController.OutTpValue10;
        inCo2.text = "Co2�� :" + CellController.InCo2Value10;
        //�׷��� �Ʒ��� ���� �ð�. �̰űٵ� �ʹ� �� ���� ����.
        mday1.text = "�����ð� :" + CellController.MeasDtSrValue1;
        mday2.text = "�����ð� :" + CellController.MeasDtSrValue2;
        mday3.text = "�����ð� :" + CellController.MeasDtSrValue3;
        mday4.text = "�����ð� :" + CellController.MeasDtSrValue4;
        mday5.text = "�����ð� :" + CellController.MeasDtSrValue5;
        mday6.text = "�����ð� :" + CellController.MeasDtSrValue6;
        mday7.text = "�����ð� :" + CellController.MeasDtSrValue7;
        mday8.text = "�����ð� :" + CellController.MeasDtSrValue8;
        mday9.text = "�����ð� :" + CellController.MeasDtSrValue9;
        mday10.text = "�����ð� :" + CellController.MeasDtSrValue10;
    }

    public void ExitButton()
    {
        Instantiate(exittap,canvas.transform);
    }

    void Update()
    {
        
    }
}