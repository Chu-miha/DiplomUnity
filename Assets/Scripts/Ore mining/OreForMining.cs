using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreForMining : MonoBehaviour
{
    [SerializeField] private GameObject oreFragment; 
    [SerializeField] private int hitsRemaining;
    [SerializeField] private int countOre;

    public void HitByPickaxe()
    {
        hitsRemaining--;

        if (hitsRemaining <= 0)
        {
            BreakIntoFragments();
        }
    }

    private void BreakIntoFragments()
    {
        for (int ore = 0; ore < countOre; ore++)
        {
            Vector3 fragmentPosition = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            Instantiate(oreFragment, fragmentPosition, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
