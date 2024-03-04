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
        // 라인 렌더러의 속성을 설정합니다.
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;


        // 슬라이더의 핸들의 RectTransform 값을 찾습니다.
        handleTransform1 = slider1.handleRect;
        // 슬라이더의 RectTransform 값을 찾습니다.
        RectTransform sliderRect = slider1.GetComponent<RectTransform>();
        // 핸들의 transform 값을 Vector3로 얻습니다.
        Vector3 handlePosition = handleTransform1.position;
        // UpdateLine 메서드를 호출합니다.
        UpdateLine(0);

        // 라인 렌더러의 Sorting Layer와 Sorting Order를 설정합니다.
        lineRenderer.sortingLayerName = "Default";
        lineRenderer.sortingOrder = 0;

        // 라인 렌더러를 활성화합니다.
        lineRenderer.enabled = true;
    }

    void UpdateLine(float value)
    {

        // 슬라이더의 핸들의 RectTransform 값을 찾습니다.
        handleTransform1 = slider1.handleRect;
        handleTransform2 = slider2.handleRect;
        // 슬라이더의 RectTransform 값을 찾습니다.
        RectTransform sliderRect = slider1.GetComponent<RectTransform>();
        // 핸들의 transform 값을 Vector3로 얻습니다.
        Vector3 handlePosition1 = handleTransform1.position;
        Vector3 handlePosition2 = handleTransform2.position;


        // 라인 렌더러의 점들의 위치를 설정합니다.(인덱스값 )
        lineRenderer.SetPosition(0, handlePosition1);
        lineRenderer.SetPosition(1, handlePosition2);
    }
}
