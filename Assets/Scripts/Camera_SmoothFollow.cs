using UnityEngine;
using System.Collections;

public class Camera_SmoothFollow : MonoBehaviour {

    private Transform m_Player; //Target follow by camera
    [SerializeField]
    private float m_SmoothTime; 

    public Vector3 m_Offset; //how far the Camera start from the target
    private Vector3 m_SmoothVel; //?
    private Vector3 m_SmoothMove; //how the Camera takes to follow the object

    private Ray m_CameraTargetRay;
    [SerializeField]
    private float m_MinimumDistance;
    public RaycastHit m_Hit;


	void Start () {
        m_Player = Manager_GameObjectsReferences.Instance.m_Player.transform;
        transform.LookAt(m_Player.transform.position, Vector3.up);
    }
	

	void LateUpdate () {
        Vector3 _rayCastDirection = new Vector3(m_Player.transform.position.x - transform.position.x, m_Player.transform.position.y - transform.position.y, m_Player.transform.position.z - transform.position.z);
        Ray groundingRay = new Ray(transform.position, _rayCastDirection);
        Debug.DrawRay(transform.position, _rayCastDirection);

        if (Physics.Raycast(groundingRay, out m_Hit, m_MinimumDistance))
        {
            /*
            if (m_Hit.collider.tag == "Player")
            {
                transform.position = transform.position;
                transform.LookAt(m_Player.transform.position, Vector3.up);
            }
            */
        }
        else
        {
            m_SmoothMove = Vector3.SmoothDamp(transform.position, m_Player.position + m_Offset, ref m_SmoothVel, m_SmoothTime);
            transform.position = Vector3.SmoothDamp(transform.position, m_Player.position + m_Offset, ref m_SmoothVel, m_SmoothTime);
        }
    }
}
