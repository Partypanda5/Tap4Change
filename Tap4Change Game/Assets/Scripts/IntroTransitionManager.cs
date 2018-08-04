using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroTransitionManager : MonoBehaviour
{

    public GameObject overlayPanel;

    public GameObject dataPanel1;
    public GameObject dataPanel2;
    public GameObject dataPanel3;
    public GameObject dataPanel4;

    public GameObject whiteBackGround;

    private int currActivePanel;

    public void BeginDataCapture()
    {
        if (PlayerPrefs.HasKey("PlayerPlayed"))
        {
            dataPanel1.SetActive(false);
            whiteBackGround.SetActive(false);
            overlayPanel.SetActive(false);
            StartGame();
        }
        else
        {
            dataPanel1.SetActive(true);
            overlayPanel.SetActive(false);
            currActivePanel = 1;
            PlayerPrefs.SetString("PlayerPlayed", "true");
        }
    }

    public void SwitchPanel()
    {
        switch (currActivePanel)
        {
            case (1):
                {
                    dataPanel1.SetActive(false);
                    dataPanel2.SetActive(true);
                    currActivePanel = 2;
                    break;
                }
            case (2):
                {
                    dataPanel2.SetActive(false);
                    dataPanel3.SetActive(true);
                    currActivePanel = 3;
                    break;
                }
            case (3):
                {
                    dataPanel3.SetActive(false);
                    dataPanel4.SetActive(true);
                    break;
                }
        }
    }

    public void StartGame()
    {
        dataPanel4.SetActive(false);
        PeopleInQueueManager.instance.StartGame();
        DayNightDisplayManager.instance.StartGame();
        whiteBackGround.SetActive(false);
    }
}


