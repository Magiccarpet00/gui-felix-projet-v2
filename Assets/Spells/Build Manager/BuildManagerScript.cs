using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 

public class BuildManagerScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI texteTableau;

    public SpellScriptableObject[] buildOne;
    public SpellScriptableObject[] buildDeux;
    public SpellScriptableObject[] buildTrois;


    public List<int> spellCombinaisonList = new List<int>();
    public string spellCombinaison;
    public int spellCombinaisonPosition = -1;
    public string[,] correspondanceSpellCombinaison;
   

    void Start()
    {

        //GameObject coucou = Instantiate(GameObject prefab, transform.position, Quaternion.identity);
        //AreaEffect coucou2 = coucou.AddComponent<AreaEffect>();
      

        int digits = 4;
        int count = (int)Mathf.Pow(4, digits);

       correspondanceSpellCombinaison = new string[count,2];

        for (int i = 0; i < count; i++)
        {
            correspondanceSpellCombinaison[i,0] = ConvertToQuaternary(i, digits);
            correspondanceSpellCombinaison[i, 1] = ConvertToQuaternary(i, digits);
        }

        

        AfficherTableau();


    }

   

    // Update is called once per frame
    void Update()
    {
       
    }

    public string ConvertToQuaternary(int decimalNumber, int digits)
    {
        string quaternaryNumber = "";

        for (int i = 0; i < digits; i++)
        {
            int remainder = decimalNumber % 4;
            quaternaryNumber = remainder.ToString() + quaternaryNumber;
            decimalNumber /= 4;
        }

        return quaternaryNumber;
        
    }

    private void AfficherTableau()
    {
        string tableauString = "";

        // Parcourir le tableau et construire la chaîne de caractères
        for (int i = 0; i < correspondanceSpellCombinaison.GetLength(0); i++)
        {
            for (int j = 0; j < correspondanceSpellCombinaison.GetLength(1); j++)
            {
                tableauString += correspondanceSpellCombinaison[i, j];
            }
            tableauString += "\n"; // Aller à la ligne après chaque ligne du tableau
        }

        // Affecter la chaîne de caractères au texte de l'objet UI Text
        texteTableau.text = tableauString;

    }

    

   
}


