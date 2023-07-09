using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string Name;
    public GameObject Object;
    public bool IsMeat;
    public string Color;
    // ����� �������� ���
    public Ingredient(string name, GameObject gameObject, bool isMeat, string color)
    {
        Name = name;
        Object = gameObject;
        IsMeat = isMeat;
        Color = color;
    }
}
