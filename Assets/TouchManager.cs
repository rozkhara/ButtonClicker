using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    public Info infoPanel;
    public GameObject hitObject;

    // Update is called once per frame
    void Update()
    {
        CheckObject();

        if (Input.GetMouseButtonDown(0))
        {
            if(hitObject != null)
                StartCoroutine(LerpCamera(Camera.main.transform.position, hitObject.transform.position - 5f * Vector3.forward,true));
        }

    }

    void CheckObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Automata")
            {
                hitObject = hit.transform.gameObject;
                hitObject.GetComponent<Outline>().TurnOn();
            }
            else
            {
                hitObject?.GetComponent<Outline>().TurnOffOutline();
                hitObject = null;
            }
        }
        else
        {
            if (hitObject != null)
            {
                hitObject?.GetComponent<Outline>().TurnOffOutline();
            }
            hitObject = null;
        }
    }

    public IEnumerator LerpCamera(Vector3 startPos, Vector3 endPos, bool b)
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
        if (b)
            infoPanel.TurnOn(hitObject.name);
        else
            infoPanel.TurnOffObject();
        //hitObject.GetComponent<Outline>().TurnOn();
    }
}
