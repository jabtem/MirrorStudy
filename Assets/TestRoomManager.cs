using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Mirror;
public class TestRoomManager : NetworkRoomManager
{
    //NetworkRoomManager = 대기실생성 혹은 방을 참가하여 플레이하는 멀티플레이 구조를 만들때 사용
    //OfflineScene = 오프라인에서 동작할 씬 예) 메인메뉴
    //Online Scene = 온라인에서 동작할 씬 
    bool showbutt;
    public override void OnRoomServerPlayersReady()
    {
        // calling the base method calls ServerChangeScene as soon as all players are in Ready state.
#if UNITY_SERVER // 서버빌드에서만 추가
            base.OnRoomServerPlayersReady();
#else
        showbutt = true; //#if !UNITY_SERVER
#endif
    }//If Server Show StartButton
    public override void OnGUI()
    {
        base.OnGUI();

        if (allPlayersReady && showbutt && GUI.Button(new Rect(150, 300, 120, 20), "START GAME"))
        {
            // set to false to hide it in the game scene
            showbutt = false;

            ServerChangeScene(GameplayScene);
        }
    }//GameStartButton


    public override void ServerChangeScene(string newSceneName)
    {
    }

    public override void OnServerSceneChanged(string sceneName)
    {
        base.OnServerSceneChanged(sceneName);
    }
}
