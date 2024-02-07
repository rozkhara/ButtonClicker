using TMPro;
using UnityEngine;

public class UsernameEdit : MonoBehaviour
{
    public TMP_Text Factory_name_set_panel;// text에 표시될 공장 이름
    public TMP_Text User_name_set_panel ;  // text에 표시될 유저 이름

    public TMP_InputField Factory_name_input ; 
    public TMP_InputField User_name_input ;

    public TMP_Text Factory_name_score_panel;
    public TMP_Text User_name_score_panel;

    private void Start()
    {
        Factory_name_set_panel.text = "Button Factory";
        User_name_set_panel.text = "User"; 
    }

    public void Edit_Factory_name_end_edit()
    {
        Factory_name_set_panel.text = Factory_name_input.text;
        Factory_name_score_panel.text = Factory_name_input.text;
    }
    public void Edit_User_name_end_edit()
    {
        User_name_set_panel.text = User_name_input.text;
        User_name_score_panel.text = User_name_input.text;
    }





}
