using UnityEngine;

public abstract class AbstractPlayer : MonoBehaviour, IPlayer
{
    private PlayerSide m_PlayerSide;

    public AbstractPlayer()
    {

    }

    public PlayerSide GetPlayerSide()
    {
        return m_PlayerSide;
    }

    public void SetSide(PlayerSide playerSide)
    {
        this.m_PlayerSide = playerSide;
    }

    protected bool MyStep()
    {
        return GameManager.GetInstance().GetCurrentPlayer() == m_PlayerSide;
    }

    protected void ChangeFiledState(int cellId)
    {
        GameManager.GetInstance().ChangeFiledState(cellId, m_PlayerSide);
    }
}
