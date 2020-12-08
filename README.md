///////////////////////////////////////////////////////
///////////////////////////////////////////////////////
//                                                   //
//                                                   //
//                FIND PHONE NUMBER                  //
//                                                   //
//                                                   //
///////////////////////////////////////////////////////
///////////////////////////////////////////////////////


#OVERVIEW
This console app takes in string values from a CSV file, extracts a phone-number if it exists, and writes the results (single column) to a new CSV file.

##Notes:
1. The _**read path and write path must be manually specified in the FindPhoneNumber.cs_** file before running the app.
1. CSV values must not contain carriage return, new line, or line break characters.  It will cause the return CSV file to contain more values than expected.
1. This console app could be ported to a WPF application used within another type of framework for broader usability.


##Credits
For REGEX structure of a phone number goes to gadildafissh on StackOverflow.  Contributor's original code can be found at:
[Stack Overflow] (https://stackoverflow.com/questions/8596088/c-sharp-regex-phone-number-check).