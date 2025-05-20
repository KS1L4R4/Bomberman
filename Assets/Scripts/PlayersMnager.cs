using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersMnager : MonoBehaviour
{
    PlayerInputManager playerInputManager;

    [SerializeField] List<Transform> spawnPos;
    [SerializeField] List<Material> playerMat;

    void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    public void OnPlayerJoin(PlayerInput playerInput)
    {
        playerInput.gameObject.transform.position = spawnPos[playerInputManager.playerCount - 1].position;
        playerInput.gameObject.GetComponent<MeshRenderer>().material = playerMat[playerInputManager.playerCount - 1];
    }
    public void OnPlayerLeft(PlayerInput playerInput)
    {
        Debug.Log("Player Has Left");
    }
}
