using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void PlayPVE()
    {
        GameManager.GetInstance().VsComputerSetUp();
        SceneManager.LoadScene("GameScene");

    }

    public void PlayPVP()
    {
        GameManager.GetInstance().VsPlayerSetUp();
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
