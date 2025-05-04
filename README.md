# Hello. Welcome to my website's GitHub repository.
My website also offers an Android dependency, a NuGet package, and a public Python code as well.
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
import com.github.saiaaaaaaa.mywebsite_androiddependency.Check;
import com.github.saiaaaaaaa.mywebsite_androiddependency.Convert;
import com.github.saiaaaaaaa.mywebsite_androiddependency.EasySQL;
import com.github.saiaaaaaaa.mywebsite_androiddependency.FlippableImageView;
import com.github.saiaaaaaaa.mywebsite_androiddependency.Fullscreen;
```
## What is available in the Android dependency?
## 1. Check
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

// or

Check.Email.shouldUseFullDomain(); // Check.Email.shouldUseFullDomain(true); also works
Check.Email.addValidDomain("gmail.com");

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
## 2. Convert
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
## 3. EasySQL
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
## 4. FlippableImageView
- Insert FlippableImageView in any of your layout/*.xml files like a normal ImageView
```
<com.github.saiaaaaaaa.cod.FlippableImageView
    android:id="@+id/img1"
    android:layout_width="100dp"
    android:layout_height="100dp"
    android:src="@drawable/sample_image" />
```
> Note: The code above is an example.
### Methods
> Calling the methods below will need an initialized object for FlippableImageView like a normal ImageView

> Example:
```
FlippableImageView img1 = findViewById(R.id.img1);
```
- Set a front image
```
img1.setFrontImage(R.drawable.sample_front_image);
```
- Set a back image
```
img1.setBackImage(R.drawable.sample_back_image);
```
- Flip the image view
```
img1.flip();
```
- Flip the image view upon clicking
```
img1.setOnClickListener(new View.OnClickListener() {
    @Override
    public void onClick(View v) {
        img1.flip();
    }
});
```
- Set flip speed
```
img1.setSpeed(Speed.SLOW);
img1.setSpeed(Speed.NORMAL);
img1.setSpeed(Speed.FAST);
```
## 5. Fullscreen
> Keyword 'this' refers to any valid activity
- Enable fullscreen on any activity
```
Fullscreen.enable(this);
```
- Disable fullscreen on any activity
```
Fullscreen.disable(this);
```
## NuGet package
- Add package in your project by running this command in the Package Manager Console
> Package Manager Console is found in Visual Studio's "Tools > NuGet Package Manager > Package Manager Console"
```
dotnet add package mywebsite_nugetpackage --version 1.1.5
```
- Import the package based on your needs
```
using mywebsite_nugetpackage;
```
> Note: The NuGet package supports .NET 6.0+ and .NET Framework 4.7+.
## What is available in the NuGet package?
## 1. Check
- Check if a String contains any symbols
```
Check.HasSymbols("Sample text"); // returns false
Check.HasSymbols("Sample text!"); // returns true
```
- Check if a String contains any numbers
```
Check.HasNumbers("Sample text"); // returns false
Check.HasNumbers("Sample text1"); // returns true
```
- Check if a String contains any spaces
```
Check.HasSpaces("Sample_text"); // returns false
Check.HasSpaces("Sample text"); // returns true
```
- Check if a String is a valid email
```
Check.Email.AddValidDomainName("gmail");
Check.Email.AddValidDomainName("outlook");
Check.Email.AddValidDomainName("yahoo");

Check.Email.AddValidDomainExtensions("com");

Check.Email.IsValid("isaiahnoelsalazar474@gmail.com") // returns true

// or

Check.Email.ShouldUseFullDomain(); // Check.Email.ShouldUseFullDomain(true); also works
Check.Email.AddValidDomain("gmail.com");

Check.Email.IsValid("isaiahnoelsalazar474@gmail.com") // returns true
```
## 2. Convert
- Convert a String to Base64
```
Convert.ToBase64("Sample text"); // returns "U2FtcGxlIHRleHQ="
```
- Convert a Base64 String to normal String
```
Convert.FromBase64("U2FtcGxlIHRleHQ="); // returns "Sample text"
```
## What is the "public Python code" in my website?
This refers to raw Python scripts located in "py > public" that anyone is free to copy and paste in their own projects.
It is not packaged as a pip module and consists of only the bare files.
## How do you use it?
## 1. Download the file, copy and paste it in your projects
## 2. Open the file, copy and paste the code in your scripts
## 3. Use "urllib.request" to read the script
Example:
```
import urllib.request

try:
    response = urllib.request.urlopen("https://saiaaaaaaa.github.io/my-website/py/public/test.py")
    content = response.read().decode('utf-8')
except:
    print("Server error")
```
The "content" variable contains the full script assuming the function "response.read()" ran properly.