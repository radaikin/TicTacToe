using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer : MonoBehaviour, IPlayer
{
    [SerializeField] private PlayerState m_PlayerState;
    [SerializeField] private GameState m_GameState;

    public PlayerState playerState
    {
        get => m_PlayerState;
        set => m_PlayerState = value;
    }

    public void MakeAMove()
    {
        if (m_PlayerState.MyStep() && GameTree.GetInstance().NodeHasChild(m_GameState.GetFieldState()))
        {
            m_GameState.ChangeFiledState(MakeAChoise());
        }
    }

    private int MakeAChoise()
    {
        List<int> cells = GameTree.GetInstance().GetCells(m_GameState.GetFieldState());
        if (cells.Count == 0) return -1;
        switch (m_GameState.GetDifficultyLevel())
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