using UnityEngine;

public class Innitializer : MonoBehaviour
{
    GameManager s_gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        s_gameManager = GameManager.GetInstance();
    }

}
