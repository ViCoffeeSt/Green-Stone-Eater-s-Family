
public class RedGem : Gem
{
    public override bool PlayerInteract(Player player)
    {
        if (player.LevelPlayer >= _levelGem)
        {
            gameObject.SetActive(false);
            player.IncreaseStonesEaten();
            player.TransitResults();
            Destroy(player.gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }
}
