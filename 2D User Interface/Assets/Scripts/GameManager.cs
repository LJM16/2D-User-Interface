using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Target;

    public bool IsGameActive = true;
    public int Score = 0;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public Button RestartButton;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score: " + Score;
        StartCoroutine(SpawnTarget());

    }

    // Update is called once per frame
    public void UpdateScore(int addToScore)
    {
        Score += addToScore;
        Debug.Log("Score: " + Score.ToString());
        ScoreText.text = "Score: " + Score.ToString();
    }

    public void GameOver()
    {
        IsGameActive = false;
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnTarget()
    {
        while(IsGameActive)
        {
             yield return new WaitForSeconds(1);
        int index = Random.Range(0, Target.Count);
        Instantiate(Target[index]);
        }
    }

    
}
