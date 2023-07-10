using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public TextMeshProUGUI TextMenu;
    private Transform[] Positions;
    // Для проверки соблюдения иутрукций
    private List<Ingredient> CurrentIngredients;
    // Чтобы было удобно удалять объекты (ингредиенты на пицце)
    private List<GameObject> CurrentGameObjects;
    private Ingredient CurrentIngredient;
    private Instruction CurrentInstruction;
    private int money;
    public TextMeshProUGUI MoneyText;
    private int attempCount;
    public TextMeshProUGUI AttempCountText;

    public Button AddButton;
    public Button RemoveButton;
    public Button FinishButton;

    public void ChangeInstruction()
    {
        CurrentInstruction = InstructionArray.Instructions[Random.Range(0, InstructionArray.Instructions.Length - 1)];
        TextMenu.text = CurrentInstruction.Task;
    }

    public void BlockButton()
    {
        RemoveButton.interactable = false;
        FinishButton.interactable = false;
    }

    private void Start()
    {
        ChangeInstruction();
        BlockButton();
    }

    private void Update()
    {
        if (GameTimer.CurrentSec == 0)
            MakePizza();
    }

    public void ChangeIngredient(Ingredient ingredient)
    {
        CurrentIngredient = ingredient;
    }
    // И такой метод для каждого ингредиента 
    // Называь методы можно по названию ингредиента
    public void ChooseIngredient0()
    {
        ChangeIngredient(IngredientArray.Ingredients[0]);
    }
    // Прикрепляется к кнопке +
    public void AddIngredient()
    {
        CurrentIngredients.Add(CurrentIngredient);
        GameObject obj = Instantiate(CurrentIngredient.Object, Positions[CurrentGameObjects.Count]);
        CurrentGameObjects.Add(obj);

        RemoveButton.interactable = true;
        if (CurrentIngredients.Count > 9)
            FinishButton.interactable = true;
        if (CurrentIngredients.Count == 20)
            AddButton.interactable = false;
    }
    // Прикрепляется к кнопке -
    public void RemoveIngredient()
    {
        CurrentIngredients.RemoveAt(CurrentIngredients.Count - 1);
        var obj = CurrentGameObjects[CurrentGameObjects.Count - 1];
        CurrentGameObjects.Remove(obj); 
        Destroy(obj);

        if (CurrentIngredients.Count < 10)
            FinishButton.interactable = false;
        if (CurrentIngredients.Count == 0)
            RemoveButton.interactable = false;
    }
    // Прикрепляется к кнопке сбросить пицццу
    public void ResesPizza()
    {
        CurrentIngredients = new List<Ingredient>();
        foreach (var obj in CurrentGameObjects)
            Destroy(obj);
        CurrentGameObjects = new List<GameObject>();
    }

    public void CheckPizza()
    {
        if (CurrentInstruction.Check(CurrentIngredients) && attempCount > 0)
            MoneyText.text = (money + 100).ToString();
            if (GameTimer.CurrentSec > 20)
                MoneyText.text = (money + 50).ToString();
            else if (GameTimer.CurrentSec > 10)
                MoneyText.text = (money + 30).ToString();
        if (attempCount > 0)
            AttempCountText.text = (attempCount - 1).ToString();
    }
    // Прикрепляется к кнопке завершить
    public void MakePizza() 
    { 
        ResesPizza();
        CheckPizza();
        ChangeInstruction();
        BlockButton();
    }
}
