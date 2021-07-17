using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Text hsText;
    public GameObject helpPanel;
    public GameObject menuPanel;
    private void Start()
    {
      hsText.text="High Score: "+PlayerPrefs.GetInt("maxScore").ToString();
    }

    public void HelpButton()
    {
      menuPanel.SetActive(false);
      helpPanel.SetActive(true);
    }
    public void PlayButton()
    {
      SceneManager.LoadScene(1);

    }
    public void BackButton()
    {
      helpPanel.SetActive(false);
      menuPanel.SetActive(true);

    }

}
