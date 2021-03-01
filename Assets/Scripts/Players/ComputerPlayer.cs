
using System;
using System.Collections.Generic;

public class ComputerPlayer : AbstractPlayer
{
    private Random random = new Random();

    public override void MakeAMove()
    {
        int cell = makeChoise(NodeState.Lose);
        if (cell == -1) cell = makeChoise(NodeState.Draw);
        if (cell == -1) cell = makeChoise(NodeState.Win);
        //add -1 handler
        GameManager.GetInstance().ChangeCellStateOnFiled(cell, this.GetPlayerSide());
        GetNextPlayer().MakeAMove();
    }

    private int makeChoise(NodeState nodeState)
    {
        List<int> cells = GameManager.GetInstance().GetGameTree.getCells(GameManager.GetInstance().GetField(), nodeState);
        if (cells.Count == 0) return -1;
        return cells[random.Next(cells.Count)];
    }
}
