using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevConsole : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            SavePlayerPreferences.instance.SetBodyWashPreference(0);
            SavePlayerPreferences.instance.SetClothesWashPreference(0);
            SavePlayerPreferences.instance.SetDishesWashPreference(0);
            Debug.Log("do it");
        }
        if (Input.GetKeyDown("k"))
        {
            SavePlayerPreferences.instance.SetBodyWashPreference(1);
            SavePlayerPreferences.instance.SetClothesWashPreference(1);
            SavePlayerPreferences.instance.SetDishesWashPreference(1);
            Debug.Log("do it");
        }
    }
}
