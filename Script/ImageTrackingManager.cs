using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTrackingManager : DefaultObserverEventHandler
{
    //harus di assign tiap kartu beda
    public GameObject CiLA;
    public string csvInput;

    //assign once
    public GameObject myTextBox;
    public Button showTextBox;
    public Button playFunFact;

    //private values
    private CiLAIntro2 myCilaScript;
    private TextBoxScript myTextBoxScript;

    // Start is called before the first frame update
    void Awake()
    {
        myCilaScript = CiLA.GetComponent<CiLAIntro2>();
        myTextBoxScript = myTextBox.GetComponent<TextBoxScript>();
    }

    // Update is called once per frame
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        myTextBoxScript.assignNewData(csvInput);
        showTextBox.gameObject.SetActive(true);
        playFunFact.gameObject.SetActive(true);
        showTextBox.GetComponent<Button>().onClick.AddListener(myTextBoxScript.ToggleOpenClose);
        playFunFact.GetComponent<Button>().onClick.AddListener(playFunFactButtonEvent);
    }
    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        myCilaScript.ForceClose();
        myTextBoxScript.ForceClose();
        showTextBox.GetComponent<Button>().onClick.RemoveAllListeners();
        playFunFact.GetComponent<Button>().onClick.RemoveAllListeners();
        showTextBox.gameObject.SetActive(false);
        playFunFact.gameObject.SetActive(false);
    }

    void playFunFactButtonEvent()
    {
        myCilaScript.PlayFunFact();
        playFunFact.GetComponent<Button>().onClick.RemoveAllListeners();
        playFunFact.gameObject.SetActive(false);
    }

}
