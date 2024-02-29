using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI noText;
    [SerializeField] TextMeshProUGUI speciesText;
    [SerializeField] TextMeshProUGUI companyText;
    DataDisplay display;

    void Awake()
    {
        //// 텍스트 초기화
        //noText.text = "";
        //speciesText.text = "";
        //companyText.text = "";
        // 변수들이 null 인지 확인하고 null 이 아니면 텍스트를 초기화
        if (noText != null)
            noText.text = "";
        if (speciesText != null)
            speciesText.text = "";
        if (companyText != null)
            companyText.text = "";

    }

    public void SetData(Dictionary<string, string> data)
    {
        //noText.text = data["no"]; // Code 키를 가지고 있는 값을 출력
        //speciesText.text = data["species"];
        //companyText.text = data["company"];

        // null 체크를 추가하여 변수가 null이 아닌 경우에만 값을 설정합니다.
        if (noText != null && data.ContainsKey("no"))
            noText.text = data["no"]; // Code 키를 가지고 있는 값을 출력

        if (speciesText != null && data.ContainsKey("species"))
            speciesText.text = data["species"];

        if (companyText != null && data.ContainsKey("company"))
            companyText.text = data["company"];
    }
}