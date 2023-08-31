using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveScript : MonoBehaviour
{
    private float _speed = 10;
    private PlayerController playerController;
    // Update is called once per frame
    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (playerController.gameOver == false)
        {
            if (playerController._isDoubleSpeedable)
            {
                transform.Translate(Vector3.left * Time.deltaTime * (_speed * 2));
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
            }

            
            if (transform.position.x <= -11)
            {
                Destroy(gameObject);
            }
        }
    }
}
