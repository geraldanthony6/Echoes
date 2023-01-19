using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//End Screen Manager
public class EndManager : MonoBehaviour
{
    public static int curr = 0;
    public GameObject text0;
    public GameObject text1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && curr == 0)
        {
            text1.SetActive(true);
            text0.SetActive(false);
            curr++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && curr == 1)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
