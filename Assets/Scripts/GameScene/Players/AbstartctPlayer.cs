using UnityEngine;

public abstract class AbstractPlayer : MonoBehaviour, IPlayer
{
    private string m_Name;
    private PlayerSide m_PlayerSide;

    public PlayerSide GetPlayerSide()
    {
        return m_PlayerSide;
    }

    public void SetName(string name) => m_Name = name;

    public string GetName() => m_Name;

    public void SetSide(PlayerSide playerSide) => m_PlayerSide = playerSide;

    protected bool MyStep()
    {
        return GameManager.GetInstance().GetCurrentPlayer() == m_PlayerSide;
    }

    protected void ChangeFiledState(int cellId)
    {
        GameManager.GetInstance().ChangeFiledState(cellId, m_PlayerSide);
    }
}
