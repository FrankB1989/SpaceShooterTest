using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public GameObject shoot;
    public Transform shootSpawn;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;


	void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
	}

    void Fire() {
        Instantiate(shoot, shootSpawn.position, shootSpawn.rotation);
        audioSource.Play();
    }

}
