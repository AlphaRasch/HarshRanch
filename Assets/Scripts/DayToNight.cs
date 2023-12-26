using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class DayToNight : MonoBehaviour
{
    [SerializeField]
    private List<Color> day_to_night;

    private void Start()
    {
        StartCoroutine(TimeOfDay());
    }

    IEnumerator TimeOfDay()
    {
        Camera camera = Camera.main;
        int count = 0;        
        while (true)
        {
            camera.backgroundColor = day_to_night[count];
            count++;
            if (count == day_to_night.Count)
            {
                count = 0;
            }
            yield return new WaitForSeconds(90);
        } 
    }
}
