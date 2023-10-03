
public class RedGem : Gem
{
    public override void PlayerInteract(Player player)
    {
        if (player.LevelPlayer < _levelGem)
        {
            return;
        }

        gameObject.SetActive(false);
        player.IncreaseStonesEaten();
        player.TransitResults();
        player.UpdateLevel();
        Destroy(player.gameObject);
    }
}
