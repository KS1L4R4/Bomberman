using System.Collections.Generic;
using UnityEngine;

public class PowerUpsPawner : MonoBehaviour
{
    [SerializeField] List<GameObject> powerUpPrefs = new List<GameObject>();

    private void OnDisable()
    {
        int rand = Random.Range(0, powerUpPrefs.Count);
        Instantiate(powerUpPrefs[rand], transform.position, Quaternion.identity);
    }
}
