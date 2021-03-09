using UnityEngine;
using System.Collections.Generic;

public class ComputerPlayer : AbstractPlayer
{
    private void Update()
    {
        if (this.MyStep() && GameManager.GetInstance().GetGameTree().NodeHasChild(GameManager.GetInstance().GetField()))
        {
            MakeAMove();
        }
    }

    public void MakeAMove()
    {
        int cellId = makeChoise(NodeState.Lose);
        if (cellId == -1) cellId = makeChoise(NodeState.Draw);
        if (cellId == -1) cellId = makeChoise(NodeState.Win);
        if (cellId == -1) return;
        this.ChangeFiledState(cellId);
    }

    private int makeChoise(NodeState nodeState)
    {
        List<int> cells = GameManager.GetInstance().GetGameTree().GetCells(GameManager.GetInstance().GetField(), nodeState);
        if (cells.Count == 0) return -1;
        return cells[Random.Range(0, cells.Count)];
    }
}
