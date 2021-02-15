using UnityEngine;
using UnityEngine.UI;

public delegate void InputEventHandler(int cellId);

public class ButtonController : MonoBehaviour
{
    [SerializeField]private Button[] buttons;
    public event InputEventHandler observer;
    public Vector2 sizeDelta;

    void Start()
    {
        sizeDelta = new Vector2(Screen.height * 0.9f, Screen.height * 0.9f);
        gameObject.GetComponent<RectTransform>().sizeDelta = sizeDelta;
        buttons = new Button[9];
        buttons[0] = gameObject.GetComponentInChildren<Button>();
        int i = 0;
        foreach (Button b in buttons)
        {
            b.GetComponent<ButtonInfo>().SetButtonId(i++);
            b.onClick.AddListener(() =>
            {
                observer(b.GetComponent<ButtonInfo>().GetButtonId());
            });
            
        }
    }

    public Button[] GetButtons() => buttons;
}
