using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    private Sprite x_sprite;
    private Sprite o_sprite;
    private ButtonController buttonController;
    private Button[] buttons;
    private CellState[] field;

    void Start()
    {
        field = GameManager.GetInstance().GetField();

        x_sprite = Resources.Load<Sprite>("MoonActive/ExTarget");
        o_sprite = Resources.Load<Sprite>("MoonActive/CircleTarget");

        buttonController = GameObject.FindGameObjectWithTag("ButtonController")
            .GetComponent<ButtonController>();
        buttons = buttonController.GetButtons();
    }

    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            if (field[i] == CellState.O)
            {
                buttons[i].image.color = new Color(255, 255, 255, 1);
                buttons[i].image.sprite = o_sprite;
            }
            else if (field[i] == CellState.X)
            {
                buttons[i].image.color = new Color(255, 255, 255, 1);
                buttons[i].image.sprite = x_sprite;
            }
            else if (field[i] == CellState.Empty)
            {
                buttons[i].image.color = new Color(0, 0, 0, 0);
            }
        }
    }
}
