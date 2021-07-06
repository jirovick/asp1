namespace traning.Entities
{
    public class Location
    {
        public string Name { get; set; }
        public long Id { get; set; }
        
        public Location(string location)
        {
            Name = location;
        }

        public Location()
        {
            
        }
        
    }
}