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

    [SerializeField] GameObject buildManager;
    public SpellScriptableObject[] spellBuildActif;
  




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void SetBuildUn()
    {
        spellBuildActif = buildManager.GetComponent<BuildManagerScript>().buildOne;

        Image buttonImage1 = button1.GetComponent<Image>();
        buttonImage1.sprite = spellBuildActif[0].spellIcon;
        Sprite sprite1 = buttonImage1.sprite;
        targetImage1.sprite = sprite1;

        Image buttonImage2 = button2.GetComponent<Image>();
        buttonImage2.sprite = spellBuildActif[1].spellIcon;
        Sprite sprite2 = buttonImage2.sprite;
        targetImage2.sprite = sprite2;

        Image buttonImage3 = button3.GetComponent<Image>();
        buttonImage3.sprite = spellBuildActif[2].spellIcon;
        Sprite sprite3 = buttonImage3.sprite;
        targetImage3.sprite = sprite3;

        Image buttonImage4 = button4.GetComponent<Image>();
        buttonImage4.sprite = spellBuildActif[3].spellIcon;
        Sprite sprite4 = buttonImage4.sprite;
        targetImage4.sprite = sprite4;

    }

    public void SetBuildDeux()
    {
        spellBuildActif = buildManager.GetComponent<BuildManagerScript>().buildDeux;

        Image buttonImage1 = button1.GetComponent<Image>();
        buttonImage1.sprite = spellBuildActif[0].spellIcon;
        Sprite sprite1 = buttonImage1.sprite;
        targetImage1.sprite = sprite1;

        Image buttonImage2 = button2.GetComponent<Image>();
        buttonImage2.sprite = spellBuildActif[1].spellIcon;
        Sprite sprite2 = buttonImage2.sprite;
        targetImage2.sprite = sprite2;

        Image buttonImage3 = button3.GetComponent<Image>();
        buttonImage3.sprite = spellBuildActif[2].spellIcon;
        Sprite sprite3 = buttonImage3.sprite;
        targetImage3.sprite = sprite3;

        Image buttonImage4 = button4.GetComponent<Image>();
        buttonImage4.sprite = spellBuildActif[3].spellIcon;
        Sprite sprite4 = buttonImage4.sprite;
        targetImage4.sprite = sprite4;

    }

    public void SetBuildTrois()
    {
        spellBuildActif = buildManager.GetComponent<BuildManagerScript>().buildTrois;

        Image buttonImage1 = button1.GetComponent<Image>();
        buttonImage1.sprite = spellBuildActif[0].spellIcon;
        Sprite sprite1 = buttonImage1.sprite;
        targetImage1.sprite = sprite1;

        Image buttonImage2 = button2.GetComponent<Image>();
        buttonImage2.sprite = spellBuildActif[1].spellIcon;
        Sprite sprite2 = buttonImage2.sprite;
        targetImage2.sprite = sprite2;

        Image buttonImage3 = button3.GetComponent<Image>();
        buttonImage3.sprite = spellBuildActif[2].spellIcon;
        Sprite sprite3 = buttonImage3.sprite;
        targetImage3.sprite = sprite3;

        Image buttonImage4 = button4.GetComponent<Image>();
        buttonImage4.sprite = spellBuildActif[3].spellIcon;
        Sprite sprite4 = buttonImage4.sprite;
        targetImage4.sprite = sprite4;

    }
}
