using UnityEngine;
using System.Collections;
using XInputDotNetPure;


public class Player_Rotation : MonoBehaviour {

    [SerializeField]
    private float m_HeightSpeed;
    [SerializeField]
    private float m_TurningSpeed;
    [SerializeField]
    private GameObject m_Camera;

    PlayerIndex playerIndex = 0;
    GamePadState state;

    void Update()
    {
        state = GamePad.GetState(playerIndex);

        Quaternion m_Orientation = Quaternion.LookRotation(m_Camera.transform.forward, this.transform.forward);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, m_Orientation, m_TurningSpeed * Time.deltaTime);

        //Déplacement droite & gauche
        float _MoveHorizontal = (state.ThumbSticks.Left.X * 2) * m_TurningSpeed * Time.deltaTime;


        //Déplacement avant & arrière.
        float _MoveVertical = (state.ThumbSticks.Left.Y * -2) * m_HeightSpeed * Time.deltaTime; ; //Check la valeur de l'input


        //transform.rotation = Quaternion.Euler(new Vector3(_MoveVertical, _MoveHorizontal, 0));

    }
}
