using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Settings/Create NamesEaterAppers", fileName = "NamesEaterApeers",
    order = 0)]

public class NameEaterAppers : ScriptableObject
{
    [SerializeField] private List<string> _names;

    private List<string> _usedNames = new List<string>();

    public string GetUnusedRandomName()
    {
        List<string> availableNames = new List<string>(_names);
        //if (availableNames.Count == 0)
        //{
        //    return null;
        //}

        int randomIndex = Random.Range(0, availableNames.Count);

        string randomName = availableNames[randomIndex];

        _usedNames.Add(randomName);
        availableNames.Remove(randomName);

        return randomName;
    }

    public void FreeName(string nameToFree)
    {
        if (_usedNames.Contains(nameToFree))
        {
            _usedNames.Remove(nameToFree);
        }
    }
}
