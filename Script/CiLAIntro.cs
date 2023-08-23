using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiLAIntro : MonoBehaviour
{
    // Start is called before the first frame update
    
    //components
    private Animator myAnimator;
    private AudioSource myAudioSource;

    //booleans
    private bool alreadySpin;
    private bool alreadyWave2;
    private bool alreadyWave;
    private bool alreadyPlayedAudio;

    //parameters set by developer
    public float scaleLimit;
    public AudioClip funFactClip;
    public GameObject thruster;

    //input
    public bool close = true;

    //utility
    private Vector3 shrinkSpeed;
    private float time = 0;


    void Start()
    {
        time = 0;
        close = true;
        alreadySpin = false;
        alreadyPlayedAudio = false;
        alreadyWave2 = false;
        alreadyWave = false;

        myAnimator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
        shrinkSpeed = new Vector3(0.01f*scaleLimit, 0.01f * scaleLimit, 0.01f * scaleLimit);
        transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //time and bool reset, DO NOT TOUCH
        time += Time.deltaTime;
        if(close)
        {
            time = 0;
            alreadyWave = false;
            alreadyWave2 = false;
            alreadyPlayedAudio = false;
            alreadySpin = false;
        }
        
        //intro
        if (!alreadySpin)
        {
            myAnimator.SetBool("Do_Spin", true);
            alreadySpin = true;
        }
        if(time > 0.5 && !close && transform.localScale.x < scaleLimit)
        {
            gameObject.transform.localScale += shrinkSpeed;
        }

        //wave
        if(time > 0.5 + 2.4 && !alreadyWave)
        {
            myAnimator.SetBool("Do_Wave_Simple", true);
            alreadyWave = true;
        }

        //bacot
        if (!alreadyPlayedAudio && time > 4.5)
        {
            myAnimator.SetBool("Do_Huh", true);
            myAudioSource.PlayOneShot(funFactClip, 1f);
            alreadyPlayedAudio = true;
        }

        if (time > 4.5 + funFactClip.length && !alreadyWave2)
        {
            myAnimator.SetBool("Do_Wave_Simple", true);
            alreadyWave2 = true;
        }

        //cek dh selesai bacot?
        if(time > 6 + funFactClip.length)
        {
            close = true;
        }

        //outro
        if (close && alreadySpin)
        {
            alreadySpin = false;
        }

        if (close && transform.localScale.x > 0)
        {
            gameObject.transform.localScale -= shrinkSpeed;
        }
        thruster.SetActive(!close);
    }

    public void PlayFunFact()
    {
        close = false;
    }
    public void Reset()
    {
        time = 0;
        close = true;
        alreadySpin = false;
        alreadyPlayedAudio = false;
        alreadyWave2 = false;
        alreadyWave = false;
        shrinkSpeed = new Vector3(0.01f * scaleLimit, 0.01f * scaleLimit, 0.01f * scaleLimit);
        transform.localScale = new Vector3(0, 0, 0);
    }
}
