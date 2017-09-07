using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkeScript : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(DeActivate());
    }
    IEnumerator DeActivate()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

}
