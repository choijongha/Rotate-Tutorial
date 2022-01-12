using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public PlayerRotate playerRotateScript;
    // Update is called once per frame
    void Update()
    {
        if (playerRotateScript.onLookRotation)
        {
            transform.Rotate(new Vector3(0, 50, 50) * Time.deltaTime);
        }
        
    }
}
