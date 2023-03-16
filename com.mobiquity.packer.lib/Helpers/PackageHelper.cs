using com.mobiquity.packer.lib.Models;

namespace com.mobiquity.packer.lib.Helpers
{
    /// <summary>
    /// Helper class with methods to process a Package and it's items
    /// </summary>
    public class PackageHelper
    {
        #region Constants
        const int ITEMINDEX = 0;
        const int ITEMWEIGHT = 1;
        const int ITEMPRICE = 2;
        #endregion

        #region Methods
        /// <summary>
        /// Method to Process PackageList For Row
        /// </summary>
        /// <param name="packageListCollection">List of Packages in row retrieved from file</param>
        /// <param name="packageList">Empty list of Packages</param>
        /// <param name="maxWeight">Max total weight of the row in file</param>
        public static void ProcessPackageListForMaxWeight(string[] packageListCollection, List<Package> packageList, double maxWeight)
        {
            for (int i = 0; i < packageListCollection.Length; i++)
            {
                string[] packageContent = (packageListCollection[i].Substring(1, packageListCollection[i].Length - 2)).Split(',');

                //Read Package Contents & Remove the Currency symbol
                int id = Int32.Parse(packageContent[ITEMINDEX]);
                double weight = Double.Parse(packageContent[ITEMWEIGHT]);
                double cost = Double.Parse(packageContent[ITEMPRICE].Substring(1, packageContent[ITEMPRICE].Replace(")", "").Replace("€", "").Length));

                //Check if the maxWeight is reached or is less than the max weight
                if (weight <= maxWeight)
                {
                    //Create Package object 
                    Package package = new Package(id, weight, cost);

                    AddPackageToCollection(packageList, package);
                }
            }
        }

        /// <summary>
        /// Add Package to the List Collection of Packages
        /// </summary>
        /// <param name="packageList">list of Packages</param>
        /// <param name="package">Package to add to packageList</param>
        public static void AddPackageToCollection(List<Package> packageList, Package package)
        {
            packageList.Add(package);
        }

        /// <summary>
        /// Method to check for maximum weight
        /// </summary>
        /// <param name="packageList">list of Packages</param>
        /// <param name="arrayRange"></param>
        /// <param name="inputMaxWeight">Max Weight Amount</param>
        /// <returns></returns>
        public static string CheckMaximum(List<Package> packageList, int arrayRange, int inputMaxWeight)
        {
            List<int> resolution = new List<int>();

            string returnData = "";

            int indexPackageFinal = 0;

            double maxWeight = 0, maxCost = 0, dWeight = 0, dCost = 0;

            //Decare new string Array with depth of the packageList object
            int[] newArray = new int[packageList.Count()];

            int[] data = new int[arrayRange];

            //Populate new Array
            for (int i = 0; i < packageList.Count(); i++)
            {
                newArray[i] = i;
            }

            Calculate(newArray, data, resolution, 0, 0);

            for (int i = 0; i <= resolution.Count() - arrayRange; i += arrayRange)
            {

                for (int j = 0; j < arrayRange; j++)
                {
                    dWeight += packageList[resolution[i + j]].getWeight();
                    dCost += packageList[resolution[i + j]].getCost();
                }
                if (dWeight <= inputMaxWeight)
                {
                    if ((dCost > maxCost) || ((dCost == maxCost) && (dWeight <= maxWeight)))
                    {
                        indexPackageFinal = i;
                        maxWeight = dWeight;
                        maxCost = dCost;
                    }
                }
            }
            for (int k = indexPackageFinal; k < arrayRange + indexPackageFinal; k++)
            {
                returnData += resolution[k] + ",";
            }
            return returnData + maxCost + "," + maxWeight;
        }

        /// <summary>
        /// Methid to calculate the combination of package max weight and cost using recursion
        /// </summary>
        /// <param name="newArray"></param>
        /// <param name="data"></param>
        /// <param name="resolution"></param>
        /// <param name="start"></param>
        /// <param name="index"></param>
        public static void Calculate(int[] newArray, int[] data, List<int> resolution, int start, int index)
        {
            //Check if index and data length is equal
            if (index == data.Length)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    resolution.Add(data[j]);
                }

                return;
            }

            for (int i = start; i < newArray.Length && newArray.Length - i >= data.Length - index; i++)
            {
                data[index] = newArray[i];

                //Recursion call
                Calculate(newArray, data, resolution, i + 1, index + 1);
            }
        }
        #endregion
    }
}
