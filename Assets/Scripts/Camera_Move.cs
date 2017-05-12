using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Camera_Move : MonoBehaviour {


    [SerializeField]
    private float m_HeightSpeed;
    [SerializeField]
    private float m_TurningSpeed;
    [SerializeField]
    private float m_ResetTimerCamera;

    float m_MoveHorizontal;
    float m_MoveVertical;
    private bool m_GetBackPosition = false;
    private Coroutine m_ResetCorotuine = null;

    PlayerIndex playerIndex = 0;
    GamePadState state;


    void Update()
    {
        state = GamePad.GetState(playerIndex);
        Debug.Log(state.ThumbSticks.Right.X);
        //Si pas de mouvement de joystick alors il la camera attend et se reset smooth avec un coroutine (Quaternion.LookRotation)
        //Si ça bouge, alors on fait un petit lerp entre -90 et 90, check variable pour savoir si c'est négatif ou positif comme mouvement ? Smoother le lerp aussi. 

        if (((state.ThumbSticks.Right.X == 0) || (state.ThumbSticks.Right.Y == 0)))
        {
            m_GetBackPosition = true;
        }
        if (((state.ThumbSticks.Right.X != 0) || (state.ThumbSticks.Right.Y != 0)))
        {
            m_GetBackPosition = false;

            if (state.ThumbSticks.Right.X > 0)
            {
                m_MoveHorizontal = Mathf.Lerp(0, 90, state.ThumbSticks.Right.X);
            }
            if (state.ThumbSticks.Right.X < 0)
            {
                m_MoveHorizontal = Mathf.Lerp(0, -90, state.ThumbSticks.Right.X);
            }



            if (state.ThumbSticks.Right.Y > 0)
            {
                m_MoveVertical = Mathf.Lerp(0, 45, state.ThumbSticks.Right.Y);
            }
            if (state.ThumbSticks.Right.Y < 0)
            {
                m_MoveVertical = Mathf.Lerp(0, -45, -state.ThumbSticks.Right.Y);
            }

        }

        if (m_GetBackPosition)
        {
            m_ResetCorotuine = StartCoroutine(ResetOrientation());
        }
        else
        {
            StopCoroutine(m_ResetCorotuine);
        }


        transform.localRotation = Quaternion.Euler(-m_MoveVertical, m_MoveHorizontal, 0);

       // m_Orientation = Quaternion.LookRotation(m_ListTargetedVehicle[0].transform.position - transform.position, m_ListTargetedVehicle[0].transform.position - transform.position);
       // m_DynamicVisual.transform.localRotation = Quaternion.Slerp(m_DynamicVisual.transform.localRotation, m_Orientation, m_SpeedRotation * Time.deltaTime);


        //Déplacement avant & arrière.
        //float _MoveVertical = (state.ThumbSticks.Right.Y * 2) * m_HeightSpeed * Time.deltaTime; ; //Check la valeur de l'input
        // transform.Rotate(_MoveVertical, 0, 0); //déplacement en x en fonction de movevertical
    }

    IEnumerator ResetOrientation()
    {
        yield return new WaitForSeconds(m_ResetTimerCamera);
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
        }
        yield break;
    }
}
