using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class StorageManager
{
    public static List<Storage> Storages { get; private set; }

    public static bool StoreIngredients(IngredientType type, int amount)
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

    public static void EmptyStorage(IngredientType type, int amount)
    {
        
    }

    private static Storage[] FindStoragesOfType(IngredientType type)
    {
        return Storages.Where(storage => storage.Type == type).ToArray();
    }
}
