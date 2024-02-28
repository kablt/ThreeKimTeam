using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QueryButton : MonoBehaviour
{
    public DropdownManager dropdownManager; // DropdownM ��ũ��Ʈ ����
    public TextAsset csvFile; //Unity Editor���� �Ҵ�
    public TMP_Text resultText; // ����� ǥ���� Text UI

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
            if (rowValues.Length != 6) continue; //�� ����

            int no = int.Parse(rowValues[0]);
            int id = int.Parse(rowValues[1]);
            string region = rowValues[2];
            string city = rowValues[3];
            string species = rowValues[4];
            string company = rowValues[5];

            //Debug.Log($"��ȣ: {no}, ���ڵ�: {id}, ����(��): {region},����(�ñ�): {city},ǰ��: {species},��ü: {company}");
        }
    }
    public void OnClickQuery()
    {
        // ���õ� �� ��������
        string selectedRegion = dropdownManager.parentDropdown.options[dropdownManager.parentDropdown.value].text;
        string selectedCity = dropdownManager.childDropdown.options[dropdownManager.childDropdown.value].text;

        // ��� �ʱ�ȭ
        resultText.text = "";

        // CSV ���Ͽ��� ������ �б�
        string[] rows = csvFile.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
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
                // ��� ���
                resultText.text += $"���ڵ�: {no}, ǰ��: {species}, ��ü: {company}\n";
            }
        }
    }
    // ���࿡ region�� city�� dropdown���� ������ ���� ���ٸ�
    // ���ڵ�, ǰ��, ��ü�� ������ �����´�.
    void MakeTable()
    {

    }
}
