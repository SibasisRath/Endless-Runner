using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score;
    private PlayerController playerControllerScript;

    public Transform startingPoint;
    public float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        score = 0;

        playerControllerScript.gameOver = true;
        StartCoroutine(PlayIntro());


    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver && Time.timeScale == 1)
        {
            if (playerControllerScript._isDoubleSpeedable)
            {
                score += 2;
            }
            else
            {
                score++;
            }
            Debug.Log("Score: " + score);
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
        playerControllerScript.gameOver = false;

    }
}