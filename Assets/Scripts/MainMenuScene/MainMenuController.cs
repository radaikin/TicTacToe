using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private DifficultyDropdown m_DifficultyDropdown;
    [SerializeField] private GameState m_GameState;
    private List<string> m_DifficultyLevelList;

    private void Start()
    {
        m_DifficultyLevelList = m_DifficultyDropdown.GetComponent<DifficultyDropdown>().GetDifficultyLevels();
        m_DifficultyDropdown.GetComponent<Dropdown>().AddOptions(m_DifficultyLevelList);
        Debug.Log(m_GameState.GetDifficultyLevel().ToString());
        m_DifficultyDropdown.GetComponentInChildren<Text>().text
            = m_GameState.GetDifficultyLevel().ToString();
    }


    public void PlayPVE()
    {
     //TODO   GameManager.GetInstance().VsComputerSetUp();
        SceneManager.LoadScene("GameScene");

    }

    public void PlayPVP()
    {
    //TODO    GameManager.GetInstance().VsPlayerSetUp();
        SceneManager.LoadScene("GameScene");
    }

    public void OnSettingsPressed()
    {
        GameObject.FindGameObjectWithTag("FirstPlayerNameInputField")
            .GetComponent<InputField>().onEndEdit.AddListener(
            (name) => PlayerPrefs.SetString("FirstPlayerName", name));
        GameObject.FindGameObjectWithTag("SecondPlayerNameInputField")
            .GetComponent<InputField>().onEndEdit.AddListener(
            (name) => PlayerPrefs.SetString("SecondPlayerName", name));
    }
}
