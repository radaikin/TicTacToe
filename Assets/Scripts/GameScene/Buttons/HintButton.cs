using System.Collections;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    public void Hint()
    {
        StartCoroutine("HintCoroutine");
    }

    private IEnumerator HintCoroutine()
    {
        int cellId = GameObject.FindWithTag("FirstPlayer")
            .GetComponent<Player>().MakeAHint();
        for (int i = 0; i < 3; i++)
        {
            GameManager.GetInstance().SetHintToACell(cellId);
            yield return new WaitForSeconds(.05f);
            GameManager.GetInstance().RemoveHintFromACell(cellId);
            yield return new WaitForSeconds(.1f);
        }
    }

}
