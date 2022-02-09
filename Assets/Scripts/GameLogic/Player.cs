using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKeyDown)
        {
            RaycastHit      hit;
            
            FindObjectOfType<AudioManager>().Play("Shooting");

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.GetComponent<Can> () != null)
                {
                    StartCoroutine(ExecuteAfterTime(0.1f));
                    hit.transform.GetComponent<Can>().OnHit(700, transform.forward);
                }

                else if (hit.transform.GetComponent<Button>() != null)
                {
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }

    IEnumerator ExecuteAfterTime(float i_Time)
    {
        yield return new WaitForSeconds(i_Time);
        FindObjectOfType<AudioManager>().Play("CanHit");
    }
}
