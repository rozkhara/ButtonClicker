using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PanelManager: MonoBehaviour
{
    public UnityEngine.UI.Image viewport;

    public UnityEngine.UI.Image prefab1;
    public UnityEngine.UI.Image prefab2;
    public UnityEngine.UI.Image prefab3;

    public class StoreComponent
    {
        public UnityEngine.UI.Image item;
        public int item_id;

        public StoreComponent(UnityEngine.UI.Image item, int item_id)
        {
            this.item = item;
            this.item_id = item_id;
        }

        public void onclick()
        {
            BuyButtonUI.target = GameManager.automata_list[item_id];
        }
    }

    public static List<StoreComponent> items;
    public StoreComponent item1;

    private void Start()
    {
        UnityEngine.UI.Image StorePanel1 = Instantiate(prefab1, this.transform.position, Quaternion.identity);
        StorePanel1.transform.SetParent(GameObject.Find("Content").transform, false);
        StoreComponent item1 = new StoreComponent(StorePanel1, 1);
        StoreComponent item2 = new StoreComponent(prefab2, 2);
        items.Add(item1);
        items.Add(item2);
        
    }


}