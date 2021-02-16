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
                var tmp = b.GetComponent<ButtonInfo>().GetButtonId();
                m_observer(b.GetComponent<ButtonInfo>().GetButtonId());
            });
        }
    }

    public Button[] GetButtons() => m_buttons;
}
