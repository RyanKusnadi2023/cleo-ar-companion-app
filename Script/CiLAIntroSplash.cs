using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CiLAIntroSplash : MonoBehaviour
{
    private Animator myAnimator;
    private AudioSource myAudioSource;
    public AudioClip funFactClip;
    public bool test;


    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (test)
        {
            test = false;
            PlayFunFact();
        }
    }

    public void PlayFunFact()
    {
        StartCoroutine(FunFactSequence());
    }

    public void ForceClose()
    {
        StartCoroutine(ForceCloseCoroutine());
    }

    IEnumerator ForceCloseCoroutine()
    {
        myAudioSource.Stop();
        transform.localScale = new Vector3(0, 0, 0);
        yield return null;
    }

    IEnumerator FunFactSequence()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        myAnimator.SetBool("Do_Spin_Grow", true);
        transform.localScale = new Vector3(2, 2, 2);
        yield return new WaitForSeconds(3.5f);
        myAnimator.SetBool("Do_Wave_Simple", true);
        yield return new WaitForSeconds(2.5f);
        myAudioSource.PlayOneShot(funFactClip, 1f);
        while (myAudioSource.isPlaying)
        {
            myAnimator.SetBool("Do_Huh", true);
            yield return new WaitForSeconds(3.1f);
        }
        myAnimator.SetBool("Do_Wave_Simple", true);
        yield return new WaitForSeconds(2f);
        myAnimator.SetBool("Do_Spin_Shrink", true);
        yield return new WaitForSeconds(1.8f);
        transform.localScale = new Vector3(0, 0, 0);
    }

    IEnumerator Shrink(GameObject target)
    {
        Vector3 scaler = new Vector3(0.05f * target.transform.localScale.x, 0.05f * target.transform.localScale.y, 0.05f * target.transform.localScale.z);
        while (target.transform.localScale.x > 0)
        {
            target.transform.localScale -= scaler;
        }
        yield return null;
    }

    IEnumerator Expand(GameObject target, float maxSize)
    {
        Vector3 scaler = new Vector3(0.05f * target.transform.localScale.x, 0.05f * target.transform.localScale.y, 0.05f * target.transform.localScale.z);
        while (target.transform.localScale.x < maxSize)
        {
            target.transform.localScale += scaler;
        }
        yield return null;
    }
    public void StartSequence()
    {
        test = true;
    }
}
