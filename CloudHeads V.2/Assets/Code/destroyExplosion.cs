using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("destroyME");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator destroyME()
    {
        yield return new WaitForSeconds(.15f);
        Destroy(this.gameObject);
    }
}
