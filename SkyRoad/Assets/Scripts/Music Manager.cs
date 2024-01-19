using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]private SerializedDictionary<string, AudioSource> _audioSources;

    public static MusicManager Music;

    private void Awake()
    {
        Music = this;
    }

    public void ActivateGameMusic(bool isActive)
    {
        if (!Music._audioSources.ContainsKey("Menu Music")) return;
        
        ApplicationData.AppData.IsOnGameSound = isActive;
        var gameVolume = isActive ? 1 : 0;
        Music._audioSources["Menu Music"].gameObject.SetActive(isActive);
        
        if(!ApplicationData.AppData.IsPlayMenuMusic)
            Music._audioSources["Menu Music"].Stop();
        
        Music._audioSources["Game Music"].gameObject.SetActive(isActive);
        
        if(!ApplicationData.AppData.IsPlayGameMusic)
            Music._audioSources["Game Music"].Stop();
        
        Music._audioSources["Menu Music"].volume = gameVolume;
        Music._audioSources["Game Music"].volume = gameVolume;
    }
    
    public void ActivateMusicEffects(bool isActive)
    {
        ApplicationData.AppData.IsOnMusicEffects = isActive;
        var gameVolume = isActive ? 1 : 0;

        foreach (var audio in Music._audioSources.Where(audio =>
                     audio.Key is "Buttons Music" or "Burn Music" or "Speed Music" or "Win Music"))
        {
            audio.Value.gameObject.SetActive(isActive);
            audio.Value.Stop();
            audio.Value.volume = gameVolume;
        }
    }

    public void PlaySound(string soundName, bool isOn)
    {
        if (!Music._audioSources.ContainsKey(soundName)) return;
        
        switch (soundName)
        {
            case "Menu Music":
                ApplicationData.AppData.IsPlayMenuMusic = isOn;
                break;
            case "Game Music":
                ApplicationData.AppData.IsPlayGameMusic = isOn;
                break;
            default:
                break;
        }
        
        Music._audioSources[soundName].gameObject.SetActive(isOn);
        Music._audioSources[soundName].Play();
    }
}
