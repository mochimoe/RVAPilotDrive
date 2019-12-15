using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script have function to instantiate an object with object pooler method.
 */

public class ObjectPooler : MonoBehaviour
{
    // component of spawned gameObject
    [System.Serializable]
    public class Pool 
    {
        public string tag;
        public GameObject[] myObject;
        public int size;
    }

    public List<Pool> pools;

    // variable is used to spawn the object inside another gameObject
    public Transform targetSpawn;

    // this singleton is used to call the instance method on other script
    #region Singleton
    public static ObjectPooler Instance;

    private void Awake() 
    {
        Instance = this;    
    }
    #endregion

    // dictionary is used for save the object with identity
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++) 
            {
                int randomCloud = Random.Range(0, pool.myObject.Length);

                GameObject obj = Instantiate(pool.myObject[randomCloud], transform.position, 
                                            pool.myObject[randomCloud].transform.rotation, targetSpawn);

                obj.SetActive(false);

                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    // spawning gameObject inside dictionary
    public GameObject spawnFromPool(string tag, Vector3 position)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("TAG " + tag + " doesnt exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
