using UnityEngine;

public class ButtonInfo : MonoBehaviour
{
    private int buttonId;
    private bool isClicked;

    public int GetButtonId() => buttonId;

    public void SetButtonId(int buttonId) => this.buttonId = buttonId;

    public bool GetIsClicked() => isClicked;

    public void SetIsClicked(bool isClicked) => this.isClicked = isClicked;

}
