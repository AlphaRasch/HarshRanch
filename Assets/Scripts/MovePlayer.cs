using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 8f;
    private Vector2 moveVector;
    [SerializeField]
    private GameObject shotgun;
    private bool isShotgunActive = false;
    private int health = 100;

    public int Health { get => health; set => health = value; }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shotgun.SetActive(false);
    }

    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        transform.position += new Vector3(moveVector.x, moveVector.y, 0) * speed * Time.deltaTime;        
        if (isShotgunActive)
        {
            Vector2 direction = moveVector;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            angle *= -1f;
            shotgun.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
        }        
    }

    private void OnMouseDown()
    {
        if (!isShotgunActive)
        {
            isShotgunActive = true;
            shotgun.SetActive(true);
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            isShotgunActive = false;
            shotgun.SetActive(false);
        }
    }
}
