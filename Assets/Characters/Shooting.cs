using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    [SerializeField] private AudioSource ShootSoundEffect;
    [SerializeField] private GameObject chargedProjectile;
    [SerializeField] private float chargeSpeed;
    [SerializeField] private float chargeTime;
    public bool isCharging;

    private Rigidbody2D rb;
    public GameObject player;
    
    public float smallRecoilForce = 5;
    public float bigRecoilForce = 10;
    
    void Awake()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + 90);

        if (rotZ + 90 > 0 && rotZ + 90 < 180)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (rotZ + 90 < 0 && rotZ + 90 > -180)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }


        if(Input.GetMouseButton(0) && chargeTime < 2f && canFire)
        {
            isCharging = true;
            if(isCharging == true)
            {
                chargeTime += Time.deltaTime * chargeSpeed;
            }
        }

        else if(Input.GetMouseButton(0) && chargeTime >= 2f && canFire)
        {
            canFire = false;
            ReleaseCharge();
            rb.AddForce(rotation.normalized * -bigRecoilForce, ForceMode2D.Impulse);

            
        }        

        else if (Input.GetMouseButtonUp(0) && canFire)
        {
            canFire = false;
            chargeTime = 0;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            ShootSoundEffect.Play();
            rb.AddForce(rotation.normalized * -smallRecoilForce, ForceMode2D.Impulse);
        }     


   
    }

    void ReleaseCharge()
        {
            Instantiate(chargedProjectile, bulletTransform.position, Quaternion.identity);
            isCharging = false;
            chargeTime = 0;
            canFire = false;
            ShootSoundEffect.Play();
            timer = 0;
        }
    
}
