using UnityEngine;

public class CubeSpawner : Spawner
{
    public GameObject theCube;

    private void Update()
    {
        SpawnEnemy();
    }
    public override SpamCube SpawnEnemy()
    {
        GameObject SpawnedEnemy = Instantiate(theCube, transform.position, Quaternion.identity);
        return SpawnedEnemy.GetComponent<SpamCube>();
    }
}
