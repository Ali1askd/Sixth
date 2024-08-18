using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int Player1Score;
    private int Player2Score;

    public Text Player1ScoreText;
    public Text Player2ScoreText;

    public void Player1Goal() 
    {
        Player1Score++;
        Player1ScoreText.text = Player1Score.ToString();
        
    }
    public void Player2Goal()
    {
        Player2Score++;
        Player2ScoreText.text = Player2Score.ToString();

    }
}


