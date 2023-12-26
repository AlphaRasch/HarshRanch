using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> seeds = new List<Sprite>();
    private bool isEmpty = true;
    private bool isPlantReady = false;
    private int number_plant;
    SpriteRenderer renderer = new SpriteRenderer();
    [SerializeField]
    private GameObject seed_pos;
    private GameObject storage;

    private void Start()
    {       
        renderer = seed_pos.GetComponent<SpriteRenderer>();
        storage = GameObject.FindGameObjectWithTag("Storage");
    }

    private void OnMouseOver()
    {        
        if (Input.GetMouseButtonDown(0) && transform.GetComponentInParent<Patche>().IsNear && isEmpty && storage.GetComponent<Storage>().Available_seeds[0] > 0)
        {
            StartCoroutine(Planting(0, 5f));
        }
        if (Input.GetMouseButtonDown(1) && transform.GetComponentInParent<Patche>().IsNear && isEmpty && storage.GetComponent<Storage>().Available_seeds[1] > 0)
        {
            StartCoroutine(Planting(1, 5f));
        }
        if (Input.GetMouseButtonDown(2) && transform.GetComponentInParent<Patche>().IsNear && isEmpty && storage.GetComponent<Storage>().Available_seeds[2] > 0)
        {
            StartCoroutine(Planting(2, 5f));
        }
        if(Input.GetMouseButtonDown(0) && isPlantReady)
        {
            SetDefault();
        }
    }

    IEnumerator Planting(int number_seed, float time_to_grow)
    {
        isEmpty = false;        
        storage.GetComponent<Storage>().Available_seeds[number_seed] -= 1;
        Debug.Log(number_seed + " planting");
        yield return new WaitForSeconds(time_to_grow);
        renderer.sprite = seeds[number_seed];
        seed_pos.transform.localScale = new Vector3(0.16f, 0.16f, 1);
        isPlantReady = true;
        number_plant = number_seed;
    }

    private void SetDefault()
    {
        renderer.sprite = null;
        isEmpty = true;
        isPlantReady = false;       
        storage.GetComponent<Storage>().Available_plants[number_plant] += 1;
    }

    

}
