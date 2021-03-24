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

        this.ChangeFiledState(MakeAChoise());
    }

    private int MakeAChoise()
    {
        List<int> cells = GameTree.GetInstance().GetCells(GameManager.GetInstance().GetFieldState());
        if (cells.Count == 0) return -1;
        switch (GameManager.GetInstance().GetDifficultyLevel())
        {
            case DifficultyLevel.Easy:
                return cells[cells.Count - 1];
            case DifficultyLevel.Normal:
                return cells[Random.Range((int)(cells.Count * 0.3f), (int)(cells.Count * 0.7f))];
            case DifficultyLevel.Hard:
                return cells[Random.Range(0, cells.Count / 2)];
            default:
                return -1;
        }
    }

}