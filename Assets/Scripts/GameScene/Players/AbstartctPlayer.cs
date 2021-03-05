using System;
public abstract class AbstractPlayer : IPlayer
{
    private PlayerSide playerSide;
    private IPlayer nextPlayer;

    public AbstractPlayer()
    {

    }

    public PlayerSide GetPlayerSide()
    {
        return playerSide;
    }

    public virtual void MakeAMove()
    {
        throw new NotImplementedException();
    }

    public IPlayer GetNextPlayer()
    {
        return nextPlayer;
    }

    public void SetNextPlayer(IPlayer nextPlayer)
    {
        this.nextPlayer = nextPlayer;
    }

    public void SetSide(PlayerSide playerSide)
    {
        this.playerSide = playerSide;
    }
}
