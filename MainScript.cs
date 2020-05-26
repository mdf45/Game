using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public static long Warriors = 5;
    public static long Gold = 0;
    public static long Food = 0;

    public Text WarriorsText;
    public Text GoldText;
    public Text FoodText;
    void Start()
    {
        WarriorsText.text = Warriors.ToString();
        GoldText.text = Gold.ToString();
        FoodText.text = Food.ToString();
    }

    void Update()
    {
        WarriorsText.text = Warriors.ToString();
        GoldText.text = Gold.ToString();
        FoodText.text = Food.ToString();
    }
}
