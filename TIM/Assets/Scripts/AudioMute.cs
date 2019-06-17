using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMute : MonoBehaviour {
    public Slider vol;
    public AudioSource a;
    public Button mute;
    public AudioSource click;
	// Update is called once per frame
	void Update () {
        a.volume = vol.value;
        DontDestroyOnLoad(transform.gameObject);
    }
    public void clickOnButton()
    {
        click.Play();
    }
}
