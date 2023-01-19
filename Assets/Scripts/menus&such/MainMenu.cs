using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Main Menu Buttons
public class MainMenu : MonoBehaviour
{
    public string firstLevel;
    public GameObject optionsScreen;
    // Start is called before the first frame update

    public void StartGame() 
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
