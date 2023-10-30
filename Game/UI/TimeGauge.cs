using UnityEngine;
using UnityEngine.UI;

public class TimeGauge : MonoBehaviour
{
    public float timeShards = 5f;

    public int timeShardsUsed = 0;

    private Text text;

    public GameObject TimeShardsText { get; private set; }

    void Start()
    {
        TimeShardsText = new GameObject
        {
            name = "timeShardsText"
        };

        TimeShardsText.AddComponent<Text>();
        text = TimeShardsText.GetComponent<Text>();

        // Properties for the text component
        text.text = "Time Shards";
        text.fontSize = 40;
        text.color = Color.cyan;
        text.horizontalOverflow = HorizontalWrapMode.Overflow;
        text.verticalOverflow = VerticalWrapMode.Overflow;
        text.alignment = TextAnchor.UpperLeft;
        text.font = Resources.Load<Font>("Roboto-Regular");
        TimeShardsText.transform.SetParent(GameObject.Find("Canvas").transform);
        TimeShardsText.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        TimeShardsText.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
        TimeShardsText.GetComponent<RectTransform>().anchoredPosition = new Vector3(50, -100, 1);
        TimeShardsText.transform.localScale = new Vector3(1, 1, 1);
    }

    void Update()
    {
        // Displays the text of the timeshards on the screen
        TimeShardsText.GetComponent<Text>().text = "Time Shards: " + timeShards;
    }
}
