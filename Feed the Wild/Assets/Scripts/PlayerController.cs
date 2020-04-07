using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float fieldWidth;    //bounds

    public GameObject projectilePrefab;

    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //fire new projectile after the space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

    }

    void FixedUpdate()
    {
        //keep the player in bounds
        if(transform.position.x < -fieldWidth)
        {
            transform.position = new Vector3(-fieldWidth, transform.position.y, transform.position.z);
        }

        if(transform.position.x > fieldWidth)
        {
            transform.position = new Vector3(fieldWidth, transform.position.y, transform.position.z);
        }

        //moving player left and right
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
    }
}
