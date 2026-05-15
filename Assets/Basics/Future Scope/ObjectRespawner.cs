using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectRespawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnPoint
    {
        public Vector3 position;
        public GameObject prefab;
    }

    [Header("Spawn Settings")]
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    public float respawnDelay = 8f;
    public int maxObjectsInRoom = 15;

    [Header("Room Bounds — match your room size")]
    public Vector3 roomCenter = Vector3.zero;
    public Vector3 roomSize = new Vector3(10f, 4f, 10f);
    public float spawnHeight = 1f;  // height above floor to spawn at

    private List<GameObject> activeObjects = new List<GameObject>();

    void Start()
    {
        SpawnAll();
        StartCoroutine(RespawnLoop());
    }

    void SpawnAll()
    {
        foreach (var sp in spawnPoints)
        {
            SpawnAt(sp);
        }
    }

    void SpawnAt(SpawnPoint sp)
    {
        if (activeObjects.Count >= maxObjectsInRoom) return;

        // Clamp position inside room bounds + force correct height
        Vector3 safePos = new Vector3(
            Mathf.Clamp(sp.position.x, roomCenter.x - roomSize.x * 0.5f + 0.5f,
                                       roomCenter.x + roomSize.x * 0.5f - 0.5f),
            roomCenter.y - roomSize.y * 0.5f + spawnHeight,  // always just above floor
            Mathf.Clamp(sp.position.z, roomCenter.z - roomSize.z * 0.5f + 0.5f,
                                       roomCenter.z + roomSize.z * 0.5f - 0.5f)
        );

        GameObject obj = Instantiate(sp.prefab, safePos, Quaternion.identity);

        // Freeze briefly so object lands before physics goes wild
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            StartCoroutine(EnablePhysicsAfterDelay(rb, 0.5f));
        }

        activeObjects.Add(obj);
    }

    IEnumerator EnablePhysicsAfterDelay(Rigidbody rb, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (rb != null)
            rb.isKinematic = false;
    }

    IEnumerator RespawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnDelay);
            activeObjects.RemoveAll(o => o == null);

            foreach (var sp in spawnPoints)
            {
                if (activeObjects.Count < maxObjectsInRoom)
                    SpawnAt(sp);
            }
        }
    }

    // Draw room bounds in editor so you can see exactly where objects spawn
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(roomCenter, roomSize);
    }
}