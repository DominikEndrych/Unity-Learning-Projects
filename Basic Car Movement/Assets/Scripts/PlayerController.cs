using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float turnSpeed;

    [SerializeField] float speed;
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] private float horsePower = 0;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * speed * forwardInput * Time.deltaTime);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
        speedometerText.SetText("Speed: " + speed + "km/h");
    }
}
