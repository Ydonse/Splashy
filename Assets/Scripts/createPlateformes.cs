using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createPlateformes : MonoBehaviour
{
    public GameObject plateforme;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos.z = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 50; i++)
            {
                GameObject nouvelle = Instantiate(plateforme, new Vector3(0, -0.5f, pos.z), Quaternion.identity);
                pos.z += 3;
            }
        }
    }
}
