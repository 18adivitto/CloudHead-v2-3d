using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTextRotation : MonoBehaviour
{
    Quaternion startRot;
    
    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = startRot;
    }
}
