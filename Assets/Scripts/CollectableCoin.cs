

public class CollectableCoin : Collectable
{

    protected override void OnCollect(Player player)
    {
        player.AddCoins(1);
    }

}
