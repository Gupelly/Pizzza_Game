using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public TextMeshProUGUI TextMenu;
    private Transform[] Positions;
    // ��� �������� ���������� ���������
    private List<Ingredient> CurrentIngredients;
    // ����� ���� ������ ������� ������� (����������� �� �����)
    private List<GameObject> CurrentGameObjects;
    private Ingredient CurrentIngredient;
    private Instruction CurrentInstruction;
    private int money;
    public TextMeshProUGUI MoneyText;
    private int attempCount;
    public TextMeshProUGUI AttempCountText;

    public void ChangeInstruction()
    {
        CurrentInstruction = InstructionArray.Instructions[Random.Range(0, InstructionArray.Instructions.Length - 1)];
        TextMenu.text = CurrentInstruction.Task;
    }

    private void Start()
    {
        ChangeInstruction();   
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
    // � ����� ����� ��� ������� ����������� 
    // ������� ������ ����� �� �������� �����������
    public void ChooseIngredient0()
    {
        ChangeIngredient(IngredientArray.Ingredients[0]);
    }
    // ������������� � ������ +
    public void AddIngredient()
    {
        CurrentIngredients.Add(CurrentIngredient);
        GameObject obj = Instantiate(CurrentIngredient.Object, Positions[CurrentGameObjects.Count]);
        CurrentGameObjects.Add(obj);
    }
    // ������������� � ������ -
    public void RemoveIngredient()
    {
        CurrentIngredients.RemoveAt(CurrentIngredients.Count - 1);
        var obj = CurrentGameObjects[CurrentGameObjects.Count - 1];
        CurrentGameObjects.Remove(obj); 
        Destroy(obj);
    }
    // ������������� � ������ �������� ������
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
    // ������������� � ������ ���������
    public void MakePizza() 
    { 
        ResesPizza();
        CheckPizza();
        ChangeInstruction();
    }
}
