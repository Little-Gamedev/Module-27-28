using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    private readonly List<Item> _items = new List<Item>();
    private readonly int _maxSize;

    public Inventory(int maxSize)
    {
        if (maxSize <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxSize), "Вместимость должна быть больше нуля");

        _maxSize = maxSize;
    }

    public int MaxSize => _maxSize;

    public int CurrentSize => _items.Sum(item => item.Count);

    public IReadOnlyList<Item> Items => _items;

    public bool CanAdd(Item item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        return CurrentSize + item.Count <= _maxSize;
    }

    public bool HasItem(string name, int count)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя предмета не может быть пустым", nameof(name));

        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Количество должно быть больше нуля");

        Item foundItem = _items.FirstOrDefault(item => item.Name == name);

        return foundItem != null && foundItem.Count >= count;
    }

    public bool TryAdd(Item item)
    {
        if (CanAdd(item) == false)
        {
            Debug.LogError($"[Inventory] Не хватает места для {item.Name}");

            return false;
        }

        Item existingItem = _items.FirstOrDefault(storedItem => storedItem.Name == item.Name);

        if (existingItem == null)
            _items.Add(item);
        else
            existingItem.Add(item.Count);

        return true;
    }

    public bool TryGetItems(string name, int count, out Item takenItem)
    {
        takenItem = null;

        if (HasItem(name, count) == false)
        {
            Debug.LogError($"[Inventory] Нет {count} шт. предмета {name}");

            return false;
        }

        Item foundItem = _items.First(item => item.Name == name);

        foundItem.Remove(count);

        if (foundItem.Count == 0)
            _items.Remove(foundItem);

        takenItem = new Item(name, count);

        return true;
    }
}