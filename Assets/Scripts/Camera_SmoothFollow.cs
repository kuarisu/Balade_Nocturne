using UnityEngine;
using System.Collections;

public class Camera_SmoothFollow : MonoBehaviour {

    [SerializeField]
    private Transform m_Player; //Target follow by camera
    [SerializeField]
    private float m_SmoothTime; 

    public Vector3 m_Offset; //how long will the camera take to follow the target
    private Vector3 m_SmoothVel;
    //private Vector3 m_SmoothMove;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //m_SmoothMove = Vector3.SmoothDamp(transform.position, m_Player.position + m_Offset, ref m_SmoothVel, m_SmoothTime);
        transform.position = Vector3.SmoothDamp(transform.position, m_Player.position + m_Offset, ref m_SmoothVel, m_SmoothTime);
        transform.LookAt(m_Player.transform.position, Vector3.up);

    }
}
