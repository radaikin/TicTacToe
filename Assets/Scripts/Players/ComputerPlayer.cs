
using System;
using System.Collections.Generic;

public class ComputerPlayer : AbstractPlayer
{
    private Random random = new Random();

    GameTree m_gameTree = new GameTree();


    public ComputerPlayer()
    {
        //recursive function should be called on game innit
        m_gameTree.innit();
    }

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
        List<int> cells = m_gameTree.getCells(GameManager.GetInstance().getField(), nodeState);
        if (cells.Count == 0) return -1;
        return cells[random.Next(cells.Count)];
    }
}
