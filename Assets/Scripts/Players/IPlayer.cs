
public interface IPlayer
{
    PlayerSide GetPlayerSide();
    void SetNextPlayer(IPlayer nextPlayer);
    IPlayer GetNextPlayer();
    void SetSide(PlayerSide playerSide);
    void MakeAMove();

}
