using UnityEngine;



public class GameManager
{
    private static GameManager s_instance;

    private bool side = true;
    private int moveCount;
    private CellState[] field = new CellState[9];
    public bool GetSide() => side;
    

    private GameManager()
    {
        FieldInnit();
        GameObject.FindGameObjectWithTag("ButtonController")
        .GetComponent<ButtonController>().observer+= ChangeCellStateOnFiled;

    }

    static GameManager()
    {
        s_instance = new GameManager();
        
    }

    public static GameManager GetInstance()
    {
        return s_instance;
    }

    public void ChangeCellStateOnFiled(int CellId)
    {
        field[CellId] = (side == true) ? CellState.X : CellState.O;
        Debug.Log("Field state = " + field[CellId]);
        ChangeSide();
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
