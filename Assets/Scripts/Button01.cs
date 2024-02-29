using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button01 : MonoBehaviour
{
    public DropdownManager dropdownManager; // DropdownM ��ũ��Ʈ ����
    public TextAsset csvFile; //Unity Editor���� �Ҵ�
    public RectTransform content; // Scroll View�� Content ��ü
    public GameObject cellPrefab; // Cell ������

    void Start()
    {
        ReadCSV(csvFile);
    }

    void ReadCSV(TextAsset csv)
    {
        string[] rows = csv.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 1; i < rows.Length; i++)
        {
            string[] rowValues = rows[i].Split(',');
            if (rowValues.Length != 6) continue; // �� ����

            int no = int.Parse(rowValues[0]);
            int id = int.Parse(rowValues[1]);
            string region = rowValues[2];
            string city = rowValues[3];
            string species = rowValues[4];
            string company = rowValues[5];

            // Debug.Log($"��ȣ: {no}, ���ڵ�: {id}, ����(��): {region},����(�ñ�): {city},ǰ��: {species},��ü: {company}");
        }
    }

    public void OnClickQuery()
    {
        // ���õ� �� ��������
        string selectedRegion = dropdownManager.parentDropdown.options[dropdownManager.parentDropdown.value].text;
        string selectedCity = dropdownManager.childDropdown.options[dropdownManager.childDropdown.value].text;

        // CSV ���Ͽ��� ������ �б�
        string[] rows = csvFile.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        // ��� �ʱ�ȭ
        ClearCells();

        int cellCount = 0; // ������ Cell�� ������ ���� ����

        for (int i = 1; i < rows.Length; i++)
        {
            string[] rowValues = rows[i].Split(',');
            if (rowValues.Length != 6) continue; // �� ����

            int no = int.Parse(rowValues[0]);
            int id = int.Parse(rowValues[1]);
            string region = rowValues[2];
            string city = rowValues[3];
            string species = rowValues[4];
            string company = rowValues[5];

            // ���õ� ���� ��ġ�ϴ� ���������� Ȯ��
            if (region == selectedRegion && city == selectedCity)
            {
                // Cell ������ ����
                GameObject cellObject = Instantiate(cellPrefab, content);
                // Cell ���� ����
                SetCellData(cellObject, no, species, company);

                cellCount++; // ������ Cell ���� ����
            }
        }

        // ���� �����Ͱ� ������, �� Cell�� �ϳ� �����Ͽ� ǥ��
        if (cellCount == 0)
        {
            GameObject emptyCellObject = Instantiate(cellPrefab, content);
            SetEmptyCell(emptyCellObject);
        }
    }

    void SetCellData(GameObject cellObject, int no, string species, string company)
    {
        // Cell �� Text UI ��ҵ� ����
        TextMeshProUGUI[] texts = cellObject.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = $"{no}";
        texts[1].text = $"{species}";
        texts[2].text = $"{company}";
    }

    void SetEmptyCell(GameObject cellObject)
    {
        // Cell �� Text UI ��ҵ� ����
        TextMeshProUGUI[] texts = cellObject.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI text in texts)
        {
            text.text = ""; // ������ ���
        }
        cellObject.GetComponent<Image>().enabled = false; // Cell�� ��Ȱ��ȭ
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
