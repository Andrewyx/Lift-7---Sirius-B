using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 mousePos;
    private Rigidbody2D rb;
    public float force;

    public GameObject enemyHitSound;
    public float regularBulletDamage = 1;

    private Vector2 screenBounds; //To delete offscreen bullets

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector3(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); //track screensize
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            Instantiate(enemyHitSound, transform.position, Quaternion.identity);
            enemyComponent.TakeDamage(regularBulletDamage);
            CinemachineShake.Instance.ShakeCameraSharp(2f, 0.1f);
        }
        Destroy(gameObject);
    }


    void Update()
    {
        if (transform.position.x < (-100f) || transform.position.x > 100f)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.y < (-100f) || transform.position.y > 100f)
        {
            Destroy(this.gameObject);
        }
    }

}
