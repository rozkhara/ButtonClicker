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


    public void mousedown(){
        if (isopen == false)
        {
            isopen = true;
            storebutton.GetComponent<RectTransform>().anchoredPosition = new Vector2(284, 5);
            storeview.GetComponent<RectTransform>().anchoredPosition = new Vector2(392, 0);
        }
        else
        {
            isopen = false;
            storebutton.GetComponent<RectTransform>().anchoredPosition = new Vector2(467, 5);
            storeview.GetComponent<RectTransform>().anchoredPosition = new Vector2(600, 0);
        }
    }
}
