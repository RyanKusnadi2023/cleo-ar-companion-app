using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    //props
    public GameObject redBall;
    public GameObject blueBall;
    public GameObject electronPath;
    public GameObject CiLAIntroduction;

    //data
    public int redBallSlide;
    public int blueBallSlide;
    public int electronPathSlide;
    public int cilaIntroSlide;

    //containers
    public GameObject nextButtonObject;
    public GameObject skipButtonObject;
    public List<Texture> splashScreens = new List<Texture>();

    //private values and references
    private Button nextButton;
    private Button skipButton;
    private RawImage myRawImage;
    
    private int index = 0;
    private int lengthOfList;
    // Start is called before the first frame update
    void Start()
    {
        lengthOfList = splashScreens.Count;
        myRawImage = nextButtonObject.GetComponent<RawImage>();
        nextButton = nextButtonObject.GetComponent<Button>();
        skipButton = skipButtonObject.GetComponent<Button>();

        myRawImage.texture = splashScreens[0];

        nextButton.onClick.AddListener(nextButtonPressed);
        skipButton.onClick.AddListener(skipButtonPressed);
    }

    // Update is called once per frame

    void nextButtonPressed()
    {
        if (index < lengthOfList-1)
        {
            myRawImage.texture = splashScreens[index];
            if(index == redBallSlide)
            {
                redBall.SetActive(true);
            }
            if(index == blueBallSlide)
            {
                blueBall.SetActive(true);
            }
            if(index == electronPathSlide)
            {
                electronPath.SetActive(true);
            }
            if(index == cilaIntroSlide)
            {

            }
            else
            {
                redBall.SetActive(false);
                blueBall.SetActive(false);
                electronPath.SetActive(false);
            }
            index++;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void skipButtonPressed()
    {
        Destroy(gameObject);
    }

    private IEnumerator FadingOut(float duration = 1f)
    {
        Color start = new Color(0, 0, 0, 0);
        Color end = new Color(0, 0, 0, 1);
        float t = 0f;
        while (t < duration)
        {
            myRawImage.color = Color.Lerp(start, end, t / duration);
            t += Time.deltaTime;
            yield return null;
        }
    }
}
