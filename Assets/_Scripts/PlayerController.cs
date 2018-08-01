using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region PublicVar
    public float runSpeed = 0.0f;
    #endregion PublicVar

    #region PrivateVar
    private Rigidbody m_myRB;
    private Animator m_myAnimator;
    private float m_move;
    private bool m_facingRight;
    private Vector3 m_myScale; 
    #endregion PrivateVar

    // Use this for initialization
    private void Start()
    {
        m_myRB = GetComponent<Rigidbody>();
        m_myAnimator = GetComponent<Animator>();
        m_move = 0.0f;
        m_facingRight = true;
        m_myScale = Vector3.zero;
    }

    // Update is called once per frame (rate dependent)
    private void Update()
    {

    }
    //fixed rate after physic engin is run! Its constant
    private void FixedUpdate()
    {
        // Keys A = -1 Key D = 1
        m_move = Input.GetAxis("Horizontal");
        m_myAnimator.SetFloat("speed", Mathf.Abs(m_move));

        //movement
        m_myRB.velocity = new Vector3(m_move * runSpeed, m_myRB.velocity.y, 0);

        if (m_move > 0 && !m_facingRight)
        {
            Flip();
        }
        else if (m_move < 0 && m_facingRight)
        {
            Flip();
        }
    }
    //Flipping the Character L/R 
    private void Flip()
    {
        //Flipping via gameObject Scale 
        m_facingRight = !m_facingRight;
        m_myScale = transform.localScale;
        m_myScale.z *= -1;
        transform.localScale = m_myScale;
    }
}
