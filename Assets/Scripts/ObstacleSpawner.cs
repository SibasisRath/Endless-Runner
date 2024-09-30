using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacleObject;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameManager gameManager;
    private float initialTime = 2f;
    private float repeateGap;
    [SerializeField] private float initialSpeed = 10f;

    private void Awake()
    {
        repeateGap = Random.Range(3f,5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Obstacles", initialTime, repeateGap);
    }

    void Obstacles()
    {
        if (gameManager.GameOver == false)
        {
            GameObject obstacleObj = Instantiate(obstacleObject[Random.Range(0, obstacleObject.Count)], transform.position, Quaternion.identity);
            ObstacleMoveScript obstacleMoveScript = obstacleObj.GetComponent<ObstacleMoveScript>();
            obstacleMoveScript.SetGameManager(gameManager);
            obstacleMoveScript.SetPlayerController(playerController);
            obstacleMoveScript.SetSpeed(initialSpeed);
        }
    }
}
