using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum NumeroJugador
{
    UNO, DOS
}

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textMarcador1;
    public TextMeshProUGUI textMarcador2;
    public BallController ballController;

    private int puntajeJugador1 = 0;
    private int puntajeJugador2 = 0;
    private bool mIsRunning = true;

    private void Start()
    {
        // Se inscribe el GameManager al evento OnGoal
        ballController.OnGoal += BallController_OnGoal;
        textMarcador1.text = puntajeJugador1.ToString();
        textMarcador2.text = puntajeJugador2.ToString();
    }

    private void BallController_OnGoal(object sender, System.EventArgs e)
    {
        NumeroJugador numJugador = (e as OnGoalEventArg).jugador;

        if (numJugador == NumeroJugador.UNO)
        {
            puntajeJugador1++;
        }else
        {
            puntajeJugador2++;
        }

        textMarcador1.text = puntajeJugador1.ToString();
        textMarcador2.text = puntajeJugador2.ToString();

        ballController.ReInit();
        mIsRunning = false;
    }

    private void Update()
    {
        if (!mIsRunning && Input.GetKeyDown(KeyCode.Space))
        {
            ballController.ReStart();
            mIsRunning = true;
        }
    }
}
