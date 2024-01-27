using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Userinfo : MonoBehaviour
{
    public TMP_Text Factory_name ; // text에 표시될 공장 이름
    public TMP_Text User_name;  // text에 표시될 유저 이름

    public TMP_InputField Factory_name_input ; 
    public TMP_InputField User_name_input ;

    

    public void Edit_Factory_name()
    {
        Factory_name.text = Factory_name_input.text;
    }
    public void Edit_User_name()
    {
        User_name.text = User_name_input.text;
    }





}
