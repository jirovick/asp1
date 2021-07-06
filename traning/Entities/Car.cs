namespace traning.Entities
{
    public class Car
    {
        public long ModelId { get; set; }
        public long Id { get; set; }
        public long LocationId { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public double Mileage { get; set; }
        

        public Car(long modelId, long locationId, int year, decimal price, double mileage)
        {
           
            ModelId = modelId;
            LocationId = locationId;
            Year = year;
            Price = price;
            Mileage = mileage;
        }

        public Car()
        {
        }
    }
}