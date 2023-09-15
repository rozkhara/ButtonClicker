using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gadget : MonoBehaviour
{
    public int effeciency;
    public int price;

    public void Autoclick(int effeciency)
    {
        GameManager.Instance.ChangeScore(effeciency);
    }    


}
