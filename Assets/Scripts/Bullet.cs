using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float time_to_destroy = 5f;
    private float speed = 15f;

    private void OnEnable()
    {
        StartCoroutine(DestroyBullet());
    }
    
    IEnumerator DestroyBullet()
    {        
        
        yield return new WaitForSeconds(time_to_destroy);
        Destroy(this.gameObject);
    }
}
