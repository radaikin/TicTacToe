//using UnityEngine;

////public delegate void EndOfGame();
////public delegate void RestartTimer();
////public delegate void StopTimer();

//public class GameManager
//{
//    private static GameManager s_instance;
//    private int m_moveCount = 0;
//    private CellState[] m_field = new CellState[9];

//    private IPlayer m_firstPlayer;
//    private IPlayer m_secondPlayer;

//    private GameTree m_gameTree = new GameTree();
//    public event EndOfGame m_EndOfGameEvent;
//    public event RestartTimer m_RestartTimerEvent;
//    public event StopTimer m_StopTimer;


//    private GameManager()
//    {
//        FieldInnit();
//        m_gameTree.Innit();
//    }

//    static GameManager()
//    {
//        s_instance = new GameManager();

//    }

//    public void SetUp(IPlayer firstPlayer, IPlayer secondPlayer)
//    {
//        m_firstPlayer = firstPlayer;
//        m_secondPlayer = secondPlayer;
//        //remove set side from IPlayer
//        m_firstPlayer.SetSide(PlayerSide.FirstPlayer);
//        m_secondPlayer.SetSide(PlayerSide.SecondPlayer);
//        m_firstPlayer.SetNextPlayer(m_secondPlayer);
//        m_secondPlayer.SetNextPlayer(m_firstPlayer);
//        m_firstPlayer.MakeAMove();
//    }

//    public static GameManager GetInstance() => s_instance;

//    public CellState[] GetField() => m_field;

//    public GameTree GetGameTree => m_gameTree;

//    public int GetMoveCount()
//    {
//        return m_moveCount;
//    }

//    public void ChangeCellStateOnFiled(int cellId, PlayerSide playerSide)
//    {

//        m_field[cellId] = (playerSide == PlayerSide.FirstPlayer) ?
//            CellState.X : CellState.O;
//        EndOfMove(playerSide);

//    }

//    private void EndOfMove(PlayerSide playerSide)
//    {
//        if (m_moveCount >= 4 && HasThreeInRow())
//        {
//            Win(playerSide);
//        }
//        else if (m_moveCount == 8) Draw();
//        m_moveCount++;
//    }

//    private void Win(PlayerSide player)
//    {
//        Debug.Log("Player " + player.ToString() + " won!");
//        m_StopTimer();
//        m_EndOfGameEvent();
//    }

//    private void Draw()
//    {
//        Debug.Log("Draw!");
//        m_StopTimer();
//        m_EndOfGameEvent();
//    }

//    public void Restart()
//    {
//        FieldInnit();
//        m_moveCount = 0;
//        m_RestartTimerEvent();
//    }

    

//    private bool HasThreeInRow()
//    {
//        return CellsComparator(m_field[0], m_field[1], m_field[2]) ||
//            CellsComparator(m_field[3], m_field[4], m_field[5]) ||
//            CellsComparator(m_field[6], m_field[7], m_field[8]) ||
//            CellsComparator(m_field[0], m_field[4], m_field[8]) ||
//            CellsComparator(m_field[2], m_field[4], m_field[6]);
//    }

//    private bool CellsComparator(CellState cs1, CellState cs2, CellState cs3)
//    {
//        return cs1 != CellState.Empty && cs1 == cs2 && cs1 == cs3;
//    }

//    private void FieldInnit()
//    {
//        for (int i = 0; i < m_field.Length; i++) m_field[i] = CellState.Empty;
//    }

//}
