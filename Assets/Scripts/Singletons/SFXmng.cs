﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SFXmng : MonoBehaviour
{

	[SerializeField]
	private AudioClip SFX1 = null;
	[SerializeField]
	private AudioClip SFX2 = null;
	[SerializeField]
	private AudioClip SFX3 = null;
	[SerializeField]
	private AudioClip SFX4 = null;
	[SerializeField]
	private AudioClip SFX5 = null;
	[SerializeField]
	private AudioClip SFX6 = null;
	[SerializeField]
	private AudioClip SFX7 = null;
	[SerializeField]
	private AudioClip SFX8 = null;
	[SerializeField]
	private AudioClip SFX9 = null;
	[SerializeField]
	private AudioClip SFX10 = null;



	private List<AudioSource> sources = new List<AudioSource>();


	#region Game Object Singleton

	/// <summary>
	/// This manager's sole instance (singleton).
	/// </summary>
	private static SFXmng instance = null;

	// Static read-only property that makes MusicManager accessible throughout the code.
	public static SFXmng Instance
	{
		get { return instance; }
	}

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			GameObject.DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			GameObject.Destroy(this.gameObject);
		}
	}

	void Update()
	{

	}

	#endregion Game Object Singleton


	#region Play Methods

	public void PlaySFX1()
	{
		PlaySound(this.SFX1);
	}
	public void PlaySFX2()
	{
		PlaySound(this.SFX2);
	}
	public void PlaySFX3()
	{
		PlaySound(this.SFX3);
	}
	public void PlaySFX()
	{
		PlaySound(this.SFX4);
	}
	public void PlaySFX5()
	{
		PlaySound(this.SFX5);
	}
	public void PlaySFX6()
	{
		PlaySound(this.SFX6);
	}
	public void PlaySFX7()
	{
		PlaySound(this.SFX7);
	}
	public void PlaySFX8()
	{
		PlaySound(this.SFX8);
	}
	public void PlaySFX9()
	{
		PlaySound(this.SFX9);
	}
	public void PlaySFX10()
	{
		PlaySound(this.SFX10);
	}




	private void PlaySound(AudioClip clip)
	{
		// Grab an AudioSource to play this clip.
		AudioSource source = GetAudioSource();

		// Set the clip to play.
		source.clip = clip;

		// Play the clip.
		source.Play();
	}

	#endregion Play Methods


	#region Helpers

	/// <summary>
	/// Gets the audio source.
	/// </summary>
	/// <returns>The audio source.</returns>
	private AudioSource GetAudioSource()
	{
		// Try getting the AudioSource component attached to this game object.
		AudioSource source = this.gameObject.GetComponent<AudioSource>();

		// If an AudioSource component has not yet been added to this game object, add one to this game object
		// and to our list of AudioSources.
		if (source == null)
		{
			source = this.gameObject.AddComponent<AudioSource>();
			this.sources.Add(source);
		}

		return source;
	}


	// Maximum number of AudioSources allowed for this game object.
	// For use with GetAvailableSource().
	[SerializeField]
	private int maxAudioSourceCount = 10;

	/// <summary>
	/// More advanced version of GetAudioSource().
	/// Looks for an available AudioSource. An available AudioSource is one that is not playing an AudioClip.
	/// If no available AudioSources exist, it permanently creates a new AudioSource.
	/// </summary>
	/// <returns>The free source.</returns>
	private AudioSource GetAvailableSource()
	{
		// If the list of AudioSources has not been created yet, create it.
		if (this.sources == null)
		{
			this.sources = new List<AudioSource>();
		}

		// If there are no AudioSources created, add the first AudioSource.
		if (this.sources.Count == 0)
		{
			AudioSource firstSource = this.gameObject.AddComponent<AudioSource>();
			this.sources.Add(firstSource);
		}

		// Search for an available AudioSource, i.e. the AudioSource not playing an AudioClip.
		// If one is found, stop searching by simply returning it. 
		// Using the 'return' keyword inside a loop will end the loop, and exit this method.
		for (int i = 0; i < this.sources.Count; i++)
		{
			AudioSource source = this.sources[i];
			if (source.isPlaying == false)
			{
				return source;
			}
		}

		// If we got to this point, that means we did not find an available AudioSource.

		// If we have not reached our maximum number of AudioSources for this game object, then:
		// Add a new AudioSource component to this manager, save it in the list of sources, and return it.
		if (this.sources.Count < this.maxAudioSourceCount)
		{
			AudioSource newSource = this.gameObject.AddComponent<AudioSource>();
			this.sources.Add(newSource);
			return newSource;
		}

		// If we got to this point, that means we have reached our maximum allowed AudioSources.
		// We have no available AudioSources to return.
		return null;
	}

	#endregion Helpers
}
