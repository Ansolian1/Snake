using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAccess : MonoBehaviour
{
    public static GlobalAccess Instance;
    public ColorEnum playerColorEnum;

    public Fever fever;
    public Score score;

    private void Awake()
    {
        Instance = this;
    }

    public enum ColorEnum
    {
        Red = 1,
        Green = 2,
        Blue = 3,
        Yellow = 4,
        Cyan = 5,
        Purple = 6,
        Pink = 7,
        Orange = 8
    }

    public Color GetColor(ColorEnum colorList)
    {
        switch (colorList)
        {
            case ColorEnum.Red:
                return Color.red;
            case ColorEnum.Green:
                return Color.green;
            case ColorEnum.Blue:
                return Color.blue;
            case ColorEnum.Yellow:
                return Color.yellow;
            case ColorEnum.Cyan:
                return Color.cyan;
            case ColorEnum.Purple:
                return Color.magenta;
            case ColorEnum.Pink:
                return new Color(1, 0.1f, 0.5f, 1);
            case ColorEnum.Orange:
                return new Color(1, 0.1f, 0, 1);
            default:
                return Color.white;
        }
    }
}
