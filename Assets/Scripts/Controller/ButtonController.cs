using UnityEngine;
using UnityEngine.UI;

public delegate void InputEventHandler(int cellId);

public class ButtonController : MonoBehaviour
{

    public Button[] buttons;

    public event InputEventHandler observer;

    void Start()
    {
        foreach (Button b in buttons)
        {
            b.onClick.AddListener(() =>
            {
                observer(b.GetComponent<ButtonInfo>().getButtonId());
            });

        }

    }


}
