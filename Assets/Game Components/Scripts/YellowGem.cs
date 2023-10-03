using UnityEngine;
using DG.Tweening;

public class YellowGem : Gem
{
    [Space]
    [SerializeField] private float _multiScale;
    [SerializeField] private float _changeScaleTime;

    public override void PlayerInteract(Player player)
    {
        if (player.LevelPlayer < _levelGem)
        {
            return;
        }

        player.transform.DOScale(player.transform.localScale * _multiScale, _changeScaleTime);

        gameObject.SetActive(false);

        player.IncreaseStonesEaten();
        player.UpdateLevel();
    }
}
