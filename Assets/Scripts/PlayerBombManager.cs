using UnityEngine;

public class PlayerBombManager : MonoBehaviour
{
    InputManager InputManager;
    public GameObject Bomb;

    private void Awake()
    {
        InputManager = GetComponent<InputManager>();
    }

    private void OnEnable()
    {
        InputManager.OnBombPressed.AddListener(DeployBomb);
    }

    private void OnDisable()
    {
        InputManager.OnBombPressed.RemoveListener(DeployBomb);
    }

    private void DeployBomb()
    {
        Instantiate(Bomb, transform.position, Quaternion.identity);
    }
}
