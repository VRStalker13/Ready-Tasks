using System;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private AudioClip _gameMusic;
    [SerializeField] private AudioClip _buttonsMusic;
    [SerializeField] private AudioClip _burnMusic;
    [SerializeField] private AudioClip _speedMusic;
    [SerializeField] private AudioClip _winMusic;
    
    [SerializeField] private AudioSource _menuMusicPlayer;
    [SerializeField] private AudioSource _gameMusicPlayer;
    [SerializeField] private AudioSource _buttonsMusicPlayer;
    [SerializeField] private AudioSource _burnMusicPlayer;
    [SerializeField] private AudioSource _speedMusicPlayer;
    [SerializeField] private AudioSource _winMusicPlayer;

    public static GameMusic Music;

    private void Awake()
    {
        Music = this;
    }

    public void ActivateGameMusic(bool isActive)
    {
        ApplicationData.AppData._isOnGameSound = isActive;
        var gameVolume = isActive ? 1 : 0;
        _menuMusicPlayer.gameObject.SetActive(isActive);
        
        if(!ApplicationData.AppData.IsPlayMenuMusic)
            _menuMusicPlayer.Stop();
        
        _gameMusicPlayer.gameObject.SetActive(isActive);
        
        if(!ApplicationData.AppData.IsPlayGameMusic)
            _gameMusicPlayer.Stop();
        
        _menuMusicPlayer.volume = gameVolume;
        _gameMusicPlayer.volume = gameVolume;
    }
    
    public void ActivateMusicEffects(bool isActive)
    {
        ApplicationData.AppData._isOnMusicEffects = isActive;
        var gameVolume = isActive ? 1 : 0;
        _buttonsMusicPlayer.gameObject.SetActive(isActive);
        _buttonsMusicPlayer.Stop();
        _burnMusicPlayer.gameObject.SetActive(isActive);
        _burnMusicPlayer.Stop();
        _speedMusicPlayer.gameObject.SetActive(isActive);
        _speedMusicPlayer.Stop();
        _winMusicPlayer.gameObject.SetActive(isActive);
        _winMusicPlayer.Stop();
        _buttonsMusicPlayer.volume = gameVolume;
        _burnMusicPlayer.volume = gameVolume;
        _speedMusicPlayer.volume = gameVolume;
        _winMusicPlayer.volume = gameVolume;
    }

    public void PlayMenuMusic(bool isOn)
    {
        _menuMusicPlayer.gameObject.SetActive(isOn);
        ApplicationData.AppData.IsPlayMenuMusic = isOn;
        _menuMusicPlayer.clip = _menuMusic;
        _menuMusicPlayer.Play();
    }
    
    public void PlayGameMusic(bool isOn)
    {
        ApplicationData.AppData.IsPlayGameMusic = isOn;
        _gameMusicPlayer.gameObject.SetActive(isOn);
        _gameMusicPlayer.clip = _gameMusic;
        _gameMusicPlayer.Play();
    }
    
    public void PlayButtonsMusic(bool isOn)
    {
        _buttonsMusicPlayer.gameObject.SetActive(isOn);
        _buttonsMusicPlayer.clip = _buttonsMusic;
        _buttonsMusicPlayer.Play();
    }
    
    public void PlayBurnMusic()
    {
        _burnMusicPlayer.gameObject.SetActive(true);
        _burnMusicPlayer.clip = _burnMusic; 
        _burnMusicPlayer.Play();
    }
    
    public void PlaySpeedMusic(bool isPlay)
    {
        _speedMusicPlayer.gameObject.SetActive(isPlay);
        _speedMusicPlayer.clip = _speedMusic;
        _speedMusicPlayer.Play();
    }
    
    public void PlayWinMusic()
    {
        _winMusicPlayer.gameObject.SetActive(true);
        _winMusicPlayer.clip = _winMusic; 
        _winMusicPlayer.Play();
    }
}
