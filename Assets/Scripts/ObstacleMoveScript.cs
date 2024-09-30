using UnityEngine;

public class ObstacleMoveScript : MonoBehaviour
{
    private float _speed;
    private PlayerController playerController;
    private GameManager gameManager;

    public void SetSpeed(float val) { this._speed = val; }
    public void SetPlayerController(PlayerController playerController) { this.playerController = playerController; }
    public void SetGameManager(GameManager gameManager) { this.gameManager = gameManager; }
    void Update()
    {
        if (gameManager.GameOver == false)
        {
            if (playerController.IsDoubleSpeedable)
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
