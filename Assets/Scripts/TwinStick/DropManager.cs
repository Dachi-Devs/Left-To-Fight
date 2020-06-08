using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public static Dictionary<string, int> qualityValues = new Dictionary<string, int>();

    void Start()
    {
        qualityValues.Add("crafting", QualityValues.crafting);
        qualityValues.Add("common", QualityValues.common);
        qualityValues.Add("uncommon", QualityValues.uncommon);
        qualityValues.Add("rare", QualityValues.rare);
        qualityValues.Add("epic", QualityValues.epic);
        qualityValues.Add("legendary", QualityValues.legendary);
    }
}

static class QualityValues
{
    public const int crafting = 20;
    public const int common = 20;
    public const int uncommon = 10;
    public const int rare = 5;
    public const int epic = 2;
    public const int legendary = 1;
}
