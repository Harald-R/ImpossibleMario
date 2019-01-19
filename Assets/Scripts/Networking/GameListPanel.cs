using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameListPanel : MonoBehaviour
{
	[SerializeField] private JoinButton joinButtonPrefab;
	[SerializeField] private RectTransform scrollViewContent;

	private void Awake()
	{
		AvailableGamesList.OnAvailableGamesChanged += AvailableGamesList_OnAvailableGamesChanged;
	}

	private void OnDestroy()
	{
		AvailableGamesList.OnAvailableGamesChanged -= AvailableGamesList_OnAvailableGamesChanged;
	}

	private void AvailableGamesList_OnAvailableGamesChanged(List<LanConnectionInfo> connections)
	{
		ClearExistingButtons();
		CreateNewJoinGameButtons(connections);
	}

	private void ClearExistingButtons()
	{
		var buttons = GetComponentsInChildren<JoinButton>();
		foreach (var button in buttons)
		{
			Destroy(button.gameObject);
		}
	}

	private void CreateNewJoinGameButtons(List<LanConnectionInfo> connectionInfos)
	{
		foreach (var connectionInfo in connectionInfos)
		{
			var button = Instantiate(joinButtonPrefab);
			button.Initialize(connectionInfo, scrollViewContent);
		}
	}
}
