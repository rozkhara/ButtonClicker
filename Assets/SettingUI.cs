using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class SettingUI : MonoBehaviour
{   
    public GameObject Setting_panel ;

    public GameObject Setting_btn ;

    public void Set_onclick(){

        this.Setting_panel.SetActive(!Setting_panel.activeSelf) ; 

    }

















}
