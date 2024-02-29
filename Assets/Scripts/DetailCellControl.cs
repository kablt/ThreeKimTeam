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
        // Scene에 있는 UI 오브젝트들을 찾아서 활성화
        GameObject parentDropdown = GameObject.Find("parentDropdown");
        if (parentDropdown != null) parentDropdown.SetActive(true);

        GameObject childDropdown = GameObject.Find("childDropdown");
        if (childDropdown != null) childDropdown.SetActive(true);

        GameObject scrollView = GameObject.Find("Scroll_View");
        if (scrollView != null) scrollView.SetActive(true);

        GameObject searchButton = GameObject.Find("SearchButton");
        if (searchButton != null) searchButton.SetActive(true);
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
