using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{   

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

    [SerializeField] private Transform Platform_start;
    [SerializeField] private List<Transform> PlatformPartList;
    [SerializeField] private Player player;

    private Vector3 lastEndPosition;

    public Vector3 GetPosition()
    { 
        return transform.position;
    }

    private void Awake()
    {
        lastEndPosition = Platform_start.Find("EndPosition").position;
        
        int startingSpawnLevelPart = 5; 
        for(int i = 0; i < startingSpawnLevelPart; i++){
            SpawnLevelPart();
        }
    
    
        
    }

    private void Update()
    {
        if(Vector3.Distance(player.GetPosition(),lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART) {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = PlatformPartList[Random.Range(0,PlatformPartList.Count)];
        Transform lastLevelPartTransform =SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
       Transform levelPartTransform =  Instantiate(levelPart,spawnPosition, Quaternion.identity);
       return levelPartTransform;
    }
}
