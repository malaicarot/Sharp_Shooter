using UnityEngine;

public class EnemyPool : ObjectPool
{
    public static EnemyPool SingleTonItemsPool;

    void Start()
    {
        SingleTonItemsPool = this;
    }

    public PooledObject GetEnemy(string name, Vector3 position, Quaternion quaternion)
    {
        PooledObject objOfPool = SingleTonItemsPool.GetPooledObject(name);
        objOfPool.transform.position = position;
        objOfPool.transform.rotation = quaternion;
        return objOfPool;
    }
}
