using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapping : MonoBehaviour
{
    MeshRenderer MR;
    Vector3 viewportPosition;

    Camera cam;
    void Start()
    {
        MR = GetComponent<MeshRenderer>();
        cam = Camera.main;
    }

    void LateUpdate()
    {
        viewportPosition = cam.WorldToViewportPoint(transform.position);

        if (MR.isVisible)
        {
            //Debug.Log("PlayerVisible");
        }
        if (!MR.isVisible)
        {
            if (viewportPosition.x > 1)
            {
                Debug.Log("off right");
                transform.position = cam.ViewportToWorldPoint(new Vector3(0, viewportPosition.y, viewportPosition.z));
               
            }
            if (viewportPosition.x < 0)
            {
                Debug.Log("off left");
                transform.position = cam.ViewportToWorldPoint(new Vector3(1, viewportPosition.y, viewportPosition.z));

            }

        }
        //Debug.Log(viewportPosition);
    }

}
