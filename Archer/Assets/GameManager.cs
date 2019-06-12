using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public void UpdateScore (int scoreAddition)
    {
        score += scoreAddition;
        scoreText.text = "SCORE : " + score.ToString ();
    }

}
