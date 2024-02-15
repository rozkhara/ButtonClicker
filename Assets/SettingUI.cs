using System.Collections;
using System.Collections.Generic;
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
        SoundManager.Instance.PlaySFXSound("MenuSound");
    }

    //exit 버튼 클릭하면 다시 set버튼이 나오게, set panel 없어짐 
    public void Exit_onclick()
    {
        this.Setting_panel.SetActive(false);
        Setting_btn.SetActive(true);
        BackgroundPanel.SetActive(false) ;
        SoundManager.Instance.PlaySFXSound("MenuSound");
    }
}
