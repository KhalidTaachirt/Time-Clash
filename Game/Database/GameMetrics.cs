using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GameMetrics : MonoBehaviour
{
    private GameObject player;

    private readonly string url = "./SendPlayerData.php";

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // This method allows the data to be configured when the player loses
    public void SetPlayerData()
    {
        // Set current player location with lives, played time and time shards used
        StartCoroutine(SendPlayerData(player.transform.position, player.GetComponent<PlayerLives>().lives,
            player.GetComponent<TimeGauge>().timeShardsUsed, player.GetComponent<PlayedTime>().playedTime));
    }

    // Send player data when the player loses to the PHP file with a POST request
    IEnumerator SendPlayerData(Vector3 playerLocation, int playerHealth, int usedShards, float playedTime)
    {
        // Make a new form and add playerlocation and playerhealth variables so that they can be accessed in PHP
        WWWForm SendPlayerDataUponLossForm = new();
        SendPlayerDataUponLossForm.AddField("playerLocation", playerLocation.ToString());
        SendPlayerDataUponLossForm.AddField("playerHealth", playerHealth);
        SendPlayerDataUponLossForm.AddField("usedShards", usedShards);
        SendPlayerDataUponLossForm.AddField("playedTime", playedTime.ToString("f1"));
        // Make a POST request to the remote PHP file
        using UnityWebRequest SendPlayerDataUponLossRequest = UnityWebRequest.Post(url, SendPlayerDataUponLossForm);
        yield return SendPlayerDataUponLossRequest.SendWebRequest();
        // Show error logs in the console
        if (SendPlayerDataUponLossRequest.result == UnityWebRequest.Result.ConnectionError ||
            SendPlayerDataUponLossRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(SendPlayerDataUponLossRequest.error);
        }
        else
        {
            Debug.Log(SendPlayerDataUponLossRequest.downloadHandler.text);
        }
    }
}
