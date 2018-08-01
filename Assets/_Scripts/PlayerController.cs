using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region PublicVar
    public float runSpeed;
    public float walkSpeed;

    //Jumping
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    #endregion PublicVar

    #region PrivateVar
    private Rigidbody m_myRB;
    private Animator m_myAnimator;
    private float m_move;
    private bool m_facingRight;
    private Vector3 m_myScale;
    private float m_sneaking;

    //for jumping
    private bool m_grounded;
    private Collider[] m_groundCollisions;
    private float m_groundCheckRadius = 0.2f;

    #endregion PrivateVar

    // Use this for initialization
    private void Start()
    {
        m_myRB = GetComponent<Rigidbody>();
        m_myAnimator = GetComponent<Animator>();
        m_move = 0.0f;
        m_facingRight = true;
        m_myScale = Vector3.zero;
        m_sneaking = 0.0f;
        m_grounded = false;
    }

    // Update is called once per frame (rate dependent)
    private void Update()
    {

    }
    //fixed rate after physic engin is run! Its constant
    private void FixedUpdate()
    {
        //jump
        if (m_grounded && Input.GetAxis("Jump") > 0)
        {
            m_grounded = false;
            m_myAnimator.SetBool("grounded", m_grounded);
            m_myRB.AddForce(new Vector3(0, jumpHeight, 0)); //actual jump
            Debug.Log("Space bar pressed");
        }
        
        //Jump collision check
        m_groundCollisions = Physics.OverlapSphere(groundCheck.position, m_groundCheckRadius, groundLayer);
        if (m_groundCollisions.Length > 0)
        {
            m_grounded = true;
            Debug.Log("is grounded");
        }
        else
        {
            m_grounded = false;
            Debug.Log("is not  grounded");

        }

        m_myAnimator.SetBool("grounded", m_grounded);

        // Keys A = -1 Key D = 1
        m_move = Input.GetAxis("Horizontal");
        m_myAnimator.SetFloat("speed", Mathf.Abs(m_move));

        //Sneaking /Fire3 = left shift button in unity input settings 
        m_sneaking = Input.GetAxisRaw("Fire3");
        m_myAnimator.SetFloat("sneaking", m_sneaking);

        //movement
        if (m_sneaking > 0 && m_grounded) //shift is pressed
        {
            m_myRB.velocity = new Vector3(m_move * walkSpeed, m_myRB.velocity.y, 0);
        }
        else //shift not pressed 
        {
            m_myRB.velocity = new Vector3(m_move * runSpeed, m_myRB.velocity.y, 0);
        }
        //Flipping Character
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
