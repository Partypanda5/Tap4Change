using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightDisplayManager : MonoBehaviour
{
    public static DayNightDisplayManager instance;
    int systemHour = System.DateTime.Now.Hour;
    public Sprite dayTime;
    public Sprite nightTime;
    public GameObject background;
    public string saveDate;

    void Start () 
    {
        instance = this;
    }

    public void StartGame()
    {
        if (PlayerPrefs.HasKey("InitialDate"))
        {
            saveDate = PlayerPrefs.GetString("InitialDate");

            string currentDate = System.DateTime.Now.ToString();

            if (currentDate != saveDate)
            {
                PlayerPrefs.SetString("InitialDate", saveDate);
                SavePlayerPreferences.instance.SetInitialDailyValues();
            }
        }
        else
        {
            PlayerPrefs.SetString("InitialDate", saveDate);
        }

        if (systemHour >= 6 && systemHour <= 17)
        {
            background.GetComponent<Image>().sprite = dayTime;
        }

        if ((systemHour >= 0 && systemHour <= 5) || (systemHour >= 18))
        {
            background.GetComponent<Image>().sprite = nightTime;
        }
    }
}
