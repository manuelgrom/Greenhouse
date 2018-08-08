using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public float range = 10.0f;
    public float damage = 5.0f;

    private Ray m_Shootray;
    private RaycastHit m_shootHit;

    private int m_shootableMask;
    private LineRenderer m_gunLine;

    // Use this for initialization
    void Awake()
    {
        m_shootableMask = LayerMask.GetMask("Shootable"); //resturns shootable layer
        m_gunLine = GetComponent<LineRenderer>(); //this linerender on go 

        m_Shootray.origin = this.transform.position;
        m_Shootray.direction = this.transform.forward;
        m_gunLine.SetPosition(0, this.transform.position);

        if (Physics.Raycast(m_Shootray, out m_shootHit, range,m_shootableMask))
        {
            //hit enemy goes here


            m_gunLine.SetPosition(1, m_shootHit.point);
        }
        else
        {
            m_gunLine.SetPosition(1, m_Shootray.origin + m_Shootray.direction * range);
        }
    }
}
