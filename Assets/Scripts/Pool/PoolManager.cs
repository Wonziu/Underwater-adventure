using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public List<ObjectPoolItem> Items;
    public Dictionary<string, Queue<Projectile>> ItemPool;
    public Transform Parent;

    public static PoolManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        ItemPool = new Dictionary<string, Queue<Projectile>>();
        CreatePool();
    }

    public Projectile GetPooledObject(string s)
    {       
        if (ItemPool.ContainsKey(s))
        {
            Projectile lastObject = ItemPool[s].Peek();

            if (!lastObject.gameObject.activeInHierarchy)
            {
                Projectile objectToGet = ItemPool[s].Dequeue();
                ItemPool[s].Enqueue(objectToGet);
                return objectToGet;
            }

            Projectile go = Instantiate(lastObject);
            go.transform.SetParent(Parent);
            go.gameObject.SetActive(false);
            ItemPool[s].Enqueue(go);
            return go;
        }
        return null;
    }

    private void CreatePool()
    {
        foreach (ObjectPoolItem item in Items)
            if (!ItemPool.ContainsKey(item.Key))
            {
                ItemPool.Add(item.Key, new Queue<Projectile>());

                for (int i = 0; i < item.PoolAmount; i++)
                {
                    Projectile go = Instantiate(item.ItemToPool);
                    go.transform.SetParent(Parent);
                    go.gameObject.SetActive(false);
                    ItemPool[item.Key].Enqueue(go);
                }
            }
    }
}
