using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


//https://www.youtube.com/watch?v=EHKrMWGEZPU

public class Audiofiles : MonoBehaviour
{
    [Header("List of Songs")]
    [SerializeField] private Track[] audioTracks;

    private int songIndex;

    [Header("Text UI")]
    [SerializeField] private Text songTextUI;

    private AudioSource song;

    protected int counter = 0; //stores the amount of enemies defeated
    protected int c = 1;       //stores maximum number of songs that can be played

    private void Start()
    {
        song = GetComponent<AudioSource>();

        songIndex = 0;
        updateSong(songIndex);
    }

    public void switchTrack()
    {
        counter++;
        enableMoreSongs();
    }

    public void enableMoreSongs()
    {
        if(counter == 1)
        {
            //make skipForward and backwards Buttons appear
            if (GUI.Button(new Rect(50, 50, 37.27551, -263), "different station"))
            {
                skipForwardButton();
            }
            if (GUI.Button(new Rect(20, 20, 111.8235, -263), "different station"))
            {
                skipBackButton();
            
            }
            //make buttons appear
            //allow second song in List to play
        }
        else
        {
            c++;
        }
        
    }

    public void skipForwardButton()
    {
        if (songIndex < audioTracks.Length - 1)
        {
            if(songIndex < c)
            {
                songIndex++;
                updateSong(songIndex);
            }
            
        }
    }

    public void skipBackButton()
    {
        if (songIndex >= 1)
        {
            if(songIndex > c)
            {
                songIndex--;
                updateSong(songIndex);
            }
            
        }
    }

    void updateSong(int index)
    {
        song.clip = audioTracks[index].trackAudioClip;
        songTextUI.text = audioTracks[index].name;
    }

    public void audiovolume(float volume)
    {
        song.volume = volume;
    }

    public void playAudio()
    {
        song.Play();
    }

    public void pauseAudio()
    {
        song.Pause();
    }

    public void stopAudio()
    {
        song.Stop();
    }
}