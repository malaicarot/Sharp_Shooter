using System;
using UnityEngine;

public class BulletPool : ObjectPool
{
    public static BulletPool SingletonBulletPool;
    void Awake()
    {
        if (SingletonBulletPool == null)
        {
            SingletonBulletPool = this;
        }
    }

    public void GetBullet(string objName, Vector3 objPosition, Quaternion quaternion)
    {
        PooledObject pooledObject = SingletonBulletPool.GetPooledObject(objName, objPosition, quaternion);
    }
}
