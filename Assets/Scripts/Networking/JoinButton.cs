using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class JoinButton : MonoBehaviour
{
	private Text buttonText;
	private LanConnectionInfo connectionInfo;

	private void Awake()
	{
		buttonText = GetComponentInChildren<Text>();
		GetComponent<Button>().onClick.AddListener(JoinGame);
	}

	public void Initialize(LanConnectionInfo connectionInfo, RectTransform scrollViewContent)
	{
		this.connectionInfo = connectionInfo;
		buttonText.text = connectionInfo.name;

		transform.SetParent(scrollViewContent);
		transform.localScale = Vector3.one;
		transform.localRotation = Quaternion.identity;
		transform.localPosition = Vector3.zero;
	}

	private void JoinGame()
	{
		SceneManagerWithParameters.SetParam("GameType", Globals.GameType.MULTIPLAYER_CLIENT.ToString());
		FindObjectOfType<CustomNetworkManager>().JoinGame(connectionInfo);
	}
}