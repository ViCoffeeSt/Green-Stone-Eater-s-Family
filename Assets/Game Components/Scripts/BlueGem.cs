using UnityEngine;
using DG.Tweening;

public class BlueGem : Gem
{
    [SerializeField] private float _multiScale;
    [SerializeField] private float _timeChangeScale;

    public override bool PlayerInteract(Player player)
    {
        if (player.LevelPlayer >= _levelGem)
        {
            player.transform.DOScale(player.transform.localScale * _multiScale, _timeChangeScale);

            Vector3 playerPosition = player.transform.position;
            Vector3 spawnOffset = new Vector3(1f, 0f, 1f);
            Vector3 spawnPosition = playerPosition + spawnOffset;

            Vector3 playerScale = player.transform.localScale;
            GameObject newPlayer = Instantiate(player.gameObject, spawnPosition, Quaternion.identity);
            newPlayer.transform.localScale = playerScale * _multiScale;

            Player newPlayerComponent = newPlayer.GetComponent<Player>();
            newPlayerComponent.enabled = false;
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
