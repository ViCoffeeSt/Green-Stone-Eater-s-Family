
public class RedGem : Gem
{
    public bool EndGame(float levelPlayer)
    {
        if (levelPlayer >= _levelGem)
        {
            gameObject.SetActive(false);
            return true;
        }
        else return false;
    }
}
