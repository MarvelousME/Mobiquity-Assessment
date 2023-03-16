namespace com.mobiquity.packer.lib.Models
{
    /// <summary>
    /// Package model, properties and methods
    /// </summary>
    public class Package
    {
        #region Fields
        private int id;
        private double weight;
        private double cost;
        #endregion

        #region Constructor
        public Package(int id, double weight, double cost)
        {
            this.id = id;
            this.weight = weight;
            this.cost = cost;
        }
        #endregion

        #region Methods
        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public double getWeight()
        {
            return weight;
        }

        public void setWeight(double weight)
        {
            this.weight = weight;
        }

        public double getCost()
        {
            return cost;
        }

        public void setCost(double cost)
        {
            this.cost = cost;
        }
        #endregion
    }
}
