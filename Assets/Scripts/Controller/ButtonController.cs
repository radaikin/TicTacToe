using System.Collections.Generic;
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
                ButtonClicked(b.GetComponent<ButtonInfo>().getButtonId());
            });

        }

    }

    void ButtonClicked(int ButtonNumber)
    {
        Debug.Log("Button Num: " + ButtonNumber);
        observer(ButtonNumber);
        buttons[ButtonNumber].interactable = false;
    }

}
