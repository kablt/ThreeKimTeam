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
    [SerializeField] TMP_Text measDtStr;
    [SerializeField] TMP_Text outWs;
    [SerializeField] TMP_Text outTp;
    [SerializeField] TMP_Text inCo2;
    public CellController cellControl;


//그래프 슬라이더의 Value값에 지정된 변수 넣기

public void SetData(CellController cellcontrol)
    {
        this.cellControl = cellcontrol; // 저장된 CellController를 유지

        inTp.text = cellcontrol.InTpValue10.ToString();
        inHd.text = cellcontrol.InHdValue10.ToString();
        frmhsId.text = cellcontrol.FrmhsIdValue;
        measDtStr.text = cellcontrol.MeasDtSrValue10;
        outWs.text = cellcontrol.OutWsValue10.ToString();
        outTp.text = cellcontrol.OutTpValue10.ToString(); 
     

    }

    public void UpdateData()
    {
        // 저장된 CellController에서 값을 가져와서 업데이트
        inTp.text = cellControl.InTpValue10.ToString();
        inHd.text = cellControl.InHdValue10.ToString();
        frmhsId.text = cellControl.FrmhsIdValue;
        measDtStr.text = cellControl.MeasDtSrValue10;
        outWs.text = cellControl.OutWsValue10.ToString();
        outTp.text = cellControl.OutTpValue10.ToString();
    
    }

    public void OnClickCloseButton()
    {
        DropdownManager.ActiveButton = true;
        Destroy(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {
      
    
    }

}