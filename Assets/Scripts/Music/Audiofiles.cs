using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//https://www.youtube.com/watch?v=EHKrMWGEZPU

public class Audiofiles : MonoBehaviour
{
    [Header("List of Songs")]
    [SerializeField] private Track[] audioTracks;
    private int songIndex;

    [Header("Text UI")]
    [SerializeField] private Text songTextUI;


    private AudioSource song;

    private void Start()
    {
        song = GetComponent<AudioSource>();

        songIndex = 0;
        updateSong(songIndex);
    }

    public void skipForwardButton()
    {
        if (songIndex < audioTracks.Length - 1)
        {
            songIndex++;
            updateSong(songIndex);
        }
    }

    public void skipbackButton()
    {
        if (songIndex >= 1)
        {
            songIndex--;
            updateSong(songIndex);
        }
    }

    void updateSong(int index)
    {
        song.clip = audioTracks[index].trackAudioClip;
        songTextUI.text = audioTracks[index].name;
    }

    public void audiovolume(float volume){
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
