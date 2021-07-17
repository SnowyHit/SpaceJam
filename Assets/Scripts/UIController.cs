using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public float timeRemaining{get;set;}
    private GameObject inGamePanel;
    private GameObject diePanel;
    public GameObject pausePanel;
    private float maxTime=60f;
    private Text comboText;
    private Text scoreText;
    private Text timerText;
    private GameObject player;
    private Rigidbody2D rb;
    private ColorController colorController;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining=maxTime;
        PlayerPrefs.SetInt("score", 0);
        inGamePanel=GameObject.Find("inGame");
        diePanel=GameObject.Find("Die");
        diePanel.SetActive(false);
        timerText=GameObject.Find("TimerText").GetComponent<Text>();
        comboText=GameObject.Find("ComboText").GetComponent<Text>();
        scoreText=GameObject.Find("ScoreText").GetComponent<Text>();
        player=GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody2D>();
        colorController=player.GetComponent<ColorController>();
    }

    void Update()
    {
      if(timeRemaining>maxTime){
        timeRemaining=maxTime;
      }
      if(timeRemaining>0){
        timeRemaining-=Time.deltaTime;
      }
      else{
        timeRemaining=0;
        timerText.text="Time : "+timeRemaining.ToString("n2");
        Die();
      }

      timerText.text="Time : "+timeRemaining.ToString("n2");
      comboText.text="Combo x"+(colorController.Combo.ToString());
      scoreText.text="Score : "+PlayerPrefs.GetInt("score").ToString();


    }
    void Die(){
      inGamePanel.SetActive(false);
      diePanel.SetActive(true);
      if(PlayerPrefs.GetInt("score")>PlayerPrefs.GetInt("maxScore",0)){
        PlayerPrefs.SetInt("maxScore", PlayerPrefs.GetInt("score"));
      }


    }
    public void Pause(){
      Time.timeScale=0;
      pausePanel.SetActive(true);
    }
    public void Continue(){
      Time.timeScale=1;
      pausePanel.SetActive(false);
    }

    public void Restart()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
      Time.timeScale=1;
      SceneManager.LoadScene(0);
    }
}
