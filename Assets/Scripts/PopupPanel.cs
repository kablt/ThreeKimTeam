using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopupPanel : MonoBehaviour
{
    public GameObject panelPrefab; // ǥ���� �г� ������
    private GameObject currentPanel; // ���� ǥ�õ� �г�

    void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ�� �޼ҵ� ����
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ShowPanel);
    }

    // �г� ���̱�
    void ShowPanel()
    {
        if (currentPanel == null && panelPrefab != null)
        {
            currentPanel = Instantiate(panelPrefab, transform.parent); // �г� ����
            // �г��� �巡���� �� �ֵ��� DraggablePanel ��ũ��Ʈ�� �߰��մϴ�.
            DraggablePanel draggablePanel = currentPanel.AddComponent<DraggablePanel>();
            // �ݱ� ��ư Ŭ�� �̺�Ʈ�� �޼ҵ� ����
            //Button closeButton = currentPanel.transform.Find("PopupCloseButton").GetComponent<Button>();
            //closeButton.onClick.AddListener(ClosePanel);
        }
    }

    // �г� �ݱ�
    void ClosePanel()
    {
        if (currentPanel != null)
        {
            Destroy(currentPanel); // �г� ����
            currentPanel = null; // ���� �г� ���� �ʱ�ȭ
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
        // �巡�� ���� �� ����Ǵ� �޼ҵ�
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �巡�� �� ����Ǵ� �޼ҵ�
        Vector2 mouseDelta = eventData.delta;
        panelRectTransform.anchoredPosition += mouseDelta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �巡�� ���� �� ����Ǵ� �޼ҵ�
    }
}
