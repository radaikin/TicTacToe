using System;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGamePopUp : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
        GameManager.GetInstance().m_EndOfGameEvent += PopUp;
        GameManager.GetInstance().m_EndOfGameEventDraw += DrawPopUp;
    }

    private void DrawPopUp()
    {
        gameObject.SetActive(true);
        gameObject.GetComponentInChildren<Text>().text = "Draw!";
    }

    private void PopUp(PlayerSide winner)
    { 
        gameObject.SetActive(true);
        if(winner == PlayerSide.FirstPlayer)
        gameObject.GetComponentInChildren<Text>().text
                = GameObject.FindWithTag(winner.ToString())
                .GetComponent<AbstractPlayer>().GetName() + " won!";
    }
}
