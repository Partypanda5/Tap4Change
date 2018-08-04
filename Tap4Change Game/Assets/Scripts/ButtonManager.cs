using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public static ButtonManager instance;
    public Image[] allButtons;
    public Sprite[] dishesSprites;
    public Sprite[] bodyWashSprites;
    public Sprite[] clothesWashSprites;
    public Sprite toiletSprite;

    void Start()
    {
        instance = this;
    }

    public void SetButton(string buttonName, int value)
    {
        switch (buttonName)
        {
            case ("dish"):
                {
                    allButtons[0].sprite = dishesSprites[value];
                    break;
                }
            case ("toilet"):
                {
                    allButtons[1].sprite = toiletSprite;
                    break;
                }
            case ("body"):
                {
                    allButtons[2].sprite = bodyWashSprites[value];
                    break;
                }
            case ("clothes"):
                {
                    allButtons[3].sprite = clothesWashSprites[value];
                    break;
                }
        }
    }
}
