using DG.Tweening;
using UnityEngine;

public abstract class Gem : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private float _moveDistance;
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _rotationAngle;
    [SerializeField] private float _rotationDuration;

    private Transform itemTransform;

    protected float _levelGem;

    public abstract bool PlayerInteract(Player player);


    private void Start()
    {
        itemTransform = transform;
        AnimateItem();
        _levelGem = SetLevelGem(transform);
    }

    private float SetLevelGem(Transform transform)
    {
        return transform.localScale.x;
    }

    private void AnimateItem()
    {
        Sequence itemSequence = DOTween.Sequence();
        itemSequence.Append(itemTransform.DOMoveY(itemTransform.position.y - _moveDistance, _moveDuration).SetEase(Ease.InOutSine));
        itemSequence.Append(itemTransform.DOMoveY(itemTransform.position.y, _moveDuration).SetEase(Ease.InOutSine));

        itemTransform.DORotate(new Vector3(0, _rotationAngle, 0), _rotationDuration, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Incremental)
            .SetEase(Ease.Linear);

        itemSequence.OnComplete(AnimateItem);
    }
}
