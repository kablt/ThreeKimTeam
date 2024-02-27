using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVLoader : MonoBehaviour
{
    public TextAsset csvFile; //Unity Editor���� �Ҵ�
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
            if (rowValues.Length != 6) continue; //�� ����

            int no = int.Parse(rowValues[0]);
            int id = int.Parse(rowValues[1]);
            string region = rowValues[2];
            string city = rowValues[3];
            string species = rowValues[4];
            string company = rowValues[5];

           // Debug.Log($"��ȣ: {no}, ���ڵ�: {id}, ����(��): {region},����(�ñ�): {city},ǰ��: {species},��ü: {company}");
        }
    }

    //���࿡ region�� city�� dropdown���� ������ ���� ���ٸ�
    //���ڵ�, ǰ��, ��ü�� ������ �����´�.
    void MakeTable()
    {

    }

}