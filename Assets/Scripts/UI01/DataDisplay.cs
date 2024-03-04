using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DataDisplay : MonoBehaviour
{
    public DropdownManager dropdownManager; // DropdownM 스크립트 연결
    public TextAsset csvFile; // Unity Editor에서 할당
    public RectTransform content; // Scroll View의 Content 객체
    public GameObject cellPrefab; // Cell 프리팹

    // Cell에 표시할 데이터를 저장하는 클래스
    private class FarmData
    {
        public string code;
        public string species;
        public string company;
    }

    void Start()
    {
        // 초기화
        ClearCells();
    }

    public void OnClickQuery()
    {
        // 선택된 값 가져오기
        string selectedRegion = dropdownManager.parentDropdown.options[dropdownManager.parentDropdown.value].text;
        string selectedCity = dropdownManager.childDropdown.options[dropdownManager.childDropdown.value].text;

        // 결과 초기화
        ClearCells();

        // CSV 파일에서 데이터 읽기
        string[] rows = csvFile.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        // 해당 지역에 맞는 데이터를 리스트에 저장
        List<FarmData> dataList = new List<FarmData>();
        for (int i = 1; i < rows.Length; i++)
        {
            string[] rowValues = rows[i].Split(',');
            if (rowValues.Length != 6) continue; // 열 개수 확인

            string region = rowValues[2];
            string city = rowValues[3];

            // 선택된 값과 일치하는 데이터인지 확인
            if (region == selectedRegion && city == selectedCity)
            {
                FarmData data = new FarmData();
                data.code = rowValues[1];
                data.species = rowValues[4];
                data.company = rowValues[5];
                dataList.Add(data);
            }
        }

        // 조회된 데이터를 표시
        foreach (FarmData data in dataList)
        {
            GameObject cellObject = Instantiate(cellPrefab, content);
            SetCellData(cellObject, data);
        }

    }

    void SetCellData(GameObject cellObject, FarmData data)
    {
        // Cell 내 Text UI 요소들 설정
        TextMeshProUGUI[] texts = cellObject.GetComponentsInChildren<TextMeshProUGUI>();
        texts[1].text = data.code; // DataText_no
        texts[3].text = data.species; // DataText_species
        texts[5].text = data.company; // DataText_company
    }

    void ClearCells()
    {
        // Content 아래의 모든 자식 GameObject 삭제
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}
