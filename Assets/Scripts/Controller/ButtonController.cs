using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, ISubject
{
    private GameManager gameManager;
    public Button[] buttons;

    void Start()
    {
        gameManager = GameManager.getInstance();

        foreach(Button b in buttons)
        {
            b.onClick.AddListener(() =>
            {
                ButtonClicked(b.GetComponent<ButtonId>().getButtonId());
            });

        }

    }

    void ButtonClicked(int ButtonNumber)
    {
        Debug.Log("Button Num: " + ButtonNumber);

    }

    public void Attach(IObserver observer)
    {
        throw new System.NotImplementedException();
    }

    public void Detach(IObserver observer)
    {
        throw new System.NotImplementedException();
    }

    public void Notify()
    {
        throw new System.NotImplementedException();
    }
}
