using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneManager : MonoBehaviour

{

    public static AirPlaneManager instance;

    public Vector3[] startPosition;
    public Vector3[] startRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
