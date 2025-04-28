# Hello. Welcome to my website.
My website also offers an Android dependency and a NuGet package as well.
## Android dependency
- Add JitPack in settings.gradle
```
dependencyResolutionManagement {
    /* other existing code */
    repositories {
        /* other existing code */
        maven { url 'https://jitpack.io' }
    }
}
```
- Add dependency in build.gradle
```
implementation 'com.github.saiaaaaaaa:my-website:(version)'
```
> The version will be seen in the Releases section
- Import the dependency based on your needs
```
import com.github.saiaaaaaaa.mywebsite_androidpackage.Check;
import com.github.saiaaaaaaa.mywebsite_androidpackage.Convert;
import com.github.saiaaaaaaa.mywebsite_androidpackage.EasySQL;
import com.github.saiaaaaaaa.mywebsite_androidpackage.FlippableImageView;
import com.github.saiaaaaaaa.mywebsite_androidpackage.Fullscreen;
```
## What is available in the Android dependency?
## 1. EasySQL
- Initialize EasySQL using context
```
EasySQL easySQL = new EasySQL(context);
```
### Methods
> EasySQL will automatically create/open a database while calling any methods
- Create a table
```
easySQL.createTable("sampledb", "sampletable", new String[]{"firstname:text", "lastname:text"});
```
- Insert a value to a table
```
easySQL.insertToTable("sampledb", "sampletable", new String[]{"firstname:FirstNameSaia", "lastname:LastNameSaia"});
```
- Get all values from a table
```
for (String s : easySQL.getTableValues("sampledb", "sampletable")){
    System.out.println(s);
}
```
- Check if a table exists
```
if (easySQL.doesTableExist("sampledb", "sampletable")){
    /* other existing code */
}
```
- Delete a table
```
easySQL.deleteTable("sampledb", "sampletable");
```
- Delete a value from a table
```
easySQL.deleteFromTable("sampledb", "sampletable", "firstname:FirstNameSaia");
```
> The method 'deleteFromTable' will delete the whole row with a matching columnValuePair
- Clear all values from a table
```
easySQL.clearTable("sampledb", "sampletable");
```
## 2. Fullscreen
> Keyword 'this' refers to any valid activity
- Enable fullscreen on any activity
```
Fullscreen.enable(this);
```
- Disable fullscreen on any activity
```
Fullscreen.disable(this);
```
## 3. Check
- Check if a String contains any symbols
```
Check.hasSymbols("Sample text"); // returns false
Check.hasSymbols("Sample text!"); // returns true
```
- Check if a String contains any numbers
```
Check.hasNumbers("Sample text"); // returns false
Check.hasNumbers("Sample text1"); // returns true
```
- Check if a String contains any spaces
```
Check.hasSpaces("Sample_text"); // returns false
Check.hasSpaces("Sample text"); // returns true
```
- Check if a String is a valid email
```
Check.Email.addValidDomainName("gmail");
Check.Email.addValidDomainName("outlook");
Check.Email.addValidDomainName("yahoo");

Check.Email.addValidDomainExtensions("com");

Check.Email.isValid("isaiahnoelsalazar474@gmail.com") // returns true
```
- Check how many seconds are left until specified date
```
Date now = new Date("02/10/2025");
Date until = new Date("02/14/2025");

Check.howManySecondsLeft(now, until); // returns 345600.0
```
- Check how many minutes are left until specified date
```
Date now = new Date("02/10/2025");
Date until = new Date("02/14/2025");

Check.howManyMinutesLeft(now, until); // returns 5760.0
```
- Check how many hours are left until specified date
```
Date now = new Date("02/10/2025");
Date until = new Date("02/14/2025");

Check.howManyHoursLeft(now, until); // returns 96.0
```
- Check how many days are left until specified date
```
Date now = new Date("02/10/2025");
Date until = new Date("02/14/2025");

Check.howManyDaysLeft(now, until); // returns 4.0
```
## 4. Convert
- Convert a String to Base64
```
Convert.toBase64("Sample text"); // returns "U2FtcGxlIHRleHQ="
```
- Convert a Base64 String to normal String
```
Convert.fromBase64("U2FtcGxlIHRleHQ="); // returns "Sample text"
```
- Convert a date to MM/DD/YY
```
Convert.dateToMMDDYY(new Date());
```
- Convert a date to DD/MM/YY
```
Convert.dateToDDMMYY(new Date());
```
- Convert a date to YY/MM/DD
```
Convert.dateToYYMMDD(new Date());
```
## NuGet package
- Add dependency in your project by running this command in the Package Manager Console
> Package Manager Console is found in Visual Studio's "Tools > NuGet Package Manager > Package Manager Console"
```
dotnet add package mywebsite_nugetpackage --version 1.0.6
```