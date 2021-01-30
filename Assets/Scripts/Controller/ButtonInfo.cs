using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int buttonId;
    private bool isClicked;

    public int getButtonId() => buttonId;

    public bool getIsClicked() => isClicked;

    public void setIsClicked(bool isClicked) => this.isClicked = isClicked;

}
