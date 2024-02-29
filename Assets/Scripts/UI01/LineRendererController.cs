using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LineRendererController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public TextAsset csvFile; // CSV 파일을 직접 인스펙터 창에 추가하여 데이터를 가져옴
    private List<Vector3> positions = new List<Vector3>(); // 좌표를 저장할 리스트
    private int currentIndex = 0; // 현재 선을 그리는 위치의 인덱스
    private float elapsedTime = 0f; // 경과 시간
    public float interval = 5f; // 선을 생성할 간격

    // 추가된 부분: 점의 속성
    public GameObject pointPrefab; // 점 프리팹
    public Color pointColor = Color.red;

    void Start()
    {
        ReadCSV(); // CSV 파일에서 좌표 읽어오기
        lineRenderer.positionCount = positions.Count; // positions 리스트의 크기만큼 선의 점 개수 설정
        SetInitialPositions(); // LineRenderer의 시작점 설정
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= interval && currentIndex < positions.Count)
        {
            lineRenderer.SetPosition(currentIndex, positions[currentIndex]); // 현재 인덱스에 해당하는 위치에 선을 그림
            currentIndex++;
            elapsedTime = 0f;
        }
    }

    void SetInitialPositions()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            lineRenderer.SetPosition(i, positions[i]); // LineRenderer의 초기 위치 설정

            // 추가된 부분: 각 포지션에 점 생성
            GameObject point = Instantiate(pointPrefab, positions[i], Quaternion.identity);
            point.GetComponent<Renderer>().material.color = pointColor; // 점의 색상 설정
        }
    }

    void ReadCSV()
    {
        string[] lines = csvFile.text.Split('\n'); // CSV 파일의 각 줄을 배열로 분리

        foreach (string line in lines)
        {
            string[] values = line.Split(','); // CSV 파일의 한 줄을 ','로 분리하여 배열에 저장
            if (values.Length >= 3)
            {
                float x = float.Parse(values[1]); // x 좌표
                float y = float.Parse(values[2]); // y 좌표
                float z = float.Parse(values[3]); // z 좌표
                positions.Add(new Vector3(x, y, z)); // 좌표를 positions 리스트에 추가
            }
        }
    }
}
