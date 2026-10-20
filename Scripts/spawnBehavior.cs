using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class spawnBehavior : MonoBehaviour
{
    public GameObject Panel_Game;
    public GameObject Panel_Start;
    public GameObject Panel_Over;
    public GameObject spawnObject;

    public TMP_Text hpText;
    public TMP_Text scoreText;
    public TMP_Text timerText;

    public float remainingTime;
    public int hp;
    private int score;
    public int timercheck = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = 100;
        remainingTime = 31;
        UpdateHealthText();
        UpdateScoreText();

    }

    // Update is called once per frame
    void Update() {
        StartTime();
        if (remainingTime <= 0) {
            timercheck = 2;
            GameOver();
        }
    }

    void StartTime() {
        if (timercheck == 1) {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void GoHomeScene() {
        SceneManager.LoadScene("MainMenu_Scene");
    }

    public void RestartScene() {
        SceneManager.LoadScene("Game_Scene");
    }

    public void StartGame() {
        Panel_Start.SetActive(false);
        Panel_Game.SetActive(true);
        timercheck = 1;
    }

    void SpawnCube() {
        Vector3 spawnPosition = new Vector3(Random.Range(-6, 6), 1f, Random.Range(-6, 6));
        Instantiate(spawnObject, spawnPosition, Quaternion.identity);
    }

    public void SpawnCubeTrigger() {
        SpawnCube();
        hp -= 10;
        UpdateHealthText();
        score++;
        UpdateScoreText();

        if (hp == 0) {
            GameOver();
        }
    }

    public void GameOver() {
            Panel_Game.SetActive(false);
            Panel_Over.SetActive(true);
    }

    void UpdateHealthText() {
        hpText.text = "Health: " + hp;
    }

    void UpdateScoreText() {
        scoreText.text = "Score: " + score;
    }


}
