using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractPlayer
{
    private System.Random m_random = new System.Random();

    private void Start()
    {
        GameObject.FindGameObjectWithTag("ButtonController")
        .GetComponent<ButtonController>().m_observer += OnControllerPreset;
    }

    public void OnControllerPreset(int cellId)
    {
        if (this.MyStep() && GameManager.GetInstance().GetField()[cellId] == CellState.Empty)
        {
            this.ChangeFiledState(cellId);
        }
        
    }

    public int MakeAHint()
    {
        int cell = MakeChoise(NodeState.Win);
        if (cell == -1) cell = MakeChoise(NodeState.Draw);
        if (cell == -1) cell = MakeChoise(NodeState.Lose);
        return cell;
    }

    private int MakeChoise(NodeState nodeState)
    {
        List<int> cells = GameManager.GetInstance().GetGameTree().GetCells(GameManager.GetInstance().GetField(), nodeState);
        if (cells.Count == 0) return -1;
        return cells[m_random.Next(cells.Count)];
    }
}

