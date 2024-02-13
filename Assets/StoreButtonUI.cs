using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StoreButtonUI : MonoBehaviour
{
    private bool isopen = false;
    public GameObject storebutton;
    public GameObject storeview;


    public void onclick(){
        if (isopen == false)
        {
            isopen = true;
            storebutton.GetComponent<RectTransform>().anchoredPosition = new Vector2(320, 5);
            storeview.GetComponent<RectTransform>().anchoredPosition = new Vector2(650, 0);


        }
        else
        {
            isopen = false;
            storebutton.GetComponent<RectTransform>().anchoredPosition = new Vector2(940, 5);
            storeview.GetComponent<RectTransform>().anchoredPosition = new Vector2(1300, 0);

        }
    }
}
