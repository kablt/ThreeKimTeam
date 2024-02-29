using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LineRendererController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public TextAsset csvFile; // CSV ������ ���� �ν����� â�� �߰��Ͽ� �����͸� ������
    private List<Vector3> positions = new List<Vector3>(); // ��ǥ�� ������ ����Ʈ
    private int currentIndex = 0; // ���� ���� �׸��� ��ġ�� �ε���
    private float elapsedTime = 0f; // ��� �ð�
    public float interval = 5f; // ���� ������ ����

    // �߰��� �κ�: ���� �Ӽ�
    public GameObject pointPrefab; // �� ������
    public Color pointColor = Color.red;

    void Start()
    {
        ReadCSV(); // CSV ���Ͽ��� ��ǥ �о����
        lineRenderer.positionCount = positions.Count; // positions ����Ʈ�� ũ�⸸ŭ ���� �� ���� ����
        SetInitialPositions(); // LineRenderer�� ������ ����
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= interval && currentIndex < positions.Count)
        {
            lineRenderer.SetPosition(currentIndex, positions[currentIndex]); // ���� �ε����� �ش��ϴ� ��ġ�� ���� �׸�
            currentIndex++;
            elapsedTime = 0f;
        }
    }

    void SetInitialPositions()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            lineRenderer.SetPosition(i, positions[i]); // LineRenderer�� �ʱ� ��ġ ����

            // �߰��� �κ�: �� �����ǿ� �� ����
            GameObject point = Instantiate(pointPrefab, positions[i], Quaternion.identity);
            point.GetComponent<Renderer>().material.color = pointColor; // ���� ���� ����
        }
    }

    void ReadCSV()
    {
        string[] lines = csvFile.text.Split('\n'); // CSV ������ �� ���� �迭�� �и�

        foreach (string line in lines)
        {
            string[] values = line.Split(','); // CSV ������ �� ���� ','�� �и��Ͽ� �迭�� ����
            if (values.Length >= 3)
            {
                float x = float.Parse(values[1]); // x ��ǥ
                float y = float.Parse(values[2]); // y ��ǥ
                float z = float.Parse(values[3]); // z ��ǥ
                positions.Add(new Vector3(x, y, z)); // ��ǥ�� positions ����Ʈ�� �߰�
            }
        }
    }
}
