using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{

    public int groundCounter;

    public Slider scoreGainSlider;
    public TextMeshProUGUI scoreGainText;
    public TextMeshProUGUI scoreText;
    public float score;
    public float point=10;

    public BallController ballController;



    void Start()
    {

        

        groundCounter = 0;
        
        scoreGainSlider.value = 1;
        scoreGainSlider.maxValue = 3;
        scoreGainSlider.minValue = 0.6f;



    }

    
    void Update()
    {
        
        UpdateUI();
        ScoreGainFixer();

       }


    public void GainPoint()
    {
        if (groundCounter>0 && groundCounter % 10==0)
        {
            score += point* ballController.pointMultiplier; 
        }
    }

    public void UpdateUI()
    {
        scoreText.text = "Score: " +score.ToString();
        scoreGainText.text = "Score Gain x" + ballController.pointMultiplier.ToString();
        scoreGainSlider.value = ballController.pointMultiplier;
    }

    public void ScoreGainFixer()
    {
        if (ballController.pointMultiplier <= 0.6f)
        {
            ballController.pointMultiplier = 0.6f;
        }
        if (ballController.pointMultiplier > 3f)
        {
            ballController.pointMultiplier = 3f;
        }
    }
    
}
