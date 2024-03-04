using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DataDisplay : MonoBehaviour
{
    public DropdownManager dropdownManager; // DropdownM ��ũ��Ʈ ����
    public TextAsset csvFile; // Unity Editor���� �Ҵ�
    public RectTransform content; // Scroll View�� Content ��ü
    public GameObject cellPrefab; // Cell ������

    // Cell�� ǥ���� �����͸� �����ϴ� Ŭ����
    private class FarmData
    {
        public string code;
        public string species;
        public string company;
    }

    void Start()
    {
        // �ʱ�ȭ
        ClearCells();
    }

    public void OnClickQuery()
    {
        // ���õ� �� ��������
        string selectedRegion = dropdownManager.parentDropdown.options[dropdownManager.parentDropdown.value].text;
        string selectedCity = dropdownManager.childDropdown.options[dropdownManager.childDropdown.value].text;

        // ��� �ʱ�ȭ
        ClearCells();

        // CSV ���Ͽ��� ������ �б�
        string[] rows = csvFile.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        // �ش� ������ �´� �����͸� ����Ʈ�� ����
        List<FarmData> dataList = new List<FarmData>();
        for (int i = 1; i < rows.Length; i++)
        {
            string[] rowValues = rows[i].Split(',');
            if (rowValues.Length != 6) continue; // �� ���� Ȯ��

            string region = rowValues[2];
            string city = rowValues[3];

            // ���õ� ���� ��ġ�ϴ� ���������� Ȯ��
            if (region == selectedRegion && city == selectedCity)
            {
                FarmData data = new FarmData();
                data.code = rowValues[1];
                data.species = rowValues[4];
                data.company = rowValues[5];
                dataList.Add(data);
            }
        }

        // ��ȸ�� �����͸� ǥ��
        foreach (FarmData data in dataList)
        {
            GameObject cellObject = Instantiate(cellPrefab, content);
            SetCellData(cellObject, data);
        }

    }

    void SetCellData(GameObject cellObject, FarmData data)
    {
        // Cell �� Text UI ��ҵ� ����
        TextMeshProUGUI[] texts = cellObject.GetComponentsInChildren<TextMeshProUGUI>();
        texts[1].text = data.code; // DataText_no
        texts[3].text = data.species; // DataText_species
        texts[5].text = data.company; // DataText_company
    }

    void ClearCells()
    {
        // Content �Ʒ��� ��� �ڽ� GameObject ����
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}
