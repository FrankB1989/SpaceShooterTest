using UnityEngine;
using System.Collections;

public class ManovreEvasive : MonoBehaviour {

    public float dodge;
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;
    private Transform player;

    private float currentSpeed;
    private float targetManeuver;
    private Rigidbody rigidB;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidB = GetComponent<Rigidbody>();
        currentSpeed = rigidB.velocity.z;
        StartCoroutine(Evade());
	}

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true) {
            targetManeuver = player.position.x;
            //targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float newManeuver = Mathf.MoveTowards(rigidB.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rigidB.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        rigidB.position = new Vector3
            (
            Mathf.Clamp(rigidB.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidB.position.z, boundary.zMin, boundary.zMax)
            );
        rigidB.rotation = Quaternion.Euler(0.0f, 0.0f, rigidB.velocity.x * -tilt);

    }
}
