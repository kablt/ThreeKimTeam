using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionarySample : MonoBehaviour
{
    // 셀이 만들어질 Trasform 값과 가져올 프리팹 GameObject를 SerializeField로 추가
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

        // 불러오기
        Dictionary<string, string> dict = corpBook[0];
        Debug.Log(dict["company"]);

        ////프리팹 Cell을 가져와서 ScrollView의 Content 안에 생성
        //GameObject cellObject1 = Instantiate(cellPrefab, content);
        //CellController cellController1 = cellObject1.GetComponent<CellController>(); //CellController를 불러오기
        //cellController1.SetData(corp1); //corp1 전달
        //
        //GameObject cellObject2 = Instantiate(cellPrefab, content);
        //CellController cellController2 = cellObject2.GetComponent<CellController>(); //CellController를 불러오기
        //cellController2.SetData(corp2); //corp2 전달


    }

}
