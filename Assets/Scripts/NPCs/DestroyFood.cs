using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFood : MonoBehaviour
{
    private float secondsInScene = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(secondsInScene);
        Destroy(gameObject);
    }

}
