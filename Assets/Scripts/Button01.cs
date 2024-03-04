using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button01 : MonoBehaviour
{
    public DropdownManager dropdownManager; // DropdownM 스크립트 연결
    public TextAsset csvFile; //Unity Editor에서 할당
    public RectTransform content; // Scroll View의 Content 객체
    public GameObject cellPrefab; // Cell 프리팹

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
            if (rowValues.Length != 6) continue; // 열 개수

            int no = int.Parse(rowValues[0]);
            int id = int.Parse(rowValues[1]);
            string region = rowValues[2];
            string city = rowValues[3];
            string species = rowValues[4];
            string company = rowValues[5];

            // Debug.Log($"번호: {no}, 농가코드: {id}, 지역(도): {region},지역(시군): {city},품종: {species},업체: {company}");
        }
    }

    public void OnClickQuery()
    {
        // 선택된 값 가져오기
        string selectedRegion = dropdownManager.parentDropdown.options[dropdownManager.parentDropdown.value].text;
        string selectedCity = dropdownManager.childDropdown.options[dropdownManager.childDropdown.value].text;

        // CSV 파일에서 데이터 읽기
        string[] rows = csvFile.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        // 결과 초기화
        ClearCells();

        int cellCount = 0; // 생성된 Cell의 개수를 세는 변수

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
                // Cell 프리팹 생성
                GameObject cellObject = Instantiate(cellPrefab, content);
                // Cell 정보 설정
                SetCellData(cellObject, no, species, company);

                cellCount++; // 생성된 Cell 개수 증가
            }
        }

        // 만약 데이터가 없으면, 빈 Cell을 하나 생성하여 표시
        if (cellCount == 0)
        {
            GameObject emptyCellObject = Instantiate(cellPrefab, content);
            SetEmptyCell(emptyCellObject);
        }
    }

    void SetCellData(GameObject cellObject, int no, string species, string company)
    {
        // Cell 내 Text UI 요소들 설정
        TextMeshProUGUI[] texts = cellObject.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = $"{no}";
        texts[1].text = $"{species}";
        texts[2].text = $"{company}";
    }

    void SetEmptyCell(GameObject cellObject)
    {
        // Cell 내 Text UI 요소들 비우기
        TextMeshProUGUI[] texts = cellObject.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI text in texts)
        {
            text.text = ""; // 내용을 비움
        }
        cellObject.GetComponent<Image>().enabled = false; // Cell을 비활성화
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
