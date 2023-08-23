using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpScript : DefaultObserverEventHandler
{
    private bool openStatus = false;
    public GameObject popupwindow;
    public int sceneId;
    protected override void OnTrackingFound()
    {
        StartCoroutine(Expand(popupwindow));
    }
    protected override void OnTrackingLost()
    {
        StartCoroutine(Shrink(popupwindow));
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneId);
    }
    public void ToggleOpenClose()
    {
        if (openStatus == false)
        {
            StartCoroutine(Expand(popupwindow));
            openStatus = true;
        }
        else
        {
            StartCoroutine(Shrink(popupwindow));
            openStatus = false;
        }
    }

    public void ForceClose()
    {
        StartCoroutine(Shrink(popupwindow));
    }


    IEnumerator Shrink(GameObject temp)
    {
        Vector3 scaler = new Vector3(0.001f, 0.001f, 0.001f);
        while (temp.transform.localScale.x > 0)
        {
            temp.transform.localScale -= scaler;
        }
        yield return null;
    }

    IEnumerator Expand(GameObject temp)
    {
        Vector3 scaler = new Vector3(0.001f, 0.001f, 0.001f);
        while (temp.transform.localScale.x < 0.2)
        {
            temp.transform.localScale += scaler;
        }
        yield return null;
    }
}
