using UnityEngine;
using DG.Tweening;

public class YellowGem : Gem
{
    [Space]
    [SerializeField] private float _multiScale;
    [SerializeField] private float _changeScaleTime;

    public bool PlayerGetsBigger(Transform player, float levelPlayer)
    {
        if (levelPlayer > _levelGem)
        {
            player.DOScale(player.localScale * _multiScale, _changeScaleTime);
            gameObject.SetActive(false);
            return true;
        }
        else return false;
    }
}
