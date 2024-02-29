using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QueryButton : MonoBehaviour
{
    public DropdownManager dropdownManager; // DropdownM 스크립트 연결
    public TextAsset csvFile; //Unity Editor에서 할당
    public TMP_Text resultText; // 결과를 표시할 Text UI

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
            if (rowValues.Length != 6) continue; //열 개수

            int no = int.Parse(rowValues[0]);
            int id = int.Parse(rowValues[1]);
            string region = rowValues[2];
            string city = rowValues[3];
            string species = rowValues[4];
            string company = rowValues[5];

            //Debug.Log($"번호: {no}, 농가코드: {id}, 지역(도): {region},지역(시군): {city},품종: {species},업체: {company}");
        }
    }
    public void OnClickQuery()
    {
        // 선택된 값 가져오기
        string selectedRegion = dropdownManager.parentDropdown.options[dropdownManager.parentDropdown.value].text;
        string selectedCity = dropdownManager.childDropdown.options[dropdownManager.childDropdown.value].text;

        // 결과 초기화
        resultText.text = "";

        // CSV 파일에서 데이터 읽기
        string[] rows = csvFile.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 1; i < rows.Length; i++)
        {
            string[] rowValues = rows[i].Split(',');
            if (rowValues.Length != 6) continue; // 열 개수

            int no = int.Parse(rowValues[0]);
            int id = int.Parse(rowValues[1]);
            string region = rowValues[2];
            string city = rowValues[3];
            string species = rowValues[4];
            string company = rowValues[5];

            // 선택된 값과 일치하는 데이터인지 확인
            if (region == selectedRegion && city == selectedCity)
            {
                // 결과 출력
                resultText.text += $"농가코드: {no}, 품종: {species}, 업체: {company}\n";
            }
        }
    }
    // 만약에 region과 city가 dropdown에서 선택한 값과 같다면
    // 농가코드, 품종, 업체의 정보를 가져온다.
    void MakeTable()
    {

    }
}
