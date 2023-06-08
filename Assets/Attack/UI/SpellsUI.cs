using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsUI : MonoBehaviour
{
    public Button button1; 
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;

    public Image targetImage1;
    public Image targetImage2;
    public Image targetImage3;
    public Image targetImage4;
    public Image targetImage5;



    // Start is called before the first frame update
    void Start()
    {
            Image buttonImage1= button1.GetComponent<Image>();
            Sprite sprite1 = buttonImage1.sprite;
            targetImage1.sprite = sprite1;

            Image buttonImage2 = button2.GetComponent<Image>();
            Sprite sprite2 = buttonImage2.sprite;
            targetImage2.sprite = sprite2;

            Image buttonImage3 = button3.GetComponent<Image>();
            Sprite sprite3 = buttonImage3.sprite;
            targetImage3.sprite = sprite3;

            Image buttonImage4 = button4.GetComponent<Image>();
            Sprite sprite4 = buttonImage4.sprite;
            targetImage4.sprite = sprite4;

            Image buttonImage5 = button5.GetComponent<Image>();
            Sprite sprite5 = buttonImage5.sprite;
            targetImage5.sprite = sprite5;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
