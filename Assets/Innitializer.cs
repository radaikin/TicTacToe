using UnityEngine;

public class Innitializer : MonoBehaviour
{
    private GameManager s_gameManager;

    void Awake()
    {
        s_gameManager = GameManager.GetInstance();

    }

}
