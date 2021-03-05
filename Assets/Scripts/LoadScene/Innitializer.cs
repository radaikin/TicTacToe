using UnityEngine;
using UnityEngine.SceneManagement;

public class Innitializer : MonoBehaviour
{
    private GameManager s_gameManager;

    void Start()
    {
        s_gameManager = GameManager.GetInstance();
        SceneManager.LoadScene("MainMenu");
    }

}
