using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pie : MonoBehaviour
{
    private Explosion _explosionScript;
    void Start()
    {
        _explosionScript = gameObject.GetComponent<Explosion>();
    }


    public void CollisionEnter()
    {
        if (transform.parent.gameObject.name == "Pieces")
        {
            transform.parent.gameObject.SetActive(false);
            Destroy(transform.parent.gameObject, 3);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 3);
        }
        _explosionScript.explode();
    }


}
