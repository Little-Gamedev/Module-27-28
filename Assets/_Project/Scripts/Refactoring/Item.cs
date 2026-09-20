using System;

public class Item
{
    private readonly string _name;
    private int _count;

    public Item(string name, int count)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя предмета не может быть пустым", nameof(name));

        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Количество должно быть больше нуля");

        _name = name;
        _count = count;
    }

    public string Name => _name;

    public int Count => _count;

    public void Add(int count)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Количество должно быть больше нуля");

        _count += count;
    }

    public void Remove(int count)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Количество должно быть больше нуля");

        if (count > _count)
            throw new InvalidOperationException("Нельзя забрать больше, чем есть");

        _count -= count;
    }
}