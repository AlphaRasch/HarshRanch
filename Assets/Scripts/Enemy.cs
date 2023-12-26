using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 5f;
    private int player_damage = 15;
    private int health = 20;
    private int self_damage = 10;
    private GameObject player;
    [SerializeField]
    private AudioClip wolfdead;
    [SerializeField]
    private GameObject wolfdead_audio;

    private void OnEnable()
    {
        StartCoroutine(Walking());
    }

    IEnumerator Walking()
    {
        while (true)
        {
            player = GameObject.FindGameObjectWithTag("Player") != null ? GameObject.FindGameObjectWithTag("Player") : null;
            if (player != null)
            {
                while (Vector2.Distance(player.transform.position, transform.position) > 3f && player is not null)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 2f * Time.deltaTime);
                    yield return new WaitForSeconds(0.5f * Time.deltaTime);


                }
                if (Vector2.Distance(player.transform.position, transform.position) <= 3f && player is not null && player.GetComponent<MovePlayer>().Health > 0)
                {
                    player.GetComponent<MovePlayer>().Health -= player_damage;
                }
                
            }
            
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (health > 0)
            {
                health -= self_damage;
            }
            if (health <= 0)
            {
                Instantiate(wolfdead_audio, transform.position, Quaternion.identity);
                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.Stop();
                Destroy(this.gameObject);

            }
        }
    }

    
}
