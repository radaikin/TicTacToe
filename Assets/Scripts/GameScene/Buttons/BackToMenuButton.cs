using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton : MonoBehaviour
{

    public void BackToMenu()
    {
        GameManager.GetInstance().CleanUp();
        SceneManager.LoadScene("MainMenu");
    }

}
