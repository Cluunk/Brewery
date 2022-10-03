using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class StorageManager
{
    public static List<Storage> Storages { get; private set; } = new List<Storage>();

    public static bool StoreIngredients(ItemType type, int amount)
    {
        var availableStorages = FindStoragesOfType(type);

        if (availableStorages.Length <= 0)
            return false;

        foreach (var storage in availableStorages)
        {
            var availableSpace = storage.MaxAmount - storage.Amount;
            if (availableSpace <= 0)
                continue;
            amount -= availableSpace;
            storage.Deposit(availableSpace);
        }
        
        return true;
    }

    public static void EmptyStorage(ItemType type, int amount)
    {
        
    }

    private static Storage[] FindStoragesOfType(ItemType type)
    {
        return Storages.Where(storage => storage.Type == type).ToArray();
    }
}
