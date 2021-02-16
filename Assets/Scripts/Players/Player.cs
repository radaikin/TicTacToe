using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractPlayer
{
    private bool m_canPlay;
    private System.Random m_random = new System.Random();

    public Player(PlayerSide playerSide)
    {
        this.SetSide(playerSide);
        GameObject.FindGameObjectWithTag("ButtonController")
        .GetComponent<ButtonController>().m_observer += OnControllerPreset;
        m_canPlay = playerSide == PlayerSide.FirstPlayer;
    }

    public override void MakeAMove()
    {
        m_canPlay = true;
    }

    public void OnControllerPreset(int cellId)
    {
        if (!m_canPlay || GameManager.GetInstance().GetField()[cellId] != CellState.Empty) return;
        GameManager.GetInstance().ChangeCellStateOnFiled(cellId, this.GetPlayerSide());
        m_canPlay = false;
        GetNextPlayer().MakeAMove();
    }

    public int makeAHint()
    {
        int cell = makeChoise(NodeState.Win);
        if (cell == -1) cell = makeChoise(NodeState.Draw);
        if (cell == -1) cell = makeChoise(NodeState.Lose);
        return cell;
    }

    private int makeChoise(NodeState nodeState)
    {
        List<int> cells = GameManager.GetInstance().GetGameTree.getCells(GameManager.GetInstance().GetField(), nodeState);
        if (cells.Count == 0) return -1;
        return cells[m_random.Next(cells.Count)];
    }
}

