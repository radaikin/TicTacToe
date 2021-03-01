using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void PlayPVE()
    {
        GameManager.GetInstance().SetUp(new Player(), new ComputerPlayer());
        SceneManager.LoadScene("GameScene");

    }

    public void PlayPVP()
    {
        GameManager.GetInstance().SetUp(new Player(), new Player());
        SceneManager.LoadScene("GameScene");
    }

}
