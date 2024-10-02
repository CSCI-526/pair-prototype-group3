using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmController : MonoBehaviour
{
    public GameObject arrowPrefab;
    public AudioSource audioSource;
    public int numberOfBeats;
    public AudioClip targetClip;
    public Vector3 spawnPosition;
    private float bpm;

    void Start()
    {
        
        bpm = UniBpmAnalyzer.AnalyzeBpm(targetClip);

        // check if the BPM is valid
        if (bpm <= 0)
        {
            Debug.LogError("Invalid BPM detected. Check the audio clip.");
            return;
        }

        Debug.Log("BPM is " + bpm);

        
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

       
        StartCoroutine(SpawnArrows());
    }

    IEnumerator SpawnArrows()
    {
        float beatInterval = 60f / bpm;

        for (int i = 0; i < numberOfBeats; i++)
        {
            float spawnTime = i * beatInterval;
            float delay = spawnTime - audioSource.time;

            if (delay > 0)
            {
                yield return new WaitForSeconds(delay);
            }

            
            SpawnArrow();
        }
    }

    void SpawnArrow()
    {
        Instantiate(arrowPrefab, spawnPosition, Quaternion.identity);
    }
}

