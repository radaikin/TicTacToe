using UnityEngine;
using UnityEngine.UI;

public class EndOfGamePopUp : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
        GameManager.GetInstance().m_EndOfGameEvent += PopUp;
    }

    private void PopUp()
    {
        gameObject.SetActive(true);
        gameObject.GetComponentInChildren<Text>().text = "Print Winner";
    }
}
