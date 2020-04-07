using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject Player;

    private Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        Offset = new Vector3(0, 5, -7);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + Offset;
    }
}
