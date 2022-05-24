using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Mirror;
public class TestRoomManager : NetworkRoomManager
{
    //NetworkRoomManager = ���ǻ��� Ȥ�� ���� �����Ͽ� �÷����ϴ� ��Ƽ�÷��� ������ ���鶧 ���
    //OfflineScene = �������ο��� ������ �� ��) ���θ޴�
    //Online Scene = �¶��ο��� ������ �� ��) �κ�, �ΰ���

    bool showbutt;
    public override void OnRoomServerPlayersReady()
    {
        // calling the base method calls ServerChangeScene as soon as all players are in Ready state.
#if UNITY_SERVER // �������忡���� �߰�
            base.OnRoomServerPlayersReady();
#else
        showbutt = true; //#if !UNITY_SERVER
#endif
    }//If Server Show StartButton
    public override void OnGUI()
    {
        if (!showRoomGUI)
            return;

        if (NetworkServer.active && IsSceneActive(GameplayScene))
        {
            GUILayout.BeginArea(new Rect(Screen.width - 150f, 10f, 140f, 30f));
            if (GUILayout.Button("Return to Room"))
                ServerChangeAddressableScene(RoomScene);
            GUILayout.EndArea();
        }

        if (IsSceneActive(RoomScene))
            GUI.Box(new Rect(10f, 180f, 520f, 150f), "PLAYERS");

        if (allPlayersReady && showbutt && GUI.Button(new Rect(150, 300, 120, 20), "START GAME"))
        {
            // set to false to hide it in the game scene
            showbutt = false;

            //ServerChangeScene(GameplayScene);
            ServerChangeAddressableScene(GameplayScene);
        }

    }//GameStartButton

    public override void OnServerSceneChanged(string sceneName)
    {
        base.OnServerSceneChanged(sceneName);
    }
}
