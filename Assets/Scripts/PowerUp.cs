using NUnit.Framework.Internal;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;

    public void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerBombManager playerBombManager)) return;
        switch (powerUpType)
        {
            case PowerUpType.ExtraBomb:
                playerBombManager.AddExtraBomb();
                break;
            case PowerUpType.ExtraRange:
                playerBombManager.AddExtraRange();
                break;
        }
        gameObject.SetActive(false);
    }
}

public enum PowerUpType
{
    ExtraBomb,
    ExtraRange
}