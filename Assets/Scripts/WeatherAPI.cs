using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class WeatherAPI : MonoBehaviour
{
    private readonly string apiKey = "6c2fd243991dd8fb07cf61450223be76";
    private readonly string city = "Seoul";

    public TextMeshProUGUI weatherText;
    public WeatherData weatherInfo;

    void Start()
    {
        StartCoroutine(GetWeatherInfo());
    }

    IEnumerator GetWeatherInfo()
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log($"Error : {webRequest.error}");
            }
            else
            {
                GetWeatherInfo(webRequest.downloadHandler.text);
            }
        }
    }

    private void GetWeatherInfo(string jsonData)
    {
        //Json �Ľ� ���� ����
        weatherInfo = JsonUtility.FromJson<WeatherData>(jsonData);

        weatherText.text = weatherInfo.name + "\n";
        weatherText.text += "����µ� " + weatherInfo.main.temp.ToString("N1") + "��C\n";
        weatherText.text += "���� " + weatherInfo.main.humidity + "\n";
        weatherText.text += "ǳ�� " + weatherInfo.wind.speed + "m/s";
    }
}