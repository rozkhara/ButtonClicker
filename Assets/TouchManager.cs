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

                    //Camera.main.transform.position = hit.transform.position - 5f * Vector3.forward;

                    StartCoroutine(LerpCamera(Camera.main.transform.position, hit.transform.position - 5f * Vector3.forward, hit.transform.gameObject.name));

                    //infoPanel.SetActive(true, hit.transform.gameObject.name);
                    //infoPanel.TurnOn(hit.transform.gameObject.name);
                }
            }
        }
    }

    public IEnumerator LerpCamera(Vector3 startPos, Vector3 endPos,string str)
    {
        float delta = 0;
        float duration = 2f;

        while (delta <= duration)
        {
            float t = delta / duration;
            //t = 0.25f - Mathf.Pow(t-0.5f, 2);
            t = Mathf.Sqrt(1 - Mathf.Pow(t - 1, 4));
            //t = t < 0.5f ? t * t : 1 - (1 - t) * (1 - t);

            Camera.main.transform.position = Vector3.Lerp(startPos, endPos, t);

            delta += Time.deltaTime;
            yield return null;
        }

        Camera.main.transform.position = endPos;
        infoPanel.TurnOn(str);
    }
}
