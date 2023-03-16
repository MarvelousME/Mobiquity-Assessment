using com.mobiquity.packer.lib.Extensions;
using com.mobiquity.packer.lib.Helpers;
using com.mobiquity.packer.lib.Models;

namespace com.mobiquity.packer
{
    /// <summary>
    /// Class that will have the functionality for the heavy lifting taking an input file path
    /// as a parameter else will use an absolute file path by default to read and Split packageList
    /// and retrieve the items, cost and weight.
    /// </summary>
    public class Packer
    {
        #region Constants
        const int PACKAGETOTALWEIGHT = 0;
        const int PACKAGELIST = 1;
        #endregion

        #region Variables
        static string output = "", outputPackageContents = "", ss = "";

        static double maxCost = 100, maxWeight = 100;

        static List<Package> packageList = new List<Package>();

        static List<string> packageListCollection = new List<string>();
        #endregion

        /// <summary>
        /// Method that will retrieve the items, cost and weight.
        /// </summary>
        /// <param name="filePath">File path to input file</param>
        /// <returns>Output file with calculations in a string</returns>
        public static string pack(string filePath)
        {
            //Clear Package List
            packageList.Clear();

            //Read file contents in byte[]
            var dataBytes = FileHelper.ReadAllBytes(filePath).Result;

            //Read my file contents from bytes to a string 
            string fileContent = FileHelper.GetUTF8EncodedString(dataBytes).Result;

            //Split each row in string by Environment.NewLine characters i.e \r,\n
            var rows = fileContent.Lines();

            //Loop through each row in file and do calculation
            foreach (var row in rows)
            {
                //Get each row and Split by ":" (semi-colon)
                string[] lineSegements = row.Split(':');

                //Check that the Split equals 2 for processing
                if (lineSegements.Length != 2) { continue; }

                //Get packageTotalWeight from the first segment of the row
                int packageTotalWeight = Int32.Parse(lineSegements[PACKAGETOTALWEIGHT]);

                //Get packageList for the row
                packageListCollection = lineSegements[PACKAGELIST].Split(' ').ToList();

                //Remove any elements that are empty strings using LINQ
                var rowsRemoved = packageListCollection.RemoveAll(x => x.Equals(""));

                if (packageListCollection.Count() > 0)
                {
                    //Process 
                    PackageHelper.ProcessPackageListForMaxWeight(packageListCollection.ToArray(), packageList, packageTotalWeight);

                    for (int i = 1; i <= packageList.Count(); i++)
                    {
                        string result = PackageHelper.CheckMaximum(packageList, i, packageTotalWeight);

                        string[] processedPackage = result.Split(',');

                        double cost = double.Parse(processedPackage[processedPackage.Length - 2]);
                        double weight = double.Parse(processedPackage[processedPackage.Length - 1]);

                        if (cost == 0 && weight == 0) continue;

                        #region Do Cost and Weight camparison
                        //Do Cost and Weight camparison
                        //if (cost == maxCost)
                        //{
                        if (weight < maxWeight)
                        {
                            maxCost = cost;
                            maxWeight = weight;
                            outputPackageContents = result;
                        }
                        //}
                        if (cost > maxCost)
                        {
                            maxCost = cost;
                            maxWeight = weight;
                            outputPackageContents = result;
                        }
                        #endregion
                    }

                    //Process the result: concatenate and create new line in string
                    string[] outputPackageList = outputPackageContents.Split(',');

                    for (int i = 0; i < outputPackageList.Length - 2; i++)
                    {
                        output += packageList[Int32.Parse(outputPackageList[i])].getId() + ',' + Environment.NewLine;
                    }
                    if (ss.Equals(""))
                    {
                        output = "-" + Environment.NewLine;
                    }
                    else
                    {
                        output += string.Concat(ss.AsSpan(0, ss.Length - 1), Environment.NewLine);
                    }
                }
                else
                {
                    output += "-" + Environment.NewLine;
                }
            }

            return output;
        }
    }
}
