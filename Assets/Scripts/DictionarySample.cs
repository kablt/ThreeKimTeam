using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionarySample : MonoBehaviour
{
    // ���� ������� Trasform ���� ������ ������ GameObject�� SerializeField�� �߰�
    [SerializeField] Transform content;
    [SerializeField] GameObject cellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, string> corp1 = new Dictionary<string, string>();
        corp1["no"] = "";
        corp1["species"] = "";
        corp1["company"] = "";

        Dictionary<string, string> corp2 = new Dictionary<string, string>();
        corp2["no"] = "";
        corp2["species"] = "";
        corp2["company"] = "";


        List<Dictionary<string, string>> corpBook = new List<Dictionary<string, string>>();
        corpBook.Add(corp1);
        corpBook.Add(corp2);      

        // �ҷ�����
        Dictionary<string, string> dict = corpBook[0];
        Debug.Log(dict["company"]);

        ////������ Cell�� �����ͼ� ScrollView�� Content �ȿ� ����
        //GameObject cellObject1 = Instantiate(cellPrefab, content);
        //CellController cellController1 = cellObject1.GetComponent<CellController>(); //CellController�� �ҷ�����
        //cellController1.SetData(corp1); //corp1 ����
        //
        //GameObject cellObject2 = Instantiate(cellPrefab, content);
        //CellController cellController2 = cellObject2.GetComponent<CellController>(); //CellController�� �ҷ�����
        //cellController2.SetData(corp2); //corp2 ����


    }

}
