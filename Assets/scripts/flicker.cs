using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour
{
    public bool isFlickering;

    public float delay;
    public Light myLight;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (isFlickering == true)
        {
            StartCoroutine(Flicker());
            myLight = GetComponent<Light>();
        }
        
    }

    IEnumerator Flicker()
    {
        //isFlickering = false;
        myLight.intensity = 16;
        delay = Random.Range(1.0f, 1.80f);
        yield return new WaitForSeconds(delay);
        myLight.intensity = 37;
        delay = Random.Range(1.50f, 3.0f);
        yield return new WaitForSeconds(delay);
        myLight.intensity = 0;
        delay = Random.Range(10.0f, 15.50f);
        yield return new WaitForSeconds(delay);
        myLight.intensity = 50;
    }
}
