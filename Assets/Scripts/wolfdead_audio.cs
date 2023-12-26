using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfdead_audio : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DeadAudio());
    }

    IEnumerator DeadAudio()
    {

        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }
}
