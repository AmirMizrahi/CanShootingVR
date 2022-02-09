using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    public bool         v_WasHit = false;

    public void OnHit(float hitForce, Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(hitForce * direction);
        v_WasHit = true;
    }
}
