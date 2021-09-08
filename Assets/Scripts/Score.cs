using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    public Text scoreUI;

    public void AddScore(int count)
    {
        score += count;
        scoreUI.text = score.ToString();
    }
}
