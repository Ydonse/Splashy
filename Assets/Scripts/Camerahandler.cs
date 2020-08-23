using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerahandler : MonoBehaviour
{
    private float offset = 7f;
    public Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, ball.position.z - offset);
    }
}
