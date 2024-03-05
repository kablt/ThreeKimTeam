using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DropdownManager : MonoBehaviour
{
    public TMP_Dropdown parentDropdown; // Parent Dropdown ����
    public TMP_Dropdown childDropdown;  // Child Dropdown ����
    public static bool ActiveButton = true;
    public GameObject target;

    // Parent Dropdown���� ������ �ɼǿ� ���� Child Dropdown�� �ɼ��� ������Ʈ�ϴ� �Լ�
    public void UpdateChildDropdownOptions()
    {
        // Parent Dropdown���� ���õ� �ɼǿ� ���� Child Dropdown�� �ɼ��� ����
        switch (parentDropdown.value)
        {
            case 0: // �����ϱ� ��
                SetChildDropdownOptions(new string[] { "����(��/��)" });
                break;
            case 1: // �泲 ������ ���
                SetChildDropdownOptions(new string[] { "����", "��õ", "â��", "�Ծ�" });
                break;
            case 2: // ���� ������ ���
                SetChildDropdownOptions(new string[] { "����", "����", "���", "����", "����", "ȭ��" });
                break;
            case 3: // ���� ������ ���
                SetChildDropdownOptions(new string[] { "����", "����", "����", "�ͻ�", "����", "����" });
                break;
            default: // 
                SetChildDropdownOptions(new string[] { });
                break;
        }
    }

    // Child Dropdown�� �ɼ��� �����ϴ� �Լ�
    void SetChildDropdownOptions(string[] options)
    {
        childDropdown.ClearOptions(); // ���� �ɼ��� ��� ����
        childDropdown.AddOptions(new List<string>(options)); // ���ο� �ɼ��� �߰�
    }

    // Start �Լ����� Parent Dropdown�� �� ���� �̺�Ʈ�� UpdateChildDropdownOptions �Լ��� ����
    void Start()
    {
        parentDropdown.onValueChanged.AddListener(delegate {
            UpdateChildDropdownOptions();
        });

        // �ʱ⿡�� �ѹ��� ȣ���Ͽ� Child Dropdown�� ������Ʈ
        UpdateChildDropdownOptions();
    }

    public void ActiveControl()
    {
        if(ActiveButton !=false)
        {
            target.SetActive(true);
        }
        if(ActiveButton == false)
        {
            target.SetActive(false);
        }
    }

 

    private void Update()
    {
        ActiveControl();

    }
}

