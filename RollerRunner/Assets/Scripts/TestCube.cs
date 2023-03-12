using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //rb.AddForce(transform.up * 50f);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Her Cube: "+other.gameObject.name);
    }
}
