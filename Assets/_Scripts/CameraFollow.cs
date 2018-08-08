using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; //In this case the target to follow is the player
    public float smoothing = 5.0f; //how fast the camera follows

    private Vector3 m_offset; // cam offset value
    private Vector3 m_targetCamPos; // target possition of the camera
    // Use this for initialization
    void Start()
    {
        m_offset = this.transform.position - target.position; //sets the offset
        m_targetCamPos = Vector3.zero; // null the vector
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_targetCamPos = target.position + m_offset; //sets the target cam pos

        this.transform.position = Vector3.Lerp(this.transform.position, m_targetCamPos, smoothing * Time.deltaTime); //acctual lerp / cam movement
    }
}
