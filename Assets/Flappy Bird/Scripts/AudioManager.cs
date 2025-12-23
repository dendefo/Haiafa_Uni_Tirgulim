using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager GetInstance()
    {
        if (!_instance)
        {
            var reference = Resources.Load<AudioManager>("AudioManager");
            var newObj = Instantiate(reference);
            return newObj;
        }
        return _instance;
    }

    [SerializeField] List<AudioSource> Sources;
    [SerializeField] AudioMixer AudioMixer;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFX(AudioResource resource)
    {
        var source = Sources.FirstOrDefault(Source => !Source.isPlaying);
        if (source)
        {
            source.resource = resource;
            source.Play();
        }
        else
        {
            Debug.LogError("No available audio source to play SFX: " + resource.name);
        }
    }

    public void SetSFXVolume(float volume)
    {
        AudioMixer.SetFloat("SFX_Volume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        AudioMixer.SetFloat("Music_Volume", volume);
    }

    public void SetMasterVolume(float volume)
    {
        AudioMixer.SetFloat("Master_Volume", volume);
    }


}
