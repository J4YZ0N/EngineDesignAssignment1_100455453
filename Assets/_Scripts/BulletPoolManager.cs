using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    // Reference to BulletPoolManager to turn into singleton
    public static BulletPoolManager instance = null;

    public GameObject bullet;

    public int maxBullets;

    // Structure to contain a collection of bullets
    private Queue<GameObject> bulletList;

    // Turns an instance of this script into a singleton for public use
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletList = new Queue<GameObject>();
        BuildBulletPool();
    }

    // Adds a series of bullets to the bullet pool
    private void BuildBulletPool()
    {
        for (int i = 0; i < maxBullets; i++)
        {
            GameObject newBullet = Instantiate(bullet, this.transform);
            bulletList.Enqueue(newBullet);
            newBullet.SetActive(false);
        }
    }

    // Returns current count of the bullet pool
    public int GetBulletPoolSize()
    {
        return bulletList.Count;
    }

    // Calls GetBulletPoolSize() to check if it is empty or not
    public bool IsPoolEmpty()
    {
        if(GetBulletPoolSize() == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Gets a bullet from the pool and activates it
    // If pool is empty it runs BuildBulletPool() again to create more bullets
    public GameObject GetBullet()
    {
        if (IsPoolEmpty())
        {
            BuildBulletPool();
            bullet = bulletList.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            bullet = bulletList.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
    }

    // Returns a bullet back to the pool and deactivates it
    public void ResetBullet(GameObject bullet)
    {
        bulletList.Enqueue(bullet);
        bullet.SetActive(false);
    }
}
