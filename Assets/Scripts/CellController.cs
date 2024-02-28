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
        // 텍스트 초기화
        codeText.text = "";
        itemText.text = "";
        companyText.text = "";
    }

    public void SetData(Dictionary<string, string> data)
    {
        codeText.text = data["Code"]; // Code 키를 가지고 있는 값을 출력
        itemText.text = data["Item"];
        companyText.text = data["Company"];
    }
}
