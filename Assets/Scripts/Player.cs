using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{

    [SerializeField]
    private int coins = 0;
    public int Coins { get { return coins; } }

    public event System.Action<int> OnCoinsCollected;


    private PlayerMovement playerMovement = null;
    public PlayerMovement PlayerMovement
    {
        get
        {
            if (playerMovement == null)
            {
                playerMovement = GetComponent<PlayerMovement>();
            }
            return playerMovement;
        }
    }


    public void AddCoins(int amount)
    {
        coins += amount;
        if (OnCoinsCollected != null) OnCoinsCollected(coins);
    }
	
}
