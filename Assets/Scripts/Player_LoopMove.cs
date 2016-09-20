using UnityEngine;
using System.Collections;

public class Player_LoopMove : MonoBehaviour {

    //REVOIR INPUT MANAGER DE DEPLACEMENT C'EST CHELOU (pas de triggers du tout, pas de gâchettes gauches).
    
    private float m_MaxLoopSpeed;
    private float m_LoopSpeed;
    [SerializeField]
    private float m_RegularMaxLoopSpeed;
    [SerializeField]
    private float m_RegularSpeedDividant;
    [SerializeField]
    private float m_Acceleration;
    [SerializeField]
    private float m_Deseleraction;
    private bool m_Slowing;


    private Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(LoopMove());
        m_MaxLoopSpeed = m_RegularMaxLoopSpeed;

	}
	
    void Update ()
    {
        if ((Input.GetButtonDown("RB_1") || Input.GetButtonDown("LB_1"))  && m_Slowing == false ) //Trouver comment mettre RT au lieux de RB
        {
            m_MaxLoopSpeed = m_RegularMaxLoopSpeed / m_RegularSpeedDividant;
            m_Slowing = true;
        }
        if ((Input.GetButtonUp("RB_1") || Input.GetButtonDown("LB_1")) && m_Slowing == true )
        {
            m_MaxLoopSpeed = m_RegularMaxLoopSpeed;
            m_Slowing = false;
        }
    }

 IEnumerator LoopMove ()
    {
        m_LoopSpeed = 0;
        while(true)
        {
            if (m_Slowing == false)
            {
                if (m_LoopSpeed < m_MaxLoopSpeed)
                {
                    m_LoopSpeed += m_Acceleration;
                }

                //rb.velocity = Mathf.Lerp(m_MaxLoopSpeed, Time.deltaTime * m_Acceleration);

                rb.velocity = transform.forward.normalized * m_LoopSpeed;
                yield return new WaitForEndOfFrame();
            }
            if (m_Slowing == true)
            {
                if (m_LoopSpeed > m_MaxLoopSpeed)
                {
                    m_LoopSpeed -= m_Deseleraction;
                }

                //rb.velocity = Mathf.Lerp(m_MaxLoopSpeed, Time.deltaTime * m_Acceleration);

                rb.velocity = transform.forward.normalized * m_LoopSpeed;
                yield return new WaitForEndOfFrame();
            }
        }

    }

}
