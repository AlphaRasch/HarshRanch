using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> shotpointsList = new List<GameObject>();
    [SerializeField]
    private GameObject bullet;

    private void OnEnable()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        int i = 0;
        while (true)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject shoot_bullet = Instantiate(bullet, shotpointsList[i].transform.position, shotpointsList[i].transform.rotation);
                shoot_bullet.GetComponent<Rigidbody2D>().velocity = shotpointsList[i].transform.up * 15f;
                gameObject.GetComponent<AudioSource>().Play();  
                yield return new WaitForSeconds(1f);
                i++;
            }
            if (i == 2)
            {
                i = 0;
            }
            yield return null;
        }
    }
}
