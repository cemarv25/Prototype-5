using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody targetRB;
    float minSpeed = 12;
    float maxTorque = 10;
    float ySpawnPos = -3;
    float maxSpeed = 16;
    float xRange = 4;
    GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxSpeed);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        if(gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if(gameObject.CompareTag("Good"))
        {
            gameManager.UpdateScore(-3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
