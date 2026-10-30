using System;
using System.Collections.Generic;

namespace ControlWork
{
    public class OrderService
    {
        private readonly List<SupplyOrder> items;

        public OrderService(List<SupplyOrder> source)
        {
            if (source == null) throw new ArgumentException("Список не задан.");
            items = source;
        }

        public int Count { get { return items.Count; } }

        // ИСПРАВЛЕНО: стоимость = Quantity × UnitPrice
        public decimal CalculateCost(SupplyOrder item)
        {
            return item.Quantity * item.UnitPrice;
        }

        // ИСПРАВЛЕНО: сравнение ==, а не !=
        public SupplyOrder? Find(int id)
        {
            foreach (SupplyOrder item in items)
                if (item.Id == id) return item;
            return null;
        }

        // ИСПРАВЛЕНО: устанавливаем IsClosed = true
        public bool Close(int id)
        {
            SupplyOrder? item = Find(id);
            if (item == null) return false;
            item.IsClosed = true;
            return true;
        }

        // ИСПРАВЛЕНО: добавлена ;, фильтр !IsClosed (только открытые)
        public decimal GetOpenTotal()
        {
            decimal total = 0;
            foreach (SupplyOrder item in items)
                if (!item.IsClosed) total += CalculateCost(item);
            return total;
        }

        // РЕАЛИЗОВАНО вместо TODO
        public SupplyOrder Create(string text, int amount, decimal unitPrice)
        {
            // Id = максимальный + 1; для пустого списка — 1
            int newId = 1;
            if (items.Count > 0)
            {
                int maxId = int.MinValue;
                foreach (var it in items)
                    if (it.Id > maxId) maxId = it.Id;
                newId = maxId + 1;
            }

            // Валидация выполняется в конструкторе SupplyOrder (ArgumentException)
            // Если данные недопустимы — исключение, объект НЕ добавляется
            var order = new SupplyOrder(newId, text, amount, unitPrice);

            items.Add(order);
            return order;
        }
    }
}