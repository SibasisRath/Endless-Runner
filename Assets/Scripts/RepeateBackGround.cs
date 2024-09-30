using UnityEngine;

public class RepeateBackGround : MonoBehaviour
{
    private Vector3 startingPosition;
    private float speed = 10;
    [SerializeField] private float repeatPosition;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        repeatPosition = GetComponent<BoxCollider>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.GameOver == false)
        {
            if (playerController.IsDoubleSpeedable)
            {
                transform.Translate(Vector3.left * Time.deltaTime * (speed * 2));
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

            
            if (transform.position.x <= startingPosition.x - repeatPosition)
            {
                transform.position = startingPosition;
            }
        }
    }

}
