using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StoreButtonUI : MonoBehaviour
{
    private bool isopen = true;
    public GameObject storebutton;
    public GameObject storeview;
    public GameObject buybutton;
    public GameObject upgradebutton;


    public void onclick(){
        if (isopen == false)
        {
            isopen = true;
            storebutton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-16, 5);
            storeview.GetComponent<RectTransform>().anchoredPosition = new Vector2(200, 0);
            buybutton.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, 0);
            upgradebutton.GetComponent<RectTransform>().anchoredPosition = new Vector2(300, 0);

        }
        else
        {
            isopen = false;
            storebutton.GetComponent<RectTransform>().anchoredPosition = new Vector2(384, 5);
            storeview.GetComponent<RectTransform>().anchoredPosition = new Vector2(650, 0);
            buybutton.GetComponent<RectTransform>().anchoredPosition = new Vector2(650, 0);
            upgradebutton.GetComponent<RectTransform>().anchoredPosition = new Vector2(650, 0);
        }
    }
}
