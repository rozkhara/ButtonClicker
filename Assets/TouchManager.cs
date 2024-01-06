using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    public Info infoPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Automata")
                {
                    Debug.Log(hit.transform.gameObject.name);

                    Camera.main.transform.position = hit.transform.position - 5f * Vector3.forward;

                    //infoPanel.SetActive(true, hit.transform.gameObject.name);
                    infoPanel.TurnOn(hit.transform.gameObject.name);
                }
            }
        }
    }
}
