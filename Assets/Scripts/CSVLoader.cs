using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVLoader : MonoBehaviour
{
    public TextAsset csvFile; //Unity Editor에서 할당
    void Start()
    {
        ReadCSV(csvFile);
    }

    void ReadCSV(TextAsset csv)
    {
        string[] rows = csv.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 1; i < rows.Length; i++)
        {
            string[] rowValues = rows[i].Split(',');
            if (rowValues.Length != 6) continue; //열 개수

            int no = int.Parse(rowValues[0]);
            int id = int.Parse(rowValues[1]);
            string region = rowValues[2];
            string city = rowValues[3];
            string species = rowValues[4];
            string company = rowValues[5];

           // Debug.Log($"번호: {no}, 농가코드: {id}, 지역(도): {region},지역(시군): {city},품종: {species},업체: {company}");
        }
    }

    //만약에 region과 city가 dropdown에서 선택한 값과 같다면
    //농가코드, 품종, 업체의 정보를 가져온다.
    void MakeTable()
    {

    }

}