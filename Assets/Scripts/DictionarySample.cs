using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionarySample : MonoBehaviour
{
    /*
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

        Dictionary<string, string> corp3 = new Dictionary<string, string>();
        corp3["no"] = "";
        corp3["species"] = "";
        corp3["company"] = "";

        Dictionary<string, string> corp4 = new Dictionary<string, string>();
        corp4["no"] = "";
        corp4["species"] = "";
        corp4["company"] = "";

        Dictionary<string, string> corp5 = new Dictionary<string, string>();
        corp5["no"] = "";
        corp5["species"] = "";
        corp5["company"] = "";

        List<Dictionary<string, string>> corpBook = new List<Dictionary<string, string>>();
        corpBook.Add(corp1);
        corpBook.Add(corp2);
        corpBook.Add(corp3);
        corpBook.Add(corp4);
        corpBook.Add(corp5);

        // 불러오기
        Dictionary<string, string> dict = corpBook[0];
        Debug.Log(dict["company"]);

        //프리팹 Cell을 가져와서 ScrollView의 Content 안에 생성
        GameObject cellObject1 = Instantiate(cellPrefab, content);
        CellController cellController1 = cellObject1.GetComponent<CellController>(); //CellController를 불러오기
        cellController1.SetData(corp1); //corp1 전달

        GameObject cellObject2 = Instantiate(cellPrefab, content);
        CellController cellController2 = cellObject2.GetComponent<CellController>(); //CellController를 불러오기
        cellController2.SetData(corp2); //corp2 전달

        GameObject cellObject3 = Instantiate(cellPrefab, content);
        CellController cellController3 = cellObject3.GetComponent<CellController>(); //CellController를 불러오기
        cellController3.SetData(corp3); //corp3 전달

        GameObject cellObject4 = Instantiate(cellPrefab, content);
        CellController cellController4 = cellObject4.GetComponent<CellController>(); //CellController를 불러오기
        cellController4.SetData(corp4); //corp4 전달

        GameObject cellObject5 = Instantiate(cellPrefab, content);
        CellController cellController5 = cellObject5.GetComponent<CellController>(); //CellController를 불러오기
        cellController5.SetData(corp5); //corp5 전달

    }
    */
}
