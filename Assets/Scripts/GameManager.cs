using UnityEngine;

public class GameManager
{
    private static GameManager s_instance;
    private int m_moveCount = 0;
    private CellState[] m_field = new CellState[9];
    private IPlayer m_firstPlayer;
    private IPlayer m_secondPlayer;
    private GameTree m_gameTree = new GameTree();

    private GameManager()
    {
        FieldInnit();
        m_gameTree.innit();
        m_firstPlayer = new Player(PlayerSide.FirstPlayer);
        m_secondPlayer = new ComputerPlayer(PlayerSide.SecondPlayer);
        m_firstPlayer.SetNextPlayer(m_secondPlayer);
        m_secondPlayer.SetNextPlayer(m_firstPlayer);
    }

    static GameManager()
    {
        s_instance = new GameManager();

    }

    public static GameManager GetInstance() => s_instance;

    public CellState[] GetField() => m_field;

    public GameTree GetGameTree => m_gameTree;

    public void ChangeCellStateOnFiled(int cellId, PlayerSide playerSide)
    {

        m_field[cellId] = (playerSide == PlayerSide.FirstPlayer) ? CellState.X : CellState.O;
        EndOfMove(playerSide);

        //---------------Consloe field print
        string tmp = " ";
        for (int i = 0; i < 9; i++)
        {
            if (i % 3 == 0) tmp += "\n";
            if (m_field[i] == CellState.X) tmp += "x";
            else if (m_field[i] == CellState.O) tmp += "o";
            else tmp += "_";
        }
        Debug.Log(tmp);
        //--------------Console field print
    }

    private void EndOfMove(PlayerSide playerSide)
    {
        if (m_moveCount >= 4 && HasThreeInRow())
        {
            Win(playerSide);
        }
        else if (m_moveCount == 8) Draw();
        m_moveCount++;
    }

    private void Win(PlayerSide player)
    {
        Debug.Log("Player " + player.ToString() + " won!");
    }

    private void Draw()
    {


    }

    private void Restart()
    {
        FieldInnit();
        m_moveCount = 0;
    }

    

    private bool HasThreeInRow()
    {
        return CellsComparator(m_field[0], m_field[1], m_field[2]) ||
            CellsComparator(m_field[3], m_field[4], m_field[5]) ||
            CellsComparator(m_field[6], m_field[7], m_field[8]) ||
            CellsComparator(m_field[0], m_field[4], m_field[8]) ||
            CellsComparator(m_field[2], m_field[4], m_field[6]);
    }

    private bool CellsComparator(CellState cs1, CellState cs2, CellState cs3)
    {
        return cs1 == cs2 && cs1 == cs3;

    }

    private void FieldInnit()
    {
        for (int i = 0; i < m_field.Length; i++) m_field[i] = CellState.Empty;
    }

}
