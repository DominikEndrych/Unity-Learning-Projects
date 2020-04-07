using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float topBound;
    private float bottomBound;

    // Start is called before the first frame update
    void Start()
    {
        topBound = 30;
        bottomBound = -10;

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < bottomBound || transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
    }
}
