using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Camera cam;
    public GameObject[] prefabElements;
    public GameObject prefabPlayer;
    public GameObject prefabEnemmy;
    public GameObject prefabSpell;
    public bool isCastingMegaSpell = false;


    public SpellScriptableObject[] spellBuildActif;

    public SpellScriptableObject[] buildOne;
    public SpellScriptableObject[] buildDeux;
    public SpellScriptableObject[] buildTrois;

    public GameObject newSpell;

    public DammageEffectScript dammageEffectScript;
    public SlowEffectScript slowEffectScript;
    public BlinkEffectScript blinkEffectScript;
    public DotEffectScript dotEffectScript;
    public HotEffectScript hotEffectScript;


    private void Awake()
    {
        instance = this;
    }

    public Vector3 GetMousePosWorld(Transform transform)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 mousePos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        return mousePos;
    }

    public Vector3 GetMousePosLocal(Transform transform)
    {
        Vector3 mousePosWorld = GetMousePosWorld(transform);

        // Étape 1 : Inversion de la translation
        Vector3 vectorLocalNonTranslate = mousePosWorld - transform.position;

         //Étape 2 : Inversion de la rotation
        Quaternion rotationInverse = Quaternion.Inverse(transform.rotation);
        Vector3 vectorLocalNonRotate = rotationInverse * vectorLocalNonTranslate;

         //Étape 3 : Inversion de l'échelle
        Vector3 vectorLocalFinal = new Vector3(
            vectorLocalNonRotate.x / transform.localScale.x,
            vectorLocalNonRotate.y / transform.localScale.y,
            vectorLocalNonRotate.z / transform.localScale.z);

        return vectorLocalFinal; 
    }

    public Vector3 InterpolatePoints(Vector3 start, Vector3 end, float f)
    {
        float x = start.x + f * (end.x - start.x);
        float z = start.z + f * (end.z - start.z);

        Vector3 interpolateVector = new Vector3(x,1f,z);

        return interpolateVector;


    }

    public void InstantiateNewSpell(Transform transform)
    {
        newSpell = Instantiate(prefabSpell, transform.position, Quaternion.identity);

    }



}
