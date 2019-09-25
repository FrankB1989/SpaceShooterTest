using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text gameOverText;
    public Text RestartText;

    private bool gameOver;
    private bool restart;

    private int score;

    void Start () {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        RestartText.text = "";
        score = 0;
        updateScore();
        StartCoroutine(spawnWaves());
	}

    void Update() {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(Application.loadedLevel); 
            }
        }
    }
	
    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true) { 
            for(int i = 0; i < hazardCount; i++) {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver) {
                RestartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
    }

    public void addScore(int scoreValue) {
        score += scoreValue;
        updateScore();
    }

    void updateScore() {
        scoreText.text = "Score" + score;
    }

    public void GameOver() {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
