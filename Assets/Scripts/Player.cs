using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    private ActionBasedController controller;

    // Update is called once per frame
    void Update()
    {
        controller = GetComponent<ActionBasedController>();
       // bool flag = controller.selectAction.action.ReadValue<bool>();
        if (Input.anyKeyDown)
        {
            RaycastHit hit;
            
            FindObjectOfType<AudioManager>().Play("Shooting");

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.GetComponent<Can> () != null)
                {
                    StartCoroutine(ExecuteAfterTime(0.1f));
                    hit.transform.GetComponent<Can>().OnHit(700, transform.forward);
                }
            }
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        FindObjectOfType<AudioManager>().Play("CanHit");
    }
}
