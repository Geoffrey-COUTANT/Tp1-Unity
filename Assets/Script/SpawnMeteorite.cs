using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 0.5f;

    private Camera mainCamera;
    private float nextSpawnTime;

    void Start()
    {
        mainCamera = Camera.main;
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = CalculateSpawnPosition();
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        
        if (!IsObjectVisible(spawnedObject.GetComponent<Renderer>()))
        {
            Destroy(spawnedObject);
        }
    }

    Vector2 CalculateSpawnPosition()
    {
        float spawnX = Random.Range(-8f, 8f);
        float spawnY = Random.Range(6f, 6f);

        return new Vector3(spawnX, spawnY);
    }

    bool IsObjectVisible(Renderer objectRenderer)
    {
        if (objectRenderer == null)
            return false;
        
        Plane[] frustumPlanes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        return GeometryUtility.TestPlanesAABB(frustumPlanes, objectRenderer.bounds);
    }
}