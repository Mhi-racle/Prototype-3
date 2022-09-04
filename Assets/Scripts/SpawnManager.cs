using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2f;
    private float repeatDelay = 2f;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (playerController.gameOver == false)
        {
            int random = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[random], spawnPos, obstaclePrefabs[random].transform.rotation);
        }

    }
}
