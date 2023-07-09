using System;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    public string Task;
    private Func<List<Ingredient>, bool> Function;
    public Instruction(string task, Func<List<Ingredient>, bool> check)
    {
        Task = task;
        Function = check;
    }
    public bool Check(List<Ingredient> ingredients)
    {
        return Function(ingredients);
    }
}
