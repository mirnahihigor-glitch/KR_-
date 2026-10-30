using System;
namespace ControlWork
{
    public class SupplyOrder
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public bool IsClosed { get; set; }

        public SupplyOrder(int id, string text, int amount, decimal unitPrice)
        {
            if (id <= 0) throw new ArgumentException("Id должен быть положительным.");
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Текст не задан.");
            if (amount < 1 || amount > 20) throw new ArgumentException("Количество вне диапазона.");
            if (unitPrice <= 0) throw new ArgumentException("Цена должна быть положительной.");
            Id = id;
            Title = text.Trim();
            Quantity = amount;
            UnitPrice = unitPrice;
            IsClosed = false;
        }
    }
}
