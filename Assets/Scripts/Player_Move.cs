﻿using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

    [SerializeField]
    private float m_HeightSpeed;
    [SerializeField]
    private float m_TurningSpeed;

    void Start()
    {

    }

    void Update()
    {
        //Déplacement droite & gauche
        float _MoveHorizontal = (Input.GetAxis("R_XAxis_1")*2) * m_TurningSpeed * Time.deltaTime;
        transform.Rotate(0, _MoveHorizontal, 0);

        //Déplacement avant & arrière.
        float _MoveVertical = (Input.GetAxis("R_YAxis_1")*2) * m_HeightSpeed * Time.deltaTime; ; //Check la valeur de l'input
        transform.Rotate(_MoveVertical, 0,0); //déplacement en x en fonction de movevertical

    }
}