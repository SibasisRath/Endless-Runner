using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScript : MonoBehaviour
{
    [SerializeField] GameObject instructionScreen;

    private void Start()
    {
        Time.timeScale = 0.0f;
        instructionScreen.SetActive(true);
    }
   public void OnStart()
    {
        Time.timeScale = 1f;
        instructionScreen.SetActive(false);
    }
}
