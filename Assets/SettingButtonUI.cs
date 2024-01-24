using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SettingButtonUI : MonoBehaviour
{
    public GameObject settingMenu ;
    public GameObject settingbtn ;
    public GameObject exitbtn ;


    public bool isopen = false ;
    

    public void onclick(){
        
        This.settingMenu.SetActive

        if(isopen == false){
            isopen = true ;
            settingMenu.SetActive(true) ;
        }
        else{
            isopen = false ;
            settingMenu.SetActive(false) ; 
        }
    }   


    

    
}
