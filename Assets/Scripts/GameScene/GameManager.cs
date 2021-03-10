using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void EndOfGame();
public delegate void RestartTimer();
public delegate void StopTimer();

public enum EnemySetUP { Player, Computer};

public class GameManager: MonoBehaviour
{
    private static GameManager s_instance;

    public event EndOfGame m_EndOfGameEvent;
    public event RestartTimer m_RestartTimerEvent;
    public event StopTimer m_StopTimer;

    private CellState[] m_FieldState = new CellState[9];
    private int m_MoveCounter;
    private static GameTree m_GameTree = new GameTree();
    private EnemySetUP m_EnemySetUP;

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameScene"))
        {
            GameObject.FindWithTag("FirstPlayer").AddComponent<Player>();

            if (s_instance.m_EnemySetUP == EnemySetUP.Computer)
            {
                GameObject.FindWithTag("HintButton").SetActive(true);
                GameObject.FindWithTag("SecondPlayer").AddComponent<ComputerPlayer>();
            }
            else if (s_instance.m_EnemySetUP == EnemySetUP.Player)
            {
                GameObject.FindWithTag("HintButton").SetActive(false);
                GameObject.FindWithTag("SecondPlayer").AddComponent<Player>();
            }
            GameObject.FindWithTag("FirstPlayer").GetComponent<AbstractPlayer>()
                .SetSide(PlayerSide.FirstPlayer);
            GameObject.FindWithTag("FirstPlayer").GetComponent<AbstractPlayer>()
                .SetName(PlayerPrefs.GetString("FirstPlayerName"));
            GameObject.FindWithTag("SecondPlayer").GetComponent<AbstractPlayer>()
                .SetSide(PlayerSide.SecondPlayer);
            GameObject.FindWithTag("SecondPlayer").GetComponent<AbstractPlayer>()
                .SetName(PlayerPrefs.GetString("SecondPlayerName"));
            //tmp
            Debug.Log(GameObject.FindWithTag("SecondPlayer").GetComponent<AbstractPlayer>().GetName());
        }

        if (s_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        m_MoveCounter = 0;
        FieldInnit();
        m_GameTree.Innit();
        s_instance = this;
        GameObject.DontDestroyOnLoad(gameObject); 
    }

    public static GameManager GetInstance() => s_instance;

    public GameTree GetGameTree() => m_GameTree;

    public int GetMoveCount() => m_MoveCounter;

    public CellState[] GetField() => m_FieldState;

    public void SetField(CellState[] field) => m_FieldState = field;

    public PlayerSide GetCurrentPlayer()
    {
        return m_MoveCounter % 2 == 0 ? PlayerSide.FirstPlayer : PlayerSide.SecondPlayer;
    }

    public void VsComputerSetUp()
    {
        m_EnemySetUP = EnemySetUP.Computer;
    }

    public void VsPlayerSetUp()
    {
        m_EnemySetUP = EnemySetUP.Player;
    }

    public void ChangeFiledState(int cellId, PlayerSide playerSide)
    {
        m_FieldState[cellId] = (playerSide == PlayerSide.FirstPlayer) ?
            CellState.X : CellState.O;
        EndOfMove();
        m_MoveCounter++;
    }

    public void Restart()
    {
        FieldInnit();
        m_MoveCounter = 0;
        m_RestartTimerEvent();
    }

    public void SetHintToACell(int cellId)
    {
        m_FieldState[cellId] = CellState.Hint;
    }

    public void RemoveHintFromACell(int cellId)
    {
        if (m_FieldState[cellId] == CellState.Hint)
        {
            m_FieldState[cellId] = CellState.Empty;
        }
    }

    public void CleanUp()
    {
        Destroy(GameObject.FindWithTag("FirstPlayer").GetComponent<AbstractPlayer>());
        Destroy(GameObject.FindWithTag("SecondPlayer").GetComponent<AbstractPlayer>());
        Restart();
    }

    private void EndOfMove()
    {
        if (m_MoveCounter >= 4 && !m_GameTree.NodeHasChild(m_FieldState))
        {
            switch (m_GameTree.GetNodeState(m_FieldState))
            {
                case NodeState.Win:
                    Win(PlayerSide.FirstPlayer);
                    break;
                case NodeState.Draw:
                    Draw();
                    break;
                case NodeState.Lose:
                    Win(PlayerSide.SecondPlayer);
                    break;
            }
        }
    }

    private void Draw()
    {
        Debug.Log("Draw!");
        m_StopTimer();
        m_EndOfGameEvent();
    }

    private void Win(PlayerSide winner)
    {
        Debug.Log("Player " + winner.ToString() + " won!");
        m_StopTimer();
        m_EndOfGameEvent();
    }

    private void FieldInnit()
    {
        for (int i = 0; i < m_FieldState.Length; i++) m_FieldState[i] = CellState.Empty;
    }

}
