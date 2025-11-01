using System;
using UnityEngine;

public class MusiqueManager : MonoBehaviour
{
    [SerializeField]private AudioSource MusicSource;
    [SerializeField] private float BPM = 90.80f;

    private float beatInterval;
    private float nextBeatTime;
    
    public static event Action OnBeat;

    void Start()
    {
        InitMusic();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfItTimeForTheNxtBeat();
    }


    void InitMusic() 
    {
        beatInterval = 60f / BPM;
        nextBeatTime = MusicSource.time + beatInterval;
        MusicSource.Play();

    }

    // Check if it's time for the next beat
    void CheckIfItTimeForTheNxtBeat()
    {
        if (MusicSource.isPlaying && MusicSource.time > nextBeatTime)
        {
            Debug.Log("Beat Triggered at time: " + MusicSource.time);
            OnBeat?.Invoke();
            nextBeatTime += beatInterval;
        }
    }
}
