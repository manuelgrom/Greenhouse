using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float timeBetweenBullets = 0.15f;
    public GameObject projectile; //our bullet

    private float m_nextBullet;
    private Vector3 m_rotation;
    // Use this for initialization
    void Awake()
    {
        m_nextBullet = 0.0f; //fire direct
        m_rotation = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController myPlayer = this.transform.root.GetComponent<PlayerController>();

        if (Input.GetAxisRaw("Fire1") > 0 && m_nextBullet < Time.time)
        {
            m_nextBullet = Time.time + timeBetweenBullets;

            if (myPlayer.GetFacing() == -1f)
            {
                m_rotation = new Vector3(0, -90, 0);
            }
            else
            {
                m_rotation = new Vector3(0, 90, 0);
            }

            Instantiate(projectile, this.transform.position, Quaternion.Euler(m_rotation));
        }
    }
}
