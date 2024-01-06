
using UnityEngine;

public class UpgradeButtonUI : MonoBehaviour
{
    public era target;
    public GameObject upgradebutton;

    public void onclick()
    {
        GameManager.Instance.store.Buyeff(target);
    }
}