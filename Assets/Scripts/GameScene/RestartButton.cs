using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        GameManager.GetInstance().Restart();
    }
   
}
