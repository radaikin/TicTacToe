using UnityEngine;

public class GameManager
{
    private static GameManager s_instance;

    private bool side = true;
    private int moveCount;
    private CellState[] field = new CellState[9];
    public bool GetSide() => side;
    public ControllerEventHandler ControllerEventHandler = new ControllerEventHandler();

    private GameManager() { }

    static GameManager()
    {
        s_instance = new GameManager();
        s_instance.FieldInnit();
    }

    public static GameManager GetInstance()
    {
        return s_instance;
    }

    public void ChangeCellStateOnFiled(int CellId)
    {
        Debug.Log("To Do");

    }


    public void EndOfMove()
    {



    }




    private void ChangeSide() => side = !side;

    private void FieldInnit()
    {
        for (int i = 0; i < field.Length; i++) field[i] = CellState.Empty;
    }

}
