namespace traning.Entities
{
    public class Model
    {
        public long Id { get; set; }
        public long BodyId { get; set; }
        public string Color { get; set; }
        public bool IsNew { get; set; }
        public long BrandId { get; set; }


        public Model(long bodyId, string color, bool isNew, long brandId)
        {
            BodyId = bodyId;
            Color = color;
            IsNew = isNew;
            BrandId = brandId;
        }

        public Model()
        {
        }
    }
}