using UnityEngine;
using UnityEngine.SceneManagement;

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

}
