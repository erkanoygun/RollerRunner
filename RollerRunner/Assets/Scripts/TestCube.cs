using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour
{
    

    void FixedUpdate()
    {
        transform.position += transform.forward * 1.5f * Time.fixedDeltaTime;
    }

    public void NextGameButton()
    {
        
        //SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

}
