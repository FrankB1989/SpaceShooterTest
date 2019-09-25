using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionPlayer;
    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Impossibile trovare lo script 'GameController'");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        if(explosion != null) { 
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            scoreValue = 0;
        }
        gameController.addScore(scoreValue);
        other.gameObject.SetActive(false);
        //Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
