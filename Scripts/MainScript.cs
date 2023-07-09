using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    public TextMeshProUGUI Money;
    public TextMeshProUGUI AttempCount;

    public void ChangeInstruction()
    {
        CurrentInstruction = InstructionArray.Instructions[Random.Range(0, InstructionArray.Instructions.Length - 1)];
        TextMenu.text = CurrentInstruction.Task;
    }

    private void Start()
    {
        ChangeInstruction();   
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
    }
    // Прикрепляется к кнопке -
    public void RemoveIngredient()
    {
        CurrentIngredients.RemoveAt(CurrentIngredients.Count - 1);
        var obj = CurrentGameObjects[CurrentGameObjects.Count - 1];
        CurrentGameObjects.Remove(obj); 
        Destroy(obj);
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
        if (CurrentInstruction.Check(CurrentIngredients) && int.Parse(AttempCount.text) > 0)
            Money.text = (int.Parse(Money.text) + 100).ToString();
        if (int.Parse(AttempCount.text) > 0)
            AttempCount.text = (int.Parse(AttempCount.text) - 1).ToString();
    }
    // Прикрепляется к кнопке завершить
    public void MakePizza()
    { 
        ResesPizza();
        CheckPizza();
        ChangeInstruction();
    }
}
