using UnityEngine;

public class ControllerEventHandler : IControllerObserver
{
    private ButtonController buttonController = GameObject
        .FindGameObjectWithTag("ButtonController")
        .GetComponent<ButtonController>();


    public ControllerEventHandler()
    {
        buttonController.Attach(this);
    }

    

    public void Update(int CellId)
    {
        GameManager.GetInstance().ChangeCellStateOnFiled(CellId);
        Debug.Log("Cell state in Game Manager was updated!");
    }
}
