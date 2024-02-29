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
        //// �ؽ�Ʈ �ʱ�ȭ
        //noText.text = "";
        //speciesText.text = "";
        //companyText.text = "";
        // �������� null ���� Ȯ���ϰ� null �� �ƴϸ� �ؽ�Ʈ�� �ʱ�ȭ
        if (noText != null)
            noText.text = "";
        if (speciesText != null)
            speciesText.text = "";
        if (companyText != null)
            companyText.text = "";

    }

    public void SetData(Dictionary<string, string> data)
    {
        //noText.text = data["no"]; // Code Ű�� ������ �ִ� ���� ���
        //speciesText.text = data["species"];
        //companyText.text = data["company"];

        // null üũ�� �߰��Ͽ� ������ null�� �ƴ� ��쿡�� ���� �����մϴ�.
        if (noText != null && data.ContainsKey("no"))
            noText.text = data["no"]; // Code Ű�� ������ �ִ� ���� ���

        if (speciesText != null && data.ContainsKey("species"))
            speciesText.text = data["species"];

        if (companyText != null && data.ContainsKey("company"))
            companyText.text = data["company"];
    }
}