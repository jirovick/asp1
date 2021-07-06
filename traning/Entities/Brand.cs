using Microsoft.AspNetCore.Mvc;

namespace traning.Entities
{
    public class Brand
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public bool IsLuxury { get; set; }

        public Brand(string name, bool isLuxury)
        {
            Name = name;
            IsLuxury = isLuxury;

        }

        public Brand()
        {
            
        }
    }
}