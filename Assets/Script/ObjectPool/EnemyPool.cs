using UnityEngine;

public class EnemyPool : ObjectPool
{
    public static EnemyPool SingleTonItemsPool;

    void Start()
    {
        SingleTonItemsPool = this;
    }

    public RobotMarkPool GetEnemy(string name, Vector3 position, Quaternion quaternion)
    {
        PooledObject objOfPool = SingleTonItemsPool.GetPooledObject(name);
        RobotMarkPool robot = objOfPool.GetComponent<RobotMarkPool>();
        robot.transform.position = position;
        robot.transform.rotation = quaternion;
        return robot;
    }
}
