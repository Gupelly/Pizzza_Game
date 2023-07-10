using UnityEngine;

public class IngredientArray : MonoBehaviour
{
    public static Ingredient[] Ingredients = {new Ingredient("Pepperoni", new GameObject(), true, "red"),
    new Ingredient("Bacon", new GameObject(), true, "red"),
    new Ingredient("Shrimps", new GameObject(), true, "red"),
    new Ingredient("Cucumber", new GameObject(), false, "green"),
    new Ingredient("Tomato", new GameObject(), false, "red"),
    new Ingredient("Olives", new GameObject(), false, "black"),
    new Ingredient("Mushroom", new GameObject(), false, "white"),
    new Ingredient("Onion", new GameObject(), false, "purple"),
    new Ingredient("Greens", new GameObject(), false, "green"),};
}
