using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToMinigame : DefaultObserverEventHandler
{
    // Start is called before the first frame update
    public int sceneId;
    protected override void OnTrackingFound()
    {
        StartCoroutine(MainScene());
    }

    IEnumerator MainScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneId);
        yield break;
    }
}
