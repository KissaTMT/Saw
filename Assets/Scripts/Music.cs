using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicState
{
    Play,
    Pause
}
public class Music : MonoBehaviour
{
    public static Music instance;
    [SerializeField] private List<AudioClip> _clips;
    private MusicState _musicState;
    private AudioSource _audioSource;
    private int _currentTrackIndex;

    public void InverseMusicState()
    {
        if (_musicState == MusicState.Play) Stop();
        else Play();
    }
    public void Play()
    {
        _audioSource.Play();
        _musicState = MusicState.Play;
    }
    public void Stop()
    {
        _audioSource.Pause();
        _musicState = MusicState.Pause;
    }
    private void Awake()
    {
        instance = this;
        _audioSource = GetComponent<AudioSource>();
        _currentTrackIndex = Random.Range(0, _clips.Count);
        _audioSource.clip = _clips[_currentTrackIndex];
        Play();
        StartCoroutine(CheckAndCrossfade());
    }
    private IEnumerator CheckAndCrossfade()
    {
        while (true)
        {
            float timeUntilSwitch = (_audioSource.clip.length / _audioSource.pitch) - _audioSource.time;
            if (timeUntilSwitch < 0) timeUntilSwitch = 0;
            yield return new WaitForSeconds(timeUntilSwitch);

            int nextTrackIndex = (_currentTrackIndex + 1) % _clips.Count;
            _audioSource.clip = _clips[nextTrackIndex];
            Play();

            _currentTrackIndex = nextTrackIndex;
        }
    }
}
