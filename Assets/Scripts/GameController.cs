using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
  private bool isGameRunning;
  private int score;

  public ObstacleGenerator generator;
  public GameConfiguration config;
  public TextMeshProUGUI scoreLabel;
  public GameObject gameOverScreen;
  void Start()
  {
    isGameRunning = false;

    GameStart();
  }

  private void FixedUpdate()
  {
    scoreLabel.text = score.ToString("000000.##");

    if (!isGameRunning) return;
    score++;

  }

  void GameStart()
  {
    isGameRunning = true;

    config.speed = 4f;
    generator.GenerateObstacles();
    score = 0;
  }

  public void GameOver()
  {
    isGameRunning = false;

    config.speed = 0f;
    generator.StopGenerator();
    gameOverScreen.SetActive(true);
  }
}
