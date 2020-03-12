using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class KeyboardNavigation : MonoBehaviour
{
    private int gumb = -1;
    void Start()
    {
    }
    private void selectButton()
    {
        FindObjectOfType<AudioManager>().PlayOnce("button_hover"); //zvok

        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            if (gumb == 0)
            {
                GameObject.Find("Button").GetComponent<Button>().Select();
            }
            else if (gumb == 1)
            {
                GameObject.Find("Button (1)").GetComponent<Button>().Select();
            }
            else if (gumb == 2)
            {
                GameObject.Find("Button (2)").GetComponent<Button>().Select();
            }
        }
        else
            if (gumb == 0)
            {
                GameObject.Find("Button").GetComponent<Button>().Select();
            }
            else if (gumb == 1)
            {
                GameObject.Find("HomeButton").GetComponent<Button>().Select();
            }
            else if (gumb == 2)
            {
                GameObject.Find("RestartButton").GetComponent<Button>().Select();
            }
            else if (gumb == 3)
            {
                GameObject.Find("PlayButton").GetComponent<Button>().Select();
            }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //ESC - pauza
        {
            if (SceneManager.GetActiveScene().name == "Settings")
            {
                GameObject.Find("Button").GetComponent<ButtonControler>().HomeClick();
            }
            else
                if (GameObject.Find("PlayButton").GetComponent<ButtonControler>().Paused || GameObject.Find("PlayButton").GetComponent<ButtonControler>().Over)
                {
                    GameObject.Find("PlayButton").GetComponent<ButtonControler>().SmallPlayClick();
                }
                else
                {
                    GameObject.Find("PlayButton").GetComponent<ButtonControler>().PauseClick();
                }
            gumb = -1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) //pomikanje v menuju desno
        {
            if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                gumb++;
                if (gumb > 3)
                {
                    gumb = 3;
                }

                selectButton();
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) //pomikanje v menuju levo
        {
            if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                gumb--;
                if (gumb < 0)
                {
                    gumb = 0;
                }
                selectButton();
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) //pomikanje v menuju dol
        {
            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                gumb++;
                if (gumb > 2)
                {
                    gumb = 2;
                }
                selectButton();
            }else
            if (SceneManager.GetActiveScene().name == "SampleScene") 
            {
                GameObject.Find("Answer2").GetComponent<Button>().Select();
                gumb = 5;
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) //pomikanje v menuju gor
        {
            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                gumb--;
                if (gumb < 0)
                {
                    gumb = 0;
                }
                selectButton();
            }else if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                GameObject.Find("Answer1").GetComponent<Button>().Select();
                gumb = 4;
            }
        }
        if (SceneManager.GetActiveScene().name == "Settings" && (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)))
        {
            FindObjectOfType<AudioManager>().PlayOnce("button_hover"); //zvok
            GameObject.Find("Button").GetComponent<Button>().Select();
        }
        if (SceneManager.GetActiveScene().name == "Settings" && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape)))
        {
            GameObject.Find("Button").GetComponent<ButtonControler>().HomeClick();
        }
        if (Input.GetKeyDown(KeyCode.Return))  //ENTER key
        {
            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                if (gumb == 0)
                {
                    GameObject.Find("Button").GetComponent<ButtonControler>().PlayClicked();
                }
                else if (gumb == 1)
                {
                    GameObject.Find("Button (1)").GetComponent<ButtonControler>().SettingsClick();
                }
                else if (gumb == 2)
                {
                    GameObject.Find("Button (2)").GetComponent<ButtonControler>().ExitClick();
                }
            }
            else
                if (gumb == 0)
                {
                    GameObject.Find("PlayButton").GetComponent<ButtonControler>().PauseClick();
                }
                else if (gumb == 1)
                {
                    GameObject.Find("PlayButton").GetComponent<ButtonControler>().HomeClick();
                }
                else if (gumb == 2)
                {
                    GameObject.Find("PlayButton").GetComponent<ButtonControler>().RestartClick();
                }
                else
                if (gumb == 3)
                {
                    GameObject.Find("PlayButton").GetComponent<ButtonControler>().SmallPlayClick();
                }
                else
                if (gumb == 4)
                {
                    GameObject.Find("Answer1").GetComponent<ButtonControler>().onAnswer1Click();
                }
                else
                if (gumb == 5)
                {
                    GameObject.Find("Answer2").GetComponent<ButtonControler>().onAnswer2Click();
                }
            gumb = -1;
        }

    }
}
