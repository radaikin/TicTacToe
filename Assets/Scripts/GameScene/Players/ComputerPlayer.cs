using UnityEngine;
using System.Collections.Generic;

public class ComputerPlayer : AbstractPlayer
{
    private void Update()
    {
        if (this.MyStep() && GameTree.GetInstance().NodeHasChild(GameManager.GetInstance().GetFieldState()))
        {
            MakeAMove();
        }
    }

    public void MakeAMove()
    {
        int random = Random.Range(0, 100);
        int cellId = MakeAChoise(NodeState.Lose);
        if (cellId == -1 || (GameManager.GetInstance().GetDifficultyLevel()
            != DifficultyLevel.Hard && random <= 60)) cellId = MakeAChoise(NodeState.Draw);
        if (cellId == -1 || (GameManager.GetInstance().GetDifficultyLevel()
            == DifficultyLevel.Easy && random <= 50)) cellId = MakeAChoise(NodeState.Win);
        if (cellId == -1) return;
        this.ChangeFiledState(cellId);
    }

    private int MakeAChoise(NodeState nodeState)
    {
        List<int> cells = GameTree.GetInstance().GetCells(GameManager.GetInstance().GetFieldState(), nodeState);
        if (cells.Count == 0) return -1;
        return cells[Random.Range(0, cells.Count)];
    }
}
