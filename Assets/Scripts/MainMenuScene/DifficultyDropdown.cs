using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DifficultyDropdown : MonoBehaviour
{
    private List<string> m_DifficultyLevelList;

    private void Start()
    {
        m_DifficultyLevelList = GetDifficultyLevels();
        this.gameObject.GetComponent<Dropdown>().AddOptions(m_DifficultyLevelList);
        Debug.Log(GameManager.GetInstance().GetDifficultyLevel().ToString());
        this.gameObject.GetComponentInChildren<Text>().text
            = GameManager.GetInstance().GetDifficultyLevel().ToString();
    }

    public void DropdownValueChanged(int index)
    {
        if (m_DifficultyLevelList[index] == DifficultyLevel.Easy.ToString())
        {
            GameManager.GetInstance().SetDifficultyLevel(DifficultyLevel.Easy);

        }
        else if (m_DifficultyLevelList[index] == DifficultyLevel.Normal.ToString())
        {
            GameManager.GetInstance().SetDifficultyLevel(DifficultyLevel.Normal);
        }
        else if (m_DifficultyLevelList[index] == DifficultyLevel.Hard.ToString())
        {
            GameManager.GetInstance().SetDifficultyLevel(DifficultyLevel.Hard);
        }
        Debug.Log("Difficulty level set to " + GameManager.GetInstance().GetDifficultyLevel());
    }

    private List<string> GetDifficultyLevels()
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
