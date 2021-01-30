using UnityEngine;

public class Player: AbstractPlayer
{
    bool canPlay;

    public Player(PlayerSide playerSide)
    {
        GameObject.FindGameObjectWithTag("ButtonController")
        .GetComponent<ButtonController>().observer += OnControllerPreset;
        this.SetSide(playerSide);
        canPlay = playerSide == PlayerSide.FirstPlayer;
    }

    public override void MakeAMove()
    {
        canPlay = true;   
    }

    public void OnControllerPreset(int cellId)
    {
        if (!canPlay || GameManager.GetInstance().getField()[cellId] != CellState.Empty) return;
        GameManager.GetInstance().ChangeCellStateOnFiled(cellId, this.GetPlayerSide());
        canPlay = false;
        GetNextPlayer().MakeAMove();
    }
}
