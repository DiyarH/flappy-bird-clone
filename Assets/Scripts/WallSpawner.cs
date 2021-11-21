using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public EventManager eventManager;
    public WallInstanceController wall;
    public GameObject gapPrefab;
    [Range(0.0f, 20.0f)]
    public float movementSpeed;
    [Range(0.0f, 5.0f)]
    public float spawnInterval;
    [Range(1.0f, 10.0f)]
    public float gapSize;
    [Range(0.0f, 5.0f)]
    public float gapRangeY;
    private float timeUntilNextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeUntilNextSpawn = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime;
        if (timeUntilNextSpawn <= 0)
        {
            var gapY = Random.Range(-gapRangeY, gapRangeY);
            var topWall = Instantiate(wall);
            var bottomWall = Instantiate(wall);
            var gap = Instantiate(gapPrefab);
            topWall.transform.position = new Vector3(10, gapY + 5 + gapSize / 2);
            bottomWall.transform.position = new Vector3(10, gapY - 5 - gapSize / 2);
            gap.transform.position = new Vector3(10.2f, 0);
            topWall.GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed, 0);
            bottomWall.GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed, 0);
            gap.GetComponent<Rigidbody2D>().velocity = new Vector3(-movementSpeed, 0);
            topWall.eventManager = eventManager;
            bottomWall.eventManager = eventManager;
            timeUntilNextSpawn += spawnInterval;
        }
    }
}
