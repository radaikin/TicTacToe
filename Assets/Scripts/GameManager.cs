using UnityEngine;

public delegate void PlayerManager(PlayerSide PalyerSide);

public class GameManager
{
    private static GameManager s_instance;

    public event PlayerManager observer;

    private PlayerSide playerSide = PlayerSide.FirstPlayer;
    private int moveCount = 0;
    private CellState[] field = new CellState[9];
    private IPlayer firstPlayer;
    private IPlayer secondPlayer;

    private GameManager()
    {
        FieldInnit();
        firstPlayer = new Player(PlayerSide.FirstPlayer);
        secondPlayer = new ComputerPlayer();
        firstPlayer.SetNextPlayer(secondPlayer);
        secondPlayer.SetNextPlayer(firstPlayer);
        secondPlayer.SetSide(PlayerSide.SecondPlayer);

    }

    static GameManager()
    {
        s_instance = new GameManager();
        
    }

    public static GameManager GetInstance()
    {
        return s_instance;
    }

    public CellState[] getField()
    {
        return field;
    }

    public void ChangeCellStateOnFiled(int cellId, PlayerSide playerSide)
    {

        field[cellId] = (playerSide == PlayerSide.FirstPlayer) ? CellState.X : CellState.O;
        string tmp = " ";
        for (int i = 0; i < 9; i++)
        {
            if (i % 3 == 0) tmp += "\n";
            if (field[i] == CellState.X) tmp += "x";
            else if (field[i] == CellState.O) tmp += "o";
            else tmp += "_";
        }
        Debug.Log(tmp);
        ChangeSide();
    }

    public void EndOfMove()
    {


        
    }

    private PlayerSide GetSide() => playerSide;

    private void ChangeSide()
    {
        playerSide = (playerSide == PlayerSide.FirstPlayer)? PlayerSide.SecondPlayer : PlayerSide.FirstPlayer;
    }

    private void FieldInnit()
    {
        for (int i = 0; i < field.Length; i++) field[i] = CellState.Empty;
    }

}
