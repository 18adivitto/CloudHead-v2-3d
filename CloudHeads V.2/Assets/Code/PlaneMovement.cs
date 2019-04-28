using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float speed;
    public float planeTwoSpeed;


    private Renderer[] _renderers;
    private bool _isWrappingX = true;
    private bool _isWrappingY = true;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _renderers = GetComponentsInChildren<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        
        transform.position += new Vector3  (speed*Time.deltaTime,0,0 );
        ScreenWrap();
    }

    void ScreenWrap()
    {
        bool isVisible = CheckRenderers();

        if (isVisible)
        {
            _isWrappingX = false;
            _isWrappingY = false;
            return;
        }
        if(_isWrappingX && _isWrappingY)
        {
            return;
        }

        Vector3 newPosition = transform.position;

        if (newPosition.x > 1 || newPosition.x < 1)
        {
            newPosition.x = -newPosition.x;
            _isWrappingX = true;
        }
        
        if (newPosition.y> 1 || newPosition.y < 1)
        {
            newPosition.y = -newPosition.x;
            _isWrappingY= true;
        }

        transform.position = newPosition;
    }

    bool CheckRenderers()
    {
        foreach (Renderer renderer in _renderers)
        {
            if (renderer.isVisible)
            {
                return true;
            }
        }
        return false;
    }
    
 
}
