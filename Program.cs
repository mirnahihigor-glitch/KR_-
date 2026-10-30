using System;
namespace ControlWork
{
    public class Program
    {
        public static void Main()
        {
            OrderService service = new OrderService(SampleData.Create());
            SupplyOrder? found = service.Find(20);
            Console.WriteLine("Поиск 20: " + (found == null ? "нет" : found.Id.ToString()));
            Console.WriteLine("Открытые записи: " + service.GetOpenTotal());
            Console.WriteLine("Закрытие 20: " + service.Close(20));
            Console.WriteLine("После закрытия: " + service.GetOpenTotal());
            Console.WriteLine("Добавьте собственные проверки по таблице задания.");
        }
    }
}
