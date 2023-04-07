using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCanOBeans : MonoBehaviour
{
    public GameObject beanz;
    void Start()
    {
        StartCoroutine(SpawnBean());
    }

    IEnumerator SpawnBean()
    {
        while(true){
            GameObject daBeanz = Instantiate(beanz, transform);
            daBeanz.transform.position += new Vector3(0, 3.51f, 0);
            yield return new WaitForSeconds(10);
        }
    }
}
