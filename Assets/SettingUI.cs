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
    public GameObject Exit_btn;
    public GameObject BackgroundPanel;



    //setting 버튼을 클릭했을땐 set버튼이 사라지게, set panel 나옴
    public void Set_onclick()
    {    
        this.Setting_panel.SetActive(true); 
        Setting_btn.SetActive(false);
        BackgroundPanel.SetActive(true);
    }


    //exit 버튼 클릭하면 다시 set버튼이 나오게, set panel 없어짐 
    public void Exit_onclick()
    {
        Setting_btn.SetActive(true);
        this.Setting_panel.SetActive(false);
        BackgroundPanel.SetActive(false) ;
    }
}
