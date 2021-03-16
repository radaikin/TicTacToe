using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    private Sprite m_xSprite;
    private Sprite m_oSprite;
    private Sprite m_HintSprite;
    private ButtonController buttonController;
    private Button[] buttons;

    private void Start()
    {
        m_xSprite = Resources.Load<Sprite>("MoonActive/ExTarget");
        m_oSprite = Resources.Load<Sprite>("MoonActive/CircleTarget");
        m_HintSprite = Resources.Load<Sprite>("Buttons/Hint");
        Debug.Log(m_xSprite + "\n" + m_oSprite + "\n" + m_HintSprite);
        Debug.Log("Player1" + GameObject.FindWithTag("FirstPlayerName"));
        Debug.Log(GameObject.FindWithTag("FirstPlayer"));
        GameObject.FindWithTag("FirstPlayerName").GetComponent<Text>().text =
            GameObject.FindWithTag("FirstPlayer").GetComponent<AbstractPlayer>().GetName();

        GameObject.FindWithTag("SecondPlayerName").GetComponent<Text>().text =
            GameObject.FindWithTag("SecondPlayer").GetComponent<AbstractPlayer>().GetName();
        buttonController = GameObject.FindWithTag("ButtonController")
            .GetComponent<ButtonController>();
        Debug.Log("ButtonController " + buttonController);
        buttons = buttonController.GetButtons();
        Debug.Log("Start Buttons " + buttons);
    }

    private void Update()
    {
        Debug.Log(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName());
        string log = "";
        foreach(CellState cs in GameManager.GetInstance().GetFieldState())
        {
            if(cs == CellState.Empty) log += "_";
            else log += cs.ToString();
        }
        Debug.Log("Field state: " + log);
        log = "";
        for (int i = 0; i < 9; i++)
        {
            Debug.Log("In a loop " + i);
            Debug.Log("Buttons "+ buttons);
            Debug.Log("Buttons " + i + " " + buttons[i]);
            if (GameManager.GetInstance().GetFieldState()[i] == CellState.O)
            {
                Debug.Log("Button " + i + " sprite = " + buttons[i].image.sprite);
                buttons[i].image.color = new Color(255, 255, 255, 1);
                buttons[i].image.sprite = m_oSprite;
            }
            else if (GameManager.GetInstance().GetFieldState()[i] == CellState.X)
            {
                Debug.Log("Button " + i + " sprite = " + buttons[i].image.sprite);
                buttons[i].image.color = new Color(255, 255, 255, 1);
                buttons[i].image.sprite = m_xSprite;
            }
            else if (GameManager.GetInstance().GetFieldState()[i] == CellState.Empty)
            {
                Debug.Log("Button " + i + " is empty");
                buttons[i].image.color = new Color(0, 0, 0, 0);
            }
            else if (GameManager.GetInstance().GetFieldState()[i] == CellState.Hint)
            {
                Debug.Log("Button " + i + " sprite = " + buttons[i].image.sprite);
                buttons[i].image.color = new Color(255, 255, 255, 0.5f);
                buttons[i].image.sprite = m_HintSprite;
            }
        }
    }

    private void OnDestroy()
    {
        Resources.UnloadAsset(m_xSprite);
        Resources.UnloadAsset(m_oSprite);
        Resources.UnloadAsset(m_HintSprite);
        Debug.Log("Assets unloaded");
    }
}
