using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position -= new Vector3(0.0f, verticalSpeed);
        //var newPosition = new Vector3(0.0f, verticalSpeed, 0.0f);
        //transform.position -= newPosition;
    }
    private void _Reset()
    {
        transform.position = new Vector3(0.0f, verticalBoundary);
        //transform.position = new Vector3(0.0f, 10.0f, 0.0f);
    }

    private void _CheckBounds()
    {
        // check bottom bounds
        if(transform.position.y <= -verticalBoundary)
        {
            _Reset();
        }
    }
}


// X5.62  Y10