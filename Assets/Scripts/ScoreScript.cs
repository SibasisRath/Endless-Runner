using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTextMeshProUGUI;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        scoreTextMeshProUGUI.text = "Score: " + Mathf.FloorToInt(gameManager.Score);
    }
}
