using UnityEngine;
using DG.Tweening;

public class BlueGem : Gem
{
    [SerializeField] private float _multiScale;
    [SerializeField] private float _timeChangeScale;

    public override void PlayerInteract(Player player)
    {
        if (player.LevelPlayer < _levelGem)
        {
            return;
        }

        player.transform.DOScale(player.transform.localScale * _multiScale, _timeChangeScale);

        Vector3 spawnOffset = new(1f, 0f, 1f);
        Vector3 spawnPosition = player.transform.position + spawnOffset;

        GameObject newPlayer = Instantiate(player.gameObject, spawnPosition, Quaternion.identity);
        newPlayer.transform.localScale = player.transform.localScale * _multiScale;

        Player newPlayerComponent = newPlayer.GetComponent<Player>();
        newPlayerComponent.enabled = false;
        gameObject.SetActive(false);
        player.IncreaseStonesEaten();
        player.UpdateLevel();
    }
}
