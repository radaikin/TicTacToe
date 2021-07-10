using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DifficultyDropdown : MonoBehaviour
{
    private List<string> m_DifficultyLevelList;
    [SerializeField] private GameState m_GameState;

    public void DropdownValueChanged(int index)
    {
        if (m_DifficultyLevelList[index] == DifficultyLevel.Easy.ToString())
        {
            m_GameState.SetDifficultyLevel(DifficultyLevel.Easy);

        }
        else if (m_DifficultyLevelList[index] == DifficultyLevel.Normal.ToString())
        {
            m_GameState.SetDifficultyLevel(DifficultyLevel.Normal);
        }
        else if (m_DifficultyLevelList[index] == DifficultyLevel.Hard.ToString())
        {
            m_GameState.SetDifficultyLevel(DifficultyLevel.Hard);
        }
        Debug.Log("Difficulty level set to " + m_GameState.GetDifficultyLevel());
    }

    public List<string> GetDifficultyLevels()
    {
        string[] difficultyLevels = Enum.GetNames(typeof(DifficultyLevel));
        List<string> result = new List<string>();
        foreach (string s in difficultyLevels)
        {
            result.Add(s);
        }
        return result;
    }

}
