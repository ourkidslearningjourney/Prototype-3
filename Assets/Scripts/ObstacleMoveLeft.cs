using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveLeft : MonoBehaviour
{
    private float speed = 20;
    private float leftLimit = -15;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.isGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftLimit && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
