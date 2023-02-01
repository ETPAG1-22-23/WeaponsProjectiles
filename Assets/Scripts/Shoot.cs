using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab; 
    private float speed = 5;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sr.flipX == true)
        {
            shootingPoint.localPosition = new Vector2(-0.93f, -0.61f);
        }
        else
        {
            shootingPoint.localPosition = new Vector2(0.93f, -0.61f);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (sr.flipX == true)
            {
                GameObject go = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            }
            else
            {
                GameObject go = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            }
        }
    }

}
