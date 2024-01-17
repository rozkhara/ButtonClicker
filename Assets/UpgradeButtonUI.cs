
using UnityEngine;

public class UpgradeButtonUI : MonoBehaviour
{
    public Era target;
    public GameObject upgradebutton;

    public void onclick()
    {
        GameManager.Instance.store.Buyeff(target);
    }
}