using UnityEngine;
using UnityEngine.UI;

public class BlockButtons : MonoBehaviour
{
    public Button AddButton;
    public Button RemoveButton;
    public Button FinishButton;
    void Update()
    {
        if (MainScript.CurrentIngredients.Count > 19)
            AddButton.interactable = false;
        if (MainScript.CurrentIngredients.Count == 0)
            RemoveButton.interactable = false;
        if (MainScript.CurrentIngredients.Count < 10)
            FinishButton.interactable = false;
    }
}
