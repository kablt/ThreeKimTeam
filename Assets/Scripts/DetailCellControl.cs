using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetailCellControl : MonoBehaviour
{
    [SerializeField] TMP_Text inTp;
    [SerializeField] TMP_Text inHd;
    [SerializeField] TMP_Text frmhsId;
    [SerializeField] TMP_Text measDtStr;
    [SerializeField] TMP_Text outWs;
    [SerializeField] TMP_Text outTp;
    // [SerializeField] TMP_Text inCo2;
    public CellController cellControl;

    public void SetData(CellController cellcontrol)
    {
        this.cellControl = cellcontrol; // 저장된 CellController를 유지

        inTp.text = cellcontrol.InTpValue.ToString();
        inHd.text = cellcontrol.InHdValue.ToString();
        frmhsId.text = cellcontrol.FrmhsIdValue;
        measDtStr.text = cellcontrol.MeasDtSrValue;
        outWs.text = cellcontrol.OutWsValue.ToString();
        outTp.text = cellcontrol.OutTpValue.ToString();
    }

    public void UpdateData()
    {
        // 저장된 CellController에서 값을 가져와서 업데이트
        inTp.text = cellControl.InTpValue.ToString();
        inHd.text = cellControl.InHdValue.ToString();
        frmhsId.text = cellControl.FrmhsIdValue;
        measDtStr.text = cellControl.MeasDtSrValue;
        outWs.text = cellControl.OutWsValue.ToString();
        outTp.text = cellControl.OutTpValue.ToString();
    }

    public void OnClickCloseButton()
    {
     
        Destroy(gameObject);

    }

    void Update()
    {
        
    }
}
