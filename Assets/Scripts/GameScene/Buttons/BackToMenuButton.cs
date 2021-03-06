using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton : MonoBehaviour
{

    public void BackToMenu()
    {
        GameManager.GetInstance().Restart();
        SceneManager.LoadScene("MainMenu");
    }

}
