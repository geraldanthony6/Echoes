using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Pause Menu Behavior
public class PauseManager : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public static bool HelpMenu = false;
    public static bool CharMenu = false;

    public static GameObject curr;
    public string restartLevel;
    public GameObject pauseMenuUI;
    public GameObject helpMenuUI;
    public GameObject WizUI;
    public GameObject ThiefUI;
    public GameObject KnightUI;
    public GameObject MCUI;

    public GameObject MainUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                if (HelpMenu)
                {
                    if (CharMenu)
                    {
                        CloseChar();
                    }
                    else
                    {
                        CloseHelp();
                    }

                }
                else
                {
                    ResumeGame();
                }
                
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(restartLevel);
        Time.timeScale = 1f;
    }

    public void ResumeGame() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void OpenHelp()
    {
        HelpMenu = true;
        pauseMenuUI.SetActive(false);
        helpMenuUI.SetActive(true);
        MainUI.SetActive(true);
        Debug.Log("Loading help");
    }

    public void CloseHelp()
    {
        HelpMenu = false;
        pauseMenuUI.SetActive(true);
        helpMenuUI.SetActive(false);
        Debug.Log("closing help");
    }



    // open and close help menus for the different characters

    public void CloseChar()
    {
        CharMenu = false;
        MainUI.SetActive(true);
        curr.SetActive(false);
    }
    public void OpenWiz()
    {
        CharMenu = true;
        curr = WizUI;
        MainUI.SetActive(false);
        WizUI.SetActive(true);
    }

    public void OpenKnight()
    {
        CharMenu = true;
        curr = KnightUI;
        MainUI.SetActive(false);
        KnightUI.SetActive(true);
    }

    public void OpenThief()
    {
        CharMenu = true;
        curr = ThiefUI;
        MainUI.SetActive(false);
        ThiefUI.SetActive(true);
    }

    public void OpenMC()
    {
        CharMenu = true;
        curr = MCUI;
        MainUI.SetActive(false);
        MCUI.SetActive(true);
    }
}
