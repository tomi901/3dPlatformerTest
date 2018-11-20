using UnityEngine;
using TMPro;


public class PlayerUI : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI coinCountText;

    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();

        SetCountText(coinCountText, player.Coins);
        player.OnCoinsCollected += coinCount => SetCountText(coinCountText, coinCount);
    }

    private static void SetCountText(TextMeshProUGUI text, int count)
    {
        text.text = ("x " + count);
    }

}
