using System.Collections.Generic;
using UnityEngine;

namespace _Main.Project.Scripts.ObjectPooling
{
    public class ObjectPooler : MonoBehaviour
    {
        [System.Serializable]
        private class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }

        [SerializeField] private List<Pool> pools;
        private Dictionary<string, Queue<GameObject>> poolDictionary;

        public static ObjectPooler Instance;

        private void Awake()
        {
            Instance = this;
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            // Initialize all pools on awake
            foreach (var pool in pools)
            {
                InitializePool(pool);
            }
        }

        // Initializes a pool for the given pool data
        private void InitializePool(Pool pool)
        {
            var objectPool = new Queue<GameObject>();

            for (var i = 0; i < pool.size; i++)
            {
                var obj = Instantiate(pool.prefab, transform, true);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }

        // Spawn an object from the specified pool
        public GameObject SpawnFromPool(string poolTag)
        {
            if (!poolDictionary.ContainsKey(poolTag))
            {
                Debug.LogWarning("Pool with tag " + poolTag + " doesn't exist.");
                return null;
            }

            if (poolDictionary[poolTag].Count == 0)
            {
                var pool = pools.Find(p => p.tag == poolTag);
                if (pool != null)
                {
                    ExpandPool(pool);
                }
            }

            var objectToSpawn = poolDictionary[poolTag].Dequeue();

            objectToSpawn.SetActive(true);
            var pooledObj = objectToSpawn.GetComponent<IPooledObject>();
            pooledObj?.OnObjectSpawn();

            return objectToSpawn;
        }

        // Expands the pool by instantiating additional objects
        private void ExpandPool(Pool pool)
        {
            var obj = Instantiate(pool.prefab, transform, true);
            obj.SetActive(false);
            poolDictionary[pool.tag].Enqueue(obj);
        }
        
        public void ReturnToPool(string poolTag, GameObject objectToReturn)
        {
            if (!poolDictionary.ContainsKey(poolTag))
            {
                Debug.LogWarning("Pool with tag " + poolTag + " doesn't exist.");
                return;
            }

            objectToReturn.SetActive(false);
            poolDictionary[poolTag].Enqueue(objectToReturn);
        }
    }
}