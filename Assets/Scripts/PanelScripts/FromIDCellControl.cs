using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FromIDCellControl : MonoBehaviour
{
    [SerializeField] TMP_Text formId;
    public float DownId;


    //public ICellDelegate cellDelegate; �̰� ���� �𸣰ڴ� ����
    private int index;

    private void Awake()
    {
        formId.text = "";
    }

    public void SetData(int index)
    {
        this.index = index;
    }
    //�Ʒ� �Լ� ����� ������ �г� �����ΰ�?
    /*
    public void OnClickCell()
    {
        cellDelegate.OnClickCell(this.index);
    }
    */ 
}
