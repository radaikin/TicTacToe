using UnityEngine;
using UnityEngine.UI;

public delegate void InputEventHandler(int cellId);

public class ButtonController : MonoBehaviour
{
    [SerializeField]private Button[] m_buttons;
    public event InputEventHandler m_observer;

    void Start()
    {
        this.gameObject.tag = "ButtonController";
        int i = 0;
        foreach (Button b in m_buttons)
        {
            m_buttons[i].GetComponent<ButtonInfo>().SetButtonId(i++);
            b.onClick.AddListener(() =>
            {
                m_observer(b.GetComponent<ButtonInfo>().GetButtonId());
            });
        }
    }

    public Button[] GetButtons() => m_buttons;

    private void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            CellState[] field = GameManager.GetInstance().GetField();
            if (field[i] != CellState.Empty)
            {
                m_buttons[i].interactable = false;
            }
            else m_buttons[i].interactable = true;
        }
    }
}
