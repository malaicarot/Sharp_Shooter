using System.Collections.Generic;
using UnityEngine;
public class ObjectPool : MonoBehaviour
{
    [Range(10, 100), SerializeField] uint poolSize;
    [SerializeField] List<PooledObject> pooledList;
    Dictionary<string, Stack<PooledObject>> pooledDictionary;



    void Awake()
    {
        SetupPool();
    }
    void SetupPool()
    {
        if (pooledList.Count == 0 || pooledList == null)
        {
            return;
        }
        pooledDictionary = new Dictionary<string, Stack<PooledObject>>();
        foreach (var pooledObject in pooledList)
        {
            Stack<PooledObject> pooledStack = new Stack<PooledObject>();
            for (int i = 0; i < poolSize; i++)
            {
                PooledObject newObject = Instantiate(pooledObject);
                newObject._pool = this;
                newObject.gameObject.name = pooledObject.name;
                newObject.gameObject.SetActive(false);
                pooledStack.Push(newObject);
            }
            pooledDictionary.Add(pooledObject.name, pooledStack);
        }
    }


    public PooledObject GetPooledObject(string objectName)
    {
        if (string.IsNullOrEmpty(objectName) || !pooledDictionary.ContainsKey(objectName))
        {
            Debug.Log("This object name is not exits to get!");
            return null;
        }

        if (pooledDictionary[objectName].Count == 0)
        {
            PooledObject newObject = Instantiate(pooledList.Find(obj => obj.name == objectName));
            newObject._pool = this;
            newObject.gameObject.name = objectName;
            return newObject;
        }

        PooledObject nextObject = pooledDictionary[objectName].Pop();
        nextObject.gameObject.SetActive(true);
        return nextObject;

    }


    public void ReturnToPool(PooledObject pooledObject)
    {
        if (!pooledDictionary.ContainsKey(pooledObject.name))
        {
            Debug.Log("This name not exits to return!");
            Destroy(pooledObject);
            return;
        }
        else
        {
            pooledDictionary[pooledObject.name].Push(pooledObject);
            pooledObject.gameObject.SetActive(false);
        }

    }
}