using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObjects/SpawnDataScriptable")]
public class SpawnDataScriptable : ScriptableObject
{
    [System.Serializable]
    public class SpawnEntry
    {
        public GameObject ObjectToSpawn => _objectToSpawn;
        public Vector3 SpawnPosition => _spawnPosition;

        [SerializeField] private GameObject _objectToSpawn;
        [SerializeField] private Vector3 _spawnPosition;
    }

    private List<SpawnEntry> _spawnEntries = new List<SpawnEntry>();
    public List<SpawnEntry> SpawnEntries => _spawnEntries;
    
}
