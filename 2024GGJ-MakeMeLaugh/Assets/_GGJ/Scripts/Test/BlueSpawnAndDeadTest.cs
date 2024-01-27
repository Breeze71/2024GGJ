using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace V
{
    public class BlueSpawnAndDeadTest : MonoBehaviour
    {
        [SerializeField] private GameObject blueguysPrefabs;

        

        [Button("Spawn Blue Guy")]
        private void SpawnBlueGuy()
        {
            Instantiate(blueguysPrefabs, transform.position, Quaternion.identity);
        }

        
    }
}
