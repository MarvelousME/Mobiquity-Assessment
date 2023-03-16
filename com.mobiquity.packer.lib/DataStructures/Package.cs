namespace com.mobiquity.packer.DataStructures
{
    public struct Package
    {
       public int PackageWeight { get; set; } 
        public int currItemsWeight { get; set; }
        public int maxItemsWeight { get; set; }
        public int totalWeight { get; set; }
        public int totalWorth { get; set; }
        public string[] items { get; set; }
    }
}
