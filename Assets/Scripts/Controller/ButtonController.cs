using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IControllerSubject
{
    public Button[] buttons;
    private List<IControllerObserver> observers = new List<IControllerObserver>();

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
        Notify(ButtonNumber);
        buttons[ButtonNumber].interactable = false;
    }

    //Listener will send you CellId of pushed Button
    public void Attach(IControllerObserver observer)
    {
        observers.Add(observer);
        Debug.Log("Observer was added!");
    }

    public void Detach(IControllerObserver observer)
    {
        observers.Remove(observer);
        Debug.Log("Observer was removed!");
    }

    public void Notify(int cellNumber)
    {
        observers.ForEach((obj) => obj.Update(cellNumber));
    }
}
