using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 40f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelParts;
    [SerializeField] private GameObject player;

    public List<Transform> levelSpawned = new List<Transform>(); 

    private Vector3 lastEndPosition;
    // Start is called before the first frame update
    void Start()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        levelSpawned.Add(levelPart_Start);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
            SpawnLevelPart();
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelParts[Random.Range(0, levelParts.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        levelSpawned.Add(levelPartTransform);
        if (levelSpawned.Count > 9)
        {
            Destroy(levelSpawned[0].gameObject);
            levelSpawned.RemoveAt(0);
        }

        return levelPartTransform;
    }
}
