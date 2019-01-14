using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Globals;

public class LoadOnClick : MonoBehaviour
{
	public string sceneName;

    public void LoadScene()
	{
		try {
			GameType gameType = GameObject.Find("GameType").GetComponent<GameTypes>().GetGameType();
			CustomNetworkManager networkManager = GameObject.Find("NetworkManager").GetComponent<CustomNetworkManager>();
			SceneManagerWithParameters.SetParam("GameType", gameType.ToString());

			networkManager.ChangeScene(sceneName);
			networkManager.StartHosting();
            
		} catch(System.Exception e) {
			Debug.Log("Error: " + e);
		}
	}

	// TODO: Use method if lobby is implemented
	private void RedirectToScene(GameType gameType, string sceneName)
	{
		switch(gameType) {
			case GameType.SINGLEPLAYER:
				SceneManagerWithParameters.Load(sceneName, "GameType", gameType.ToString());
				break;
			case GameType.MULTIPLAYER_HOST:
			case GameType.MULTIPLAYER_CLIENT:
				SceneManagerWithParameters.SetParam("GameType", gameType.ToString());
				SceneManagerWithParameters.SetParam("SceneName", sceneName);
				SceneManagerWithParameters.Load("MultiplayerLobby");
				break;
			default:
				break;
		}
	}
}
