using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chikens : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI eggs;
    [SerializeField]
    private TextMeshProUGUI feed;
    [SerializeField]
    private Canvas chiken_panel;

    private int count_egg = 0;
    private int count_feed = 0;
    private bool isChikenPanelActive = false;

    private void Start()
    {
        chiken_panel.enabled = false;
        StartCoroutine(CreateEggs(3f, 5));
    }

   
    private void OnMouseDown()
    {
        if (!isChikenPanelActive)
        {
            isChikenPanelActive = true;
            chiken_panel.enabled = true;
        }
        else
        {
            isChikenPanelActive = false;
            chiken_panel.enabled = false;
        }
    }

    IEnumerator CreateEggs(float time_create_egg, int max_count_egg_iter)
    {
        while (true)
        {
            eggs.text = count_egg.ToString();
            feed.text = count_feed.ToString() + "/1";
            int count = max_count_egg_iter;
            if (count_feed > 0)
            {
                count_feed -= 1;
                feed.text = count_feed.ToString() + "/1";
                while (count > 0)
                {
                    count -= 1;
                    count_egg += 1;
                    eggs.text = count_egg.ToString();
                    yield return new WaitForSeconds(time_create_egg);
                }                
            }            
           yield return null;
        }
    }

    public void TakeEggs()
    {
        GameObject storage = GameObject.FindGameObjectWithTag("Storage");
        storage.GetComponent<Storage>().Eggs += count_egg;
        count_egg = 0;
    }

    public void GiveFeed()
    {
        GameObject storage = GameObject.FindGameObjectWithTag("Storage");
        count_feed += storage.GetComponent<Storage>().Birdfood;
        storage.GetComponent<Storage>().Birdfood = 0;
    }

   
}
