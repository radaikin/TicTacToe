using UnityEngine;

public class ButtonId : MonoBehaviour
{

    [Header("Parameters")]
    [SerializeField] private int buttonId;

    public int getButtonId() => buttonId;
}
