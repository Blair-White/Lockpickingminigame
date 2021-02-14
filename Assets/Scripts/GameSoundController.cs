using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundController : MonoBehaviour
{
    public static GameSoundController instance = null;
    public AudioSource audSrc;
    public AudioClip audBlip;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        audSrc.volume = .45f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayBlip()
    {
        audSrc.PlayOneShot(audBlip);
    }
}
