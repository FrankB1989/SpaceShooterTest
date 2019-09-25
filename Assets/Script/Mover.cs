using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

    void Start()
    {         
        /*if (gameObject.tag == "Asteroid") {
            speed = Random.Range(speed * 2, speed);
        }*/
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
