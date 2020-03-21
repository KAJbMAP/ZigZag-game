using UnityEngine;
using System.Collections.Generic;
public class TileGenerator : MonoBehaviour
{
    [System.Serializable]
    public struct TileOffsetInfo
    {
        public Vector3 OffsetDirection;
        public Quaternion rotation;
    }

    public Transform Ball;
    public GameObject StartPlatform;
    public GameObject Tile, TileWithCrystlal;
    public Transform SpawnTilePoint;
    public TileOffsetInfo[] TileSpawnHelper;
    public float CrystalTileChance = 0.2f;
    public float ActiveTileRadius;
    public float TileSize = 1f;

    private Queue<Tile> ActiveTiles = new Queue<Tile>(16);

    private void OnDrawGizmos()
    {
        if (!Ball)
            return;
        
        Gizmos.DrawWireSphere(Ball.position, ActiveTileRadius);
    }

    private void Start()
    {
        ActiveTiles.Enqueue(CreateNewTile(StartPlatform, Vector3.zero, Quaternion.identity));
    }

    private void FixedUpdate()
    {
        while (GetDistance(SpawnTilePoint.position, Ball.position) < ActiveTileRadius)
        {
            var offset = TileSpawnHelper[Random.Range(0, TileSpawnHelper.Length)];
            SpawnTilePoint.Translate(offset.OffsetDirection * TileSize, Space.World);
            SpawnTilePoint.rotation = offset.rotation;
            ActiveTiles.Enqueue(CreateNewTile(GetRandomTile(), SpawnTilePoint.position, SpawnTilePoint.rotation));
        }
                
        while (ActiveTiles.Count > 0)
        {
            if (GetDistance(ActiveTiles.Peek().transform.position, Ball.position) > ActiveTileRadius)
                ActiveTiles.Dequeue().Hide();
            else 
                break;
        }
    }

    private Tile CreateNewTile(GameObject tile, Vector3 position, Quaternion rotation)
    {
        return Instantiate(tile, position, rotation, transform).GetComponent<Tile>();
    }

    private float GetDistance(Vector3 fisrt, Vector3 second)
    {
        return Mathf.Abs((fisrt - second).magnitude);
    }

    private GameObject GetRandomTile()
    {
        return Random.value > CrystalTileChance ? Tile : TileWithCrystlal;
    }
}