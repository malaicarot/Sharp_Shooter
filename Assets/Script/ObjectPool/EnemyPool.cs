using UnityEngine;

public class EnemyPool : ObjectPool
{
    public static EnemyPool SingleTonItemsPool;

    void Awake()
    {
        SingleTonItemsPool = this;
    }

    public RobotMarkPool GetEnemy(string name, Vector3 position, Quaternion quaternion)
    {
        PooledObject objOfPool = SingleTonItemsPool.GetPooledObject(name, position, quaternion);
        RobotMarkPool robot = objOfPool.GetComponent<RobotMarkPool>();
        return robot;
    }
}
