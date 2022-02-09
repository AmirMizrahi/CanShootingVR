using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    public bool wasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit(float hitForce, Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(hitForce * direction);
        wasHit = true;
    }
}
