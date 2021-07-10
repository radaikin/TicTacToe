using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField]private GameState m_GameState;
    [SerializeField]private Sprite m_xSprite;
    [SerializeField]private Sprite m_oSprite;
    [SerializeField]private Sprite m_HintSprite;
    [SerializeField]private FieldButtonController buttonController;
    private Button[] buttons;

    //TODO remove FindWithTag()
    //TODO dunno why but I cant set link to button controller in unity. find why and do it

    public void Init()
    {
        
        //GameObject.FindWithTag("FirstPlayerName").GetComponent<Text>().text =
        //    GameObject.FindWithTag("FirstPlayer").GetComponent<AbstractPlayer>().GetName();

        //GameObject.FindWithTag("SecondPlayerName").GetComponent<Text>().text =
        //    GameObject.FindWithTag("SecondPlayer").GetComponent<AbstractPlayer>().GetName();
        buttonController = GameObject.FindWithTag("ButtonController")
            .GetComponent<FieldButtonController>();
        Debug.Log("ButtonController " + buttonController);
        buttons = buttonController.GetButtons();
        Debug.Log("Start Buttons " + buttons);
    }

    public void UpdateView()
    {
        Debug.Log(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName());
        string log = "";
        foreach (CellState cs in m_GameState.GetFieldState())
        {
            if (cs == CellState.Empty) log += "_";
            else log += cs.ToString();
        }
        Debug.Log("Field state: " + log);
        log = "";
        for (int i = 0; i < 9; i++)
        {
            Debug.Log("In a loop " + i);
            Debug.Log("Buttons " + buttons);
            Debug.Log("Buttons " + i + " " + buttons[i]);
            if (m_GameState.GetFieldState()[i] == CellState.O)
            {
                Debug.Log("Button " + i + " sprite = " + buttons[i].image.sprite);
                buttons[i].image.color = new Color(255, 255, 255, 1);
                buttons[i].image.sprite = m_oSprite;
            }
            else if (m_GameState.GetFieldState()[i] == CellState.X)
            {
                Debug.Log("Button " + i + " sprite = " + buttons[i].image.sprite);
                buttons[i].image.color = new Color(255, 255, 255, 1);
                buttons[i].image.sprite = m_xSprite;
            }
            else if (m_GameState.GetFieldState()[i] == CellState.Empty)
            {
                Debug.Log("Button " + i + " is empty");
                buttons[i].image.color = new Color(0, 0, 0, 0);
            }
            else if (m_GameState.GetFieldState()[i] == CellState.Hint)
            {
                Debug.Log("Button " + i + " sprite = " + buttons[i].image.sprite);
                buttons[i].image.color = new Color(255, 255, 255, 0.5f);
                buttons[i].image.sprite = m_HintSprite;
            }
        }
    }

    private void OnDestroy()
    {
    }
}
