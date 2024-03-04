using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopupPanel : MonoBehaviour
{
    public GameObject panelPrefab; // 표시할 패널 프리팹
    private GameObject currentPanel; // 현재 표시된 패널

    void Start()
    {
        // 버튼 클릭 이벤트에 메소드 연결
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ShowPanel);
    }

    // 패널 보이기
    void ShowPanel()
    {
        if (currentPanel == null && panelPrefab != null)
        {
            currentPanel = Instantiate(panelPrefab, transform.parent); // 패널 생성
            // 패널을 드래그할 수 있도록 DraggablePanel 스크립트를 추가합니다.
            DraggablePanel draggablePanel = currentPanel.AddComponent<DraggablePanel>();
            // 닫기 버튼 클릭 이벤트에 메소드 연결
            //Button closeButton = currentPanel.transform.Find("PopupCloseButton").GetComponent<Button>();
            //closeButton.onClick.AddListener(ClosePanel);
        }
    }

    // 패널 닫기
    void ClosePanel()
    {
        if (currentPanel != null)
        {
            Destroy(currentPanel); // 패널 제거
            currentPanel = null; // 현재 패널 변수 초기화
        }
    }
}

public class DraggablePanel : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform panelRectTransform;
    private Canvas canvas;
    private RectTransform canvasRectTransform;

    void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasRectTransform = canvas.GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 시작 시 실행되는 메소드
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 드래그 중 실행되는 메소드
        Vector2 mouseDelta = eventData.delta;
        panelRectTransform.anchoredPosition += mouseDelta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그 종료 시 실행되는 메소드
    }
}
