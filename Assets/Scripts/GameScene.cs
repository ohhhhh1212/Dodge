using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public GameUI m_GameUI = null;
    public HudUI m_HudUI = null;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        GameMgr.Inst.BattleFSM.Initialize(OnReadyState, OnWaveState, OnGameState, OnResultState);
        GameMgr.Inst.GameInfo.Init();
        m_HudUI.Init();
    }


    void OnReadyState()
    {
        GameMgr.Inst.GameInfo.Init();
        m_GameUI.OnReadyState();
        m_HudUI.OnReadyState();
    }
    void OnWaveState()
    {

    }
    void OnGameState()
    {
        m_HudUI.OnGameState();
        m_GameUI.OnGameState();
    }
    void OnResultState()
    {
        m_HudUI.OnResultState();
        m_GameUI.OnResultState();
    }

    private void Update()
    {
        GameMgr.Inst.BattleFSM.OnUpdate();

        if (GameMgr.Inst.BattleFSM.IsGameState())
        {
            GameMgr.Inst.GameInfo.CalTime();
        }
    }

}
