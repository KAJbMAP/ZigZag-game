using UnityEngine;
using System.Collections.Generic;
public class TileGenerator : MonoBehaviour
{
    public GameObject StartPlatform;
    public GameObject[] TilesVariations;
    public Transform Ball;
    public Transform SpawnTilePoint;
    public Vector3[] OffsetDirection;
    public float ActiveTileRadius;
    public float TileSize = 1f;

    private Queue<GameObject> ActiveTiles = new Queue<GameObject>(16);


    private void OnDrawGizmos()
    {
        if (!Ball)
            return;

        Gizmos.DrawWireSphere(Ball.position, ActiveTileRadius);
    }

    private void Start()
    {
        ActiveTiles.Enqueue(CreateNewTile(StartPlatform, Vector3.zero));
    }

    private void FixedUpdate()
    {
        while (GetDistance(SpawnTilePoint.position, Ball.position) < ActiveTileRadius)
        {
            Vector3 offset = OffsetDirection[Random.Range(0, OffsetDirection.Length)];
            SpawnTilePoint.Translate(offset, Space.World);
            ActiveTiles.Enqueue(CreateNewTile(GetRandomGameObject(TilesVariations), SpawnTilePoint.position));
        }

        if (ActiveTiles.Count > 0)
            while (GetDistance(ActiveTiles.Peek().transform.position, Ball.position) > ActiveTileRadius)
            {
                Destroy(ActiveTiles.Dequeue());
            }
    }

    private GameObject CreateNewTile(GameObject tile, Vector3 position)
    {
        return Instantiate(tile, position, Quaternion.identity, transform);
    }

    private float GetDistance(Vector3 fisrt, Vector3 second)
    {
        return Mathf.Abs((fisrt - second).magnitude);
    }

    private GameObject GetRandomGameObject(GameObject[] array)
    {
        return array[Random.Range(0, array.Length)];        
    }
}