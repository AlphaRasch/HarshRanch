using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patche : MonoBehaviour
{
    private GameObject Player;
    private bool isNear = false;
    public bool IsNear { get { return isNear; } }
    [SerializeField]
    private Sprite sprite_select;
    [SerializeField]
    private Sprite sprite_based;    
    private void OnEnable()
    {
        StartCoroutine(FindPlayer());
    }

    IEnumerator FindPlayer()
    {
        while (true)
        {
            Player = GameObject.FindGameObjectWithTag("Player") != null ? GameObject.FindGameObjectWithTag("Player") : null;
            if (Player != null)
            {
                if (Vector3.Distance(this.transform.position, Player.transform.position) < 5f && Player is not null)
                {
                    isNear = true;
                }
                else
                {
                    isNear = false;
                    SpriteRenderer renderer = GetComponent<SpriteRenderer>();
                    renderer.sprite = sprite_based;
                }
            }
            yield return null;
        }
    }

    void OnMouseOver()
    {
        if (isNear)
        {           
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = sprite_select;
        }
        
    }
    private void OnMouseExit()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprite_based;
    }
}
