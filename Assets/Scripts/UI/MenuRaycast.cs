using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class MenuRaycast : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.GetComponent<Button>() != null)
                {
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }
}