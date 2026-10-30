using System.Collections.Generic;
namespace ControlWork
{
    public static class SampleData
    {
        public static List<SupplyOrder> Create()
        {
            return new List<SupplyOrder>
            {
                new SupplyOrder(10, "Первая запись", 2, 500m),
                new SupplyOrder(20, "Вторая запись", 3, 400m),
                new SupplyOrder(30, "Закрытая запись", 1, 300m) { IsClosed = true }
            };
        }
    }
}
