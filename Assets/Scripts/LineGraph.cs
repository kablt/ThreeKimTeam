using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class LineGraph : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;

    public RectTransform handleTransform1;
    public RectTransform handleTransform2;

    public LineRenderer lineRenderer;


    void Start()
    {
        // ���� �������� �Ӽ��� �����մϴ�.
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;


        // �����̴��� �ڵ��� RectTransform ���� ã���ϴ�.
        handleTransform1 = slider1.handleRect;
        // �����̴��� RectTransform ���� ã���ϴ�.
        RectTransform sliderRect = slider1.GetComponent<RectTransform>();
        // �ڵ��� transform ���� Vector3�� ����ϴ�.
        Vector3 handlePosition = handleTransform1.position;
        // UpdateLine �޼��带 ȣ���մϴ�.
        UpdateLine(0);

        // ���� �������� Sorting Layer�� Sorting Order�� �����մϴ�.
        lineRenderer.sortingLayerName = "Default";
        lineRenderer.sortingOrder = 0;

        // ���� �������� Ȱ��ȭ�մϴ�.
        lineRenderer.enabled = true;
    }

    void UpdateLine(float value)
    {

        // �����̴��� �ڵ��� RectTransform ���� ã���ϴ�.
        handleTransform1 = slider1.handleRect;
        handleTransform2 = slider2.handleRect;
        // �����̴��� RectTransform ���� ã���ϴ�.
        RectTransform sliderRect = slider1.GetComponent<RectTransform>();
        // �ڵ��� transform ���� Vector3�� ����ϴ�.
        Vector3 handlePosition1 = handleTransform1.position;
        Vector3 handlePosition2 = handleTransform2.position;


        // ���� �������� ������ ��ġ�� �����մϴ�.(�ε����� )
        lineRenderer.SetPosition(0, handlePosition1);
        lineRenderer.SetPosition(1, handlePosition2);
    }
}
