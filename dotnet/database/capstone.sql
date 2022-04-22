USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
);

CREATE TABLE code (
	code_id int IDENTITY(1,1) NOT NULL,
	user_id int NOT NULL,
	programming_language varchar(50) NOT NULL,
	title varchar(50) NOT NULL,
	snippet varchar(MAX) NULL,
	code_description varchar(MAX)  NULL,
	example_date varchar(50)  NULL,
	difficulty_rank varchar(50)  NULL,
	category varchar(MAX)  NULL,
	submission_status int NOT NULL,
	is_public int NOT NULL,
	attribution varchar(MAX) NULL,
	generic_example int NOT NULL,
	CONSTRAINT PK_code PRIMARY KEY (code_id),
	-- CONSTRAINT [FK_example] FOREIGN KEY (user_id) REFERENCES [users] (user_id)
);

--populate default data
-- user/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

-- admin/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

INSERT INTO code
    (user_id, title, programming_language, example_date, code_description, snippet, difficulty_rank, category, attribution, submission_status, is_public, generic_example)
VALUES
    (1, 'Reverse JavaScript forloop', 'JavaScript', '01/01/2022 01:00:00 AM', 'A way to start by max n and decrease the index after each loop. This can be useful for starting at the end of an array and looping through it backwards', 'const maxIndex = 100;
for (let i = maxIndex; i >= 0; i--) {
  if (i == 0) {
    console.log("No More Bottles Of Milk On The Wall :/");
  } else {
    console.log(`${i} Bottles of Milk On The Wall`);
  }
}
', 'Easy', 'Functional', 'Aidan Wallace;https://www.freecodecamp.com', 1, 1, 1);
INSERT INTO code
    (user_id, title, programming_language, example_date, code_description, snippet, difficulty_rank, category, attribution, submission_status, is_public, generic_example)
VALUES
    (1, 'C# word counter', 'C#', '01/01/2022 01:00:00 AM', 'Enter a string and get a sum of all the words', 'using System;
public class WordCounter
{
    public static void Main()
    {
        string str;
        int i, wrd, l;
        Console.Write("\n\nCount the total number of words in a string :\n");
        Console.Write("------------------------------------------------------\n");
        Console.Write("Input the string : ");
        str = Console.ReadLine();
        l = 0;
        wrd = 1;
        /* loop till end of string */
        while (l <= str.Length - 1)
        {
            if (str[l] == " " || str[l] == "\n" || str[l] == "\t")
            {
                wrd++;
            }
            l++;
        }
        Console.Write("Total number of words in the string is : {0}\n", wrd);
    }
}', 'Easy', 'Functional', 'Elon Musk;https://www.geeksforgeeks.com', 1, 1, 1);
INSERT INTO code
    (user_id, title, programming_language, example_date, code_description, snippet, difficulty_rank, category, attribution, submission_status, is_public, generic_example)
VALUES
    (1, 'Multiply a matrix', 'Python', '01/01/2022 01:00:00 AM', 'Combine a matrix using python', '# 3x3 matrix
X = [
    [12,7,3],
    [4 ,5,6],
    [7 ,8,9]
]
# 3x4 matrix
Y = [
    [5,8,1,2],
    [6,7,3,0],
]
# result is 3x4
result = [
    [0,0,0,0],
    [0,0,0,0],
    [0,0,0,0]
]
for i in range(len(X)):
   for j in range(len(Y[0])):
       for k in range(len(Y)):
           result[i][j] += X[i][k] * Y[k][j]
for r in result:
   print(r)', 'Medium', 'Mathmatics', 'Jeff Bejos', 1, 1, 1);
INSERT INTO code
    (user_id, title, programming_language, example_date, code_description, snippet, difficulty_rank, category, attribution, submission_status, is_public, generic_example)
VALUES
    (1, 'Check OS in GOLANG', 'Golang', '01/01/2022 01:00:00 AM', 'Check the operating system of the current machine', 'package main
import (
    "fmt"
    "runtime"
)
func main() {
    os := runtime.GOOS
    switch os {
    case "windows":
        fmt.Println("Windows")
    case "darwin":
        fmt.Println("MAC operating system")
    case "linux":
        fmt.Println("Linux")
    default:
        fmt.Printf("%s.\n", os)
    }
}', 'Easy', 'Data Other', 'Aidan Wallace;https://www.freecodecamp.com', 1, 1, 1);
INSERT INTO code
    (user_id, title, programming_language, example_date, code_description, snippet, difficulty_rank, category, attribution, submission_status, is_public, generic_example)
VALUES
    (1, 'Get date and time', 'Bash', '01/01/2022 01:00:00 AM', 'Get the current date and time with a shell script. (.sh)', '#!/bin/bash
Year=`date +%Y`
Month=`date +%m`
Day=`date +%d`
Hour=`date +%H`
Minute=`date +%M`
Second=`date +%S`
echo `date`
echo "Current Date is: $Day-$Month-$Year"
echo "Current Time is: $Hour:$Minute:$Second"', 'Easy', 'Data', 'Aidan Wallace;https://www.freecodecamp.com', 1, 1, 1);
INSERT INTO code
    (user_id, title, programming_language, example_date, code_description, snippet, difficulty_rank, category, attribution, submission_status, is_public, generic_example)
VALUES
    (1, 'Animated Cloud Logo', 'CSS HTML', '01/01/2022 01:00:00 AM', 'Create an animated logo', 
  '/*HTML*/
  <div id="animatedlogo">

  </div>

/*CSS*/
  #animatedlogo{
  grid-area: "logo";
  display:fixed;
  justify-content: center;
  align-items: center;

  width:50vw;
  height:40vh;

  background-image:url(../assets/animatedlogo/cloudcodeanimated1.svg);
  background-position: center;
  background-repeat:no-repeat;
  
  margin: 0 auto;
  animation: alternate 4s infinite ;
}
@keyframes alternate{
  3.2%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated2.svg);
  }
  6.4%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated3.svg);
  }
  9.6%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated4.svg);
  }
  12.8%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated5.svg);
  }
  16.1%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated6.svg);
  }
  19.3%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated7.svg);
  }
  22.5%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated8.svg);
  }
  25.7%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated9.svg);
  }
  28.9%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated10.svg);
  }
  32.2%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated11.svg);
  }
  35.4%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated12.svg);
  }
  38.6%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated12-5.svg);
  }
  41.8%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated13.svg);
  }
  45%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated14.svg);
  }
  48.3%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated15.svg);
  }
  51.5%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated16.svg);
  }
  54.7%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated17.svg);
  }
  57.9%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated18.svg);
  }
  61.1%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated19.svg);
  }
  64.4%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated20.svg);
  }
  67.6%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated21.svg);
  }
  70.8%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated22.svg);
  }
  74.%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated23.svg);
  }
  77.2%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated24.svg);
  }
  80.5%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated24-5.svg);
  }
  83.7%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated25.svg);
  }
  86.9%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated26.svg);
  }
  90.1%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated27.svg);
  }
  93.3%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated28.svg);
  }
  96.6%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated29.svg);
  }
  100%{
    background-image:url(../assets/animatedlogo/cloudcodeanimated30.svg);
  }
}', 'Medium', 'Web', 'Misha Shatokhin;https://www.codecloud.com', 1, 1, 1);
GO
