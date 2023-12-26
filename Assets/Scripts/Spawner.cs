using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> points;
    [SerializeField]
    private GameObject enemy;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        int i = 0;
        yield return new WaitForSeconds(30f);
        while (true)
        {
            Instantiate(enemy, points[i].position, Quaternion.identity);
            i++;
            if (i == points.Count)
            {
                i = 0;
            }
            yield return new WaitForSeconds(15f);
        }
    }
}
