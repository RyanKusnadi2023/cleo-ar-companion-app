using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string CSVInput;
    private bool openStatus = false;

    public TextMeshProUGUI Nama;
    public TextMeshProUGUI Konfigurasi;
    public TextMeshProUGUI NoAtom;
    public TextMeshProUGUI Periode;
    public TextMeshProUGUI Golongan;
    public TextMeshProUGUI MassaAtom;
    public TextMeshProUGUI Simbol;

    void Start()
    {
        string[] temp = CSVInput.Split(",");
        Nama.text = temp[0];
        NoAtom.text = temp[1];
        Simbol.text = temp[2];
        MassaAtom.text = temp[3];
        Periode.text = temp[4];
        Golongan.text = temp[5];
        Konfigurasi.text = temp[6];
        openStatus = false;
    }

    public void assignNewData(string csvInput2)
    {
        string[] temp = CSVInput.Split(",");
        Nama.text = temp[0];
        NoAtom.text = temp[1];
        Simbol.text = temp[2];
        MassaAtom.text = temp[3];
        Periode.text = temp[4];
        Golongan.text = temp[5];
        Konfigurasi.text = temp[6];
        openStatus = false;
    }

    public void ToggleOpenClose()
    {
        if(openStatus == false)
        {
            StartCoroutine(Expand());
            openStatus = true;
        }
        else 
        {
            StartCoroutine(Shrink());
            openStatus=false;
        }
    }

    public void ForceClose()
    {
        StartCoroutine(Shrink());
    }


    IEnumerator Shrink()
    {
        Vector3 scaler = new Vector3(0.001f, 0.001f, 0.001f);
        while (transform.localScale.x > 0)
        {
            transform.localScale -= scaler;
        }
        yield return null;
    }

    IEnumerator Expand()
    {
        Vector3 scaler = new Vector3(0.001f, 0.001f, 0.001f);
        while (transform.localScale.x < 1)
        {
            transform.localScale += scaler;
        }
        yield return null;
    }
}
