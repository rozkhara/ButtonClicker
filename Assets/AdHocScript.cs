using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdHocScript : MonoBehaviour
{
    public void UpdateFactoryName(string s)
    {
        GameManager.Instance.SetFactoryName(s);
    }

    public void UpdateUserName(string s)
    {
        GameManager.Instance.SetUserName(s);
    }
}
