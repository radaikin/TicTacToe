using UnityEngine;

public class UndoButton : MonoBehaviour
{
    public void Undo()
    {
        if (!FieldIsEmpty())
        {
            GameManager.GetInstance().UndoLastStep();
        }
    }

    private bool FieldIsEmpty()
    {
        bool FieldIsEmpty = true;
        CellState[] fieldState = GameManager.GetInstance().GetFieldState();
        foreach (CellState cs in fieldState)
        {
            if (cs != CellState.Empty) FieldIsEmpty = false;
        }
        return FieldIsEmpty;
    }
}
