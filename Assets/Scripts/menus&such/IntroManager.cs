using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Intro Screen Manager
public class IntroManager : MonoBehaviour
{
    public static int curr = 0;
    public GameObject text0;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject LoadingScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && curr == 0)
        {
            text0.SetActive(true);
            curr++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && curr == 1)
        {
            text1.SetActive(true);
            text0.SetActive(false);
            curr++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && curr == 2)
        {
            text2.SetActive(true);
            text1.SetActive(false);
            curr++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && curr == 3)
        {
            text3.SetActive(true);
            text2.SetActive(false);
            curr++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && curr == 4)
        {
            LoadingScreen.SetActive(true);
            SceneManager.LoadScene("Final");
        }
    }
}