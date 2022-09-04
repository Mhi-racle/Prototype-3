
using System.Transactions;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30f;
    private PlayerController playerController;
    public float leftBound = -15;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if ((transform.position.x < leftBound) && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);

        }

    }
}
