using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] Turret[] m_Turrets = null;
    [SerializeField] Player m_Player = null;
    [SerializeField] Transform m_BulletParent = null;

    public void OnReadyState()
    {
        DestroyBullet();
        m_Player.Init();
    }

    public void OnGameState()
    {
        for (int i = 0; i < m_Turrets.Length; i++)
        {
            m_Turrets[i].Init();
        }
    }

    public void OnResultState()
    {
        for (int i = 0; i < m_Turrets.Length; i++)
        {
            m_Turrets[i].StopShoot();
        }
    }

    void DestroyBullet()
    {
        if (m_BulletParent.childCount == 0)
            return;

        for (int i = 0; i < m_BulletParent.childCount; i++)
        {
            Destroy(m_BulletParent.GetChild(i).gameObject);
        }
    }

    private void OnDestroy()
    {
        DestroyBullet();
    }
}
