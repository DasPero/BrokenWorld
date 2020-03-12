using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

	public Sound[] sounds;

	public static AudioManager current;
	public int currentSong;

	void Awake()
	{

		if (current == null)
		{
			current = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	public void Play(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.Play();
	}

	public void Pause(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.Pause();
	}

	public void Stop(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.Stop();
	}

	public void PlayOnce(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.PlayOneShot(s.source.clip, s.source.volume);
	}

	public AudioClip GetClip(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return null;
		}
		else
		{
			return s.source.clip;
		}
	}

	public AudioSource GetSource(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return null;
		}
		else
		{
			return s.source;
		}
	}

	public void StopAllSounds()
	{
		foreach (Sound s in sounds)
		{
			s.source.Stop();
		}
	}

	void Start()
	{
		Play("menu");
	}

	public void MusicVolume(float value)
	{
		Sound s = Array.Find(sounds, sound => sound.name == "menu");
		s.source.volume = value;

		s = Array.Find(sounds, sound => sound.name == "ingame");
		s.source.volume = value;
	}

	public void EffectVolume(float value)
	{
		Sound s = Array.Find(sounds, sound => sound.name == "button_click");
		s.source.volume = value;

		s = Array.Find(sounds, sound => sound.name == "button_hover");
		s.source.volume = value;

		s = Array.Find(sounds, sound => sound.name == "jump");
		s.source.volume = value;

		s = Array.Find(sounds, sound => sound.name == "death");
		s.source.volume = value;
	}

	public float GetMusicVolume()
	{
		Sound s = Array.Find(sounds, sound => sound.name == "menu");
		return s.source.volume;
	}

	public float GetEffectVolume()
	{
		Sound s = Array.Find(sounds, sound => sound.name == "button_click");
		return s.source.volume;
	}
}
