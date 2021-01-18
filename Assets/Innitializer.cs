using UnityEngine;

public class Innitializer : MonoBehaviour
{
    GameManager s_gameManager;
    void Awake()
    {
        s_gameManager = GameManager.GetInstance();
    }

}
