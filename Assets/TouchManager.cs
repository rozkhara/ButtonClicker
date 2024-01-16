using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    public Info infoPanel;
    public GameObject hitObject;
    public GameObject clickedObject;
    public IEnumerator nowCameraLerpCorotuine;

    // Update is called once per frame
    void Update()
    {
        CheckObject();

        if (Input.GetMouseButtonDown(0))
        {
            if (hitObject != null)
            {
                LerpCameraAni(Camera.main.transform.position, Vector3.zero, true);
            }
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

    public void LerpCameraAni(Vector3 startPos, Vector3 endPos, bool b)
    {
        if (nowCameraLerpCorotuine != null)
        {
            StopCoroutine(nowCameraLerpCorotuine);
            infoPanel.TurnOffObject();
            clickedObject = null;
        }

        if (b)
        {
            clickedObject = hitObject;
            endPos = clickedObject.transform.position - 5f * Vector3.forward;
        }
        nowCameraLerpCorotuine = LerpCamera(startPos, endPos, b);
        StartCoroutine(nowCameraLerpCorotuine);
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
            infoPanel.TurnOn(clickedObject.name);
        else
        {
            infoPanel.TurnOffObject();
            clickedObject = null;
        }
        //hitObject.GetComponent<Outline>().TurnOn();
    }
}
