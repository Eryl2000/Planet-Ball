﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownUI : MonoBehaviour {

    static CountDownUI instance = null;

    public int countDownTime = 3;
    public Text countDownText;

    public Color team1Color;
    public Color team2Color;

    private float currentCountDown = 0;
    private bool counting = false;
    private Ball currentBall;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(counting)
        {
            countDownText.text = Mathf.CeilToInt(currentCountDown).ToString();
            currentCountDown -= Time.deltaTime;

            if(currentCountDown < 0)
            {
                currentBall.ResetBall();
                counting = false;
                countDownText.gameObject.SetActive(false);
            }
        }
    }

    public static void StartCountdown(Ball ball, int playerNumber)
    {


        ball.Score();
        instance.currentBall = ball;
        instance.currentCountDown = instance.countDownTime;
        instance.counting = true;
        instance.countDownText.color = instance.GetColor(playerNumber);
        instance.countDownText.gameObject.SetActive(true);
    }

    private Color GetColor(int teamNumber)
    {
        if (teamNumber == 1)
        {
            return team1Color;
        }
        else if (teamNumber == 2)
        {
            return team2Color;
        }
        else
        {
            Debug.LogError("Invalid team number!");
            return Color.black;
        }
    }
}
