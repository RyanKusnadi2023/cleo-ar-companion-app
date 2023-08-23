using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CleanScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.UnloadScene(0);
        SceneManager.UnloadScene(2);
        SceneManager.UnloadScene(3);
        SceneManager.UnloadScene(4);
    }
}
