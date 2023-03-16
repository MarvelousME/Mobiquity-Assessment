# Mobiquity-Assessment
Assessment for company: Mobiquity (Netherlands)

Assignment: Package Challenge<br/>
Introduction<br/>
You want to send your friend a package with different things.<br/>
Each thing you put inside the package has such parameters as index number, weight and cost. The<br/>
package has a weight limit. Your goal is to determine which things to put into the package so that the<br/>
total weight is less than or equal to the package limit and the total cost is as large as possible.<br/>
You would prefer to send a package which weighs less in case there is more than one package with the<br/>
same price.<br/>
Input sample<br/>
Your API should accept as its only argument a path to a filename. The input file contains several lines.<br/>
Each line is one test case.<br/>
Each line contains the weight that the package can take (before the colon) and the list of items you need<br/>
to choose. Each item is enclosed in parentheses where the 1st number is a item’s index number, the 2nd<br/>
is its weight and the 3rd is its cost. E.g.<br/>
81 : (1,53.38,€45) (2,88.62,€98) (3,78.48,€3) (4,72.30,€76) (5,30.18,€9)<br/>
(6,46.34,€48)<br/>
8 : (1,15.3,€34)<br/>
75 : (1,85.31,€29) (2,14.55,€74) (3,3.98,€16) (4,26.24,€55) (5,63.69,€52)<br/>
(6,76.25,€75) (7,60.02,€74) (8,93.18,€35) (9,89.95,€78)<br/>
56 : (1,90.72,€13) (2,33.80,€40) (3,43.15,€10) (4,37.97,€16) (5,46.81,€36)<br/>
(6,48.77,€79) (7,81.80,€45) (8,19.36,€79) (9,6.76,€64)<br/><br/>
Output sample<br/>
For each set of items that you put into a package provide a new row in the output string (items’ index<br/>
numbers are separated by comma). E.g.<br/>
4<br/>
-<br/>
2,7<br/>
8,9<br/><br/>
Constraints<br/>
You should write a class com.mobiquity.packer.Packer with a static API method named pack. This<br/>
method accepts the absolute path to a test file as a String. The test file will be in UTF-8 format. The pack<br/>
method returns the solution as a String.<br/>
Your method should throw an error/exception named APIException<br/>
(com.mobiquity.packer.APIException where relevant) if any constraints are not met. Therefore your API<br/>
signature in pseudocode should look like:<br/>
string pack(string filePath)<br/>
Additional constraints:<br/>
1. Max weight that a package can take is ≤ 100<br/>
2. There might be up to 15 items you need to choose from<br/>
3. Max weight and cost of an item is ≤ 100<br/><br/>
Remember<br/>
Apply best practices for software design & development and document your approach (what<br/>
strategy/algorithm/data structure/design pattern you chose and why) and put comments into your<br/>
source files. We do consider TDD a best practice.<br/><br/>
Your Result<br/>
When finished, please send a link to a public repository or a zip file to your contact person within<br/>
Mobiquity. The zip file/repository should include the source files for your solution. The source code will<br/>
be examined by one of our developers. Note that your delivered source code should be considered<br/>
production release ready.<br/>
Your solution is meant to be used as a cross platform library, NOT as a standalone application.<br/>
Good luck with this assignment. If you have any questions, don’t hesitate to ask your contact person<br/>
within Mobiquity.<br/>
