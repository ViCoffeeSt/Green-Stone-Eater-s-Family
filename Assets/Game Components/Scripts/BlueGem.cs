using UnityEngine;
using DG.Tweening;

public class BlueGem : Gem
{
    [SerializeField] private float _multiScale;
    [SerializeField] private float _timeChangeScale;

    public bool SpliteStoneEater(GameObject gameObjectPlayer, float levelPlayer)
    {
        if (levelPlayer >= _levelGem)
        {
            gameObjectPlayer.transform.DOScale(gameObjectPlayer.transform.localScale * _multiScale, _timeChangeScale);


            Vector3 playerPosition = gameObjectPlayer.transform.position;
            Vector3 spawnOffset = new Vector3(1f, 0f, 1f);
            Vector3 spawnPosition = playerPosition + spawnOffset;

            Vector3 playerScale = gameObjectPlayer.transform.localScale;
            GameObject newPlayer = Instantiate(gameObjectPlayer, spawnPosition, Quaternion.identity);
            newPlayer.transform.localScale = playerScale * _multiScale;

            Player player = newPlayer.GetComponent<Player>();
            player.enabled = false;
            gameObject.SetActive(false);
            return true;
        }
        else return false;
    }
}
