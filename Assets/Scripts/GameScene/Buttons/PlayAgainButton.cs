using UnityEngine;
using UnityEngine.UI;

public class PlayAgainButton : MonoBehaviour
{
    public void PlayAgain()
    {
        GameObject.FindGameObjectWithTag("EndOfGamePopUp").SetActive(false);
        GameManager.GetInstance().Restart();
    }
}
