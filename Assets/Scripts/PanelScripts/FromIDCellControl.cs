using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FromIDCellControl : MonoBehaviour
{
    [SerializeField] TMP_Text formId;
    public float DownId;


    //public ICellDelegate cellDelegate; 이건 뭔지 모르겠다 보류
    private int index;

    private void Awake()
    {
        formId.text = "";
    }

    public void SetData(int index)
    {
        this.index = index;
    }
    //아래 함수 실행시 디테일 패널 생성인가?
    /*
    public void OnClickCell()
    {
        cellDelegate.OnClickCell(this.index);
    }
    */ 
}
