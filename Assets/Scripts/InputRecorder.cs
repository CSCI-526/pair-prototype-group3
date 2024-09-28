using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    private string inputSequence = "";
    private float lastInputTime;
    public float inputTimeThreshold = 3f; // Set the input time threshold in seconds
    public KeyCode keyToPress1, keyToPress2;

    void Update()
    {
        if (Input.GetKeyDown(keyToPress1))
        {
            RecordInput("U");
        }
        
        if (Input.GetKeyDown(keyToPress2))
        {
            RecordInput("D");
        }

        // If no input for longer than the threshold, print and reset the sequence
        if (Time.time - lastInputTime > inputTimeThreshold && inputSequence.Length > 0)
        {
            Debug.Log("Input sequence: " + inputSequence);
            inputSequence = "";
        }
    }

    void RecordInput(string input)
    {
        inputSequence += input;
        lastInputTime = Time.time;
        Debug.Log("Current input sequence: " + inputSequence);
    }

    // Method to access the input sequence from other scripts
    public string GetInputSequence()
    {
        return inputSequence;
    }
}