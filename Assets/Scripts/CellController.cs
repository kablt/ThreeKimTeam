using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI codeText;
    [SerializeField] TextMeshProUGUI itemText;
    [SerializeField] TextMeshProUGUI companyText;

    void Awake()
    {
        // �ؽ�Ʈ �ʱ�ȭ
        codeText.text = "";
        itemText.text = "";
        companyText.text = "";
    }

    public void SetData(Dictionary<string, string> data)
    {
        codeText.text = data["Code"]; // Code Ű�� ������ �ִ� ���� ���
        itemText.text = data["Item"];
        companyText.text = data["Company"];
    }
}
