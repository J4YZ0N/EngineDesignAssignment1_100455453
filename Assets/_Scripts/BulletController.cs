using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 0.1f;
    public Boundary boundary;

    //a reference to the BulletPoolManager
    //private BulletPoolManager _manager;

    void Start()
    {
        boundary.Top = 2.45f;
        //_manager = FindObjectOfType<BulletPoolManager>();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += new Vector3(0.0f, bulletSpeed * Time.deltaTime, 0.0f);
    }

    private void CheckBounds()
    {
        if (transform.position.y >= boundary.Top)
        {
            // Returns the bullet to the pool
            BulletPoolManager.instance.ResetBullet(this.gameObject);
        }
    }
}
