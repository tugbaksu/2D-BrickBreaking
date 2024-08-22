using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class GameManager : MonoBehaviour
{
    public int score;
    public int live;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI liveText;

    public bool gameOver=false;
   
    void Start()
    {
        score = 0;
        live = 3;
    }

    void Update()
    {
        scoreText.text = "Skor: " + score.ToString();
        liveText.text = "Can: " + live.ToString();

        if (gameOver == true)
        {
            Debug.Log("Game Over tetiklendi, sahne deðiþtiriliyor...");
            GameOver();
        }
    }

    public void GameOver()
    {
        if (live ==0) 
        {
            gameOver = true;
            Debug.Log("Canlar bitti, oyun bitiyor...");
            SceneManager.LoadScene("GameOver");
        }
       
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
        Debug.Log("Butona basýldý");
    }


}
