using UnityEngine;

[RequireComponent(typeof(PooledObject))]
public class RobotMarkPool : PooledObject
{
    public void RobotRelease(){
        Release();
    }
}
