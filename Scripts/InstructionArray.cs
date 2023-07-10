using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InstructionArray : MonoBehaviour
{
    private static bool Function1(int count, bool isMeat, List<Ingredient> ingredients)
    {
        var ingredientList = ingredients.Select(x => x.Name);
        var ingredientsHash = new HashSet<Ingredient>(ingredients);
        var ingredientCount = new List<int>();
        foreach (var ingredient in ingredientsHash)
            ingredientCount.Add(ingredients.Count(x => x.Name == ingredient.Name));
        return ingredientsHash.Count() == count && ingredientsHash.Count(x => x.IsMeat == isMeat) == count && new HashSet<int>(ingredientCount).Count() == count;
    }
    // Придумать и добавить сюда все инструкции
    public static Instruction[] Instructions =
    {
        new Instruction("Приготовить пиццу, изспользуя только 2 вида мяса. Использовать все виды овощей в равном количестве.",
            x => Function1(2, false, x)),
        new Instruction("Приготовить пиццу, изспользуя только 3 вида мяса. Использовать все виды овощей в равном количестве.",
            x => Function1(3, false, x)),
        new Instruction("Приготовить пиццу, изспользуя только 2 вида овощей или грибов. Использовать все виды овощей в равном количестве.",
            x => Function1(2, true, x)),
        new Instruction("Приготовить пиццу, изспользуя только 3 вида овощей или грибов. Использовать все виды овощей в равном количестве.", 
            x => Function1(3, true, x)),
        new Instruction("Приготовить пиццу наполовину из мяса, наполовину из овощей",
            x => x.Count(y => y.IsMeat) == x.Count(y => !y.IsMeat)),
        new Instruction("Приготовить пиццу наполовину из мяса и овощей, мяса должно быть в 2 раза больше",
            x => x.Count(y => y.IsMeat) == 2 * x.Count(y => !y.IsMeat)),
        new Instruction("Приготовить пиццу наполовину из мяса и овощей, овощей должно быть в 2 раза больше",
            x => 2 * x.Count(y => y.IsMeat) == x.Count(y => !y.IsMeat)),
        new Instruction("Добавьте в пиццу каждый вид овощей (не грибов) по одному разу, затем добавьте столько грибов, сколько было добавлено овощей",
            x => x.Count(y => y.Name == "Tomato") == 1 && x.Count(y => y.Name == "Cucumber") == 1 && x.Count(y => y.Name == "Onion") == 1 &&
            x.Count(y => y.Name == "Olives") == 1 && x.Count(y => y.Name == "Greens") == 1 && x.Count(y => y.Name == "Mushroom") == 5),
        new Instruction("Приготовить пиццу только из красных ингредиентов, мяса должно быть в 2 раза больше",
            x => x.Count() == x.Count(y => y.Color == "red") && x.Count(y => y.IsMeat) == 2 * x.Count(y => !y.IsMeat)),
        new Instruction("Приготовить пиццу только из красных ингредиентов, овощей должно быть в 2 раза больше",
            x => x.Count() == x.Count(y => y.Color == "red") && 2 * x.Count(y => y.IsMeat) == x.Count(y => !y.IsMeat)),
    };
}
