using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    private Sprite m_xSprite;
    private Sprite m_oSprite;
    private Sprite m_HintSprite;
    private ButtonController buttonController;
    private Button[] buttons;
    private CellState[] fieldState;

    void Start()
    {
        fieldState = GameManager.GetInstance().GetField();

        m_xSprite = Resources.Load<Sprite>("MoonActive/ExTarget");
        m_oSprite = Resources.Load<Sprite>("MoonActive/CircleTarget");
        m_HintSprite = Resources.Load<Sprite>("Buttons/Hint");

        GameObject.FindWithTag("FirstPlayerName").GetComponent<Text>().text =
            GameObject.FindWithTag("FirstPlayer").GetComponent<AbstractPlayer>().GetName();
        GameObject.FindWithTag("SecondPlayerName").GetComponent<Text>().text =
            GameObject.FindWithTag("SecondPlayer").GetComponent<AbstractPlayer>().GetName();

        buttonController = GameObject.FindGameObjectWithTag("ButtonController")
            .GetComponent<ButtonController>();
        buttons = buttonController.GetButtons();
    }

    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            if (fieldState[i] == CellState.O)
            {
                buttons[i].image.color = new Color(255, 255, 255, 1);
                buttons[i].image.sprite = m_oSprite;
            }
            else if (fieldState[i] == CellState.X)
            {
                buttons[i].image.color = new Color(255, 255, 255, 1);
                buttons[i].image.sprite = m_xSprite;
            }
            else if (fieldState[i] == CellState.Empty)
            {
                buttons[i].image.color = new Color(0, 0, 0, 0);
            }
            else if (fieldState[i] == CellState.Hint)
            {
                buttons[i].image.color = new Color(255, 255, 255, 0.5f);
                buttons[i].image.sprite = m_HintSprite;
            }
        }
    }
}
