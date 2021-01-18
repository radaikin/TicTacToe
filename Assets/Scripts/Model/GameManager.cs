public class GameManager
{
    private static GameManager s_instance;

    private GameManager() { }

    static GameManager()
    {

        s_instance = new GameManager();
    }

    public static GameManager getInstance()
    {
        return s_instance;
    }

    private bool side = true;
    private int moveCount;
    private ButtonController[] field = new ButtonController[9];

    public bool GetSide() => side;

    void ChangeSide() => side = !side;

    public void EndOfMove() {



    }

}
