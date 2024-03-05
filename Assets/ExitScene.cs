using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void CloseTap()
    {
        Destroy(gameObject);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
