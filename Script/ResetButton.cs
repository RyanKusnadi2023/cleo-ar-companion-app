using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ResetButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ARCamera;
    VuforiaBehaviour _VuforiaBehaviour;
    public GameObject buttonCiLA;
    public GameObject buttonTB;
    void Start()
    {
        _VuforiaBehaviour = ARCamera.GetComponent<VuforiaBehaviour>();
        gameObject.GetComponent<Button>().onClick.AddListener(resetARCamera);
    }

    private void resetARCamera()
    {
        _VuforiaBehaviour.enabled = false;
        _VuforiaBehaviour.enabled = true;
        buttonCiLA.GetComponent<Button>().onClick.RemoveAllListeners();
        buttonTB.GetComponent<Button>().onClick.RemoveAllListeners();
        buttonCiLA.SetActive(false);
        buttonTB.SetActive(false);
    }

}
