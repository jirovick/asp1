namespace traning.Entities
{
    public class CarDetailsDto
    {
        public double Mileage { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public long Id { get; set; }
    }

    public class CarModelDto
    {
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string BodyName { get; set; }
        public long Id { get; set; }
    }

    public class CarLocationDto
    {
        public string LocationName { get; set; }
        public long Id { get; set; }
    }
}