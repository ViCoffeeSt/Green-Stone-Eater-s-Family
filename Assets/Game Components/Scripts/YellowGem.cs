using UnityEngine;
using DG.Tweening;

public class YellowGem : Gem
{
    [Space]
    [SerializeField] private float _multiScale;
    [SerializeField] private float _changeScaleTime;

    public override bool PlayerInteract(Player player)
    {
        if (player.LevelPlayer > _levelGem)
        {
            player.transform.DOScale(player.transform.localScale * _multiScale, _changeScaleTime);
            gameObject.SetActive(false);
            player.IncreaseStonesEaten();
            return true;
        }
        else
        {
            return false;
        }
    }
}
