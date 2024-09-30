using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float Score { get; private set; }
    public bool GameOver { get; set; }
    [SerializeField] private PlayerController playerControllerScript;
    public PlayerController GetPlayerController() {  return playerControllerScript; }

    public Transform startingPoint;
    public float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        Score = 0;

        GameOver = true;
        StartCoroutine(PlayIntro());


    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver && Time.timeScale == 1)
        {
            if (playerControllerScript.IsDoubleSpeedable)
            {
                Score += (2 * Time.deltaTime);
            }
            else
            {
                Score += Time.deltaTime;
            }
        }

    }

    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerControllerScript.transform.position;
        Vector3 endPos = startingPoint.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;
        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier",
        0.5f);
        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos,
            fractionOfJourney);
            yield return null;
        }
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        GameOver = false;

    }
}
