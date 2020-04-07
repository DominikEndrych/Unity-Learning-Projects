using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float turnSpeed = 20;

    private Vector3 m_Movement;
    private Quaternion m_Rotation = Quaternion.identity; //proměnná pro uchování rotace
    private Animator m_Animator;
    private Rigidbody m_PlayerRb;
    private AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_PlayerRb = gameObject.GetComponent<Rigidbody>();
        m_AudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        //přidělení pohybového vektoru
        m_Movement.Set(horizontalMovement, 0.0f, verticalMovement);
        m_Movement.Normalize(); //normalizace

        //je hráč v pohybu?
        bool hasHorizontalInput = !Mathf.Approximately(horizontalMovement, 0.0f);
        bool hasVerticalInput = !Mathf.Approximately(verticalMovement, 0.0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        m_Animator.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        //kam by se měl hráč otočit?
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0.0f);

        m_Rotation.SetLookRotation(desiredForward); //uloží rotaci desiredForward

    }

    //speciální metoda, která umožní změnit, jak se aplikuje Root Motion
    private void OnAnimatorMove()
    {
        m_PlayerRb.MovePosition(m_PlayerRb.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_PlayerRb.MoveRotation(m_Rotation);
    }
}
