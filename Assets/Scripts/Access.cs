using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Access : MonoBehaviour
{
    // Reference to the ApiManager script
    public ApiManager apiManager;

    // Timer variables
    private float timer = 0f;
    private float updateInterval = 10f; // Update every 10 seconds

    // Start is called before the first frame update
    void Start()
    {
        // Make sure to assign the ApiManager instance in the Unity Editor
        if (apiManager == null)
        {
            Debug.LogError("ApiManager reference not set in the Unity Editor!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update every 10 seconds
        timer += Time.deltaTime;
        if (timer >= updateInterval)
        {
            // Access the values from ApiManager and print them in the console
            float inTpValue = apiManager.InTpValue;
            float inHdValue = apiManager.InHdValue;
            string frmhsIdValue = apiManager.FrmhsIdValue;
            

            Debug.Log($"Access Script - inTp: {inTpValue}, inHd: {inHdValue}, frmhsId: {frmhsIdValue}");
           
            // Reset the timer
            timer = 0f;
        }
    }
}
