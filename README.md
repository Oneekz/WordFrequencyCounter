## Word Frequency Counter
As an author I want to know the number of times each word appears in a sentence.

So that I can make sure I'm not repeating myself

###The application accepts such command line arguments:

##Input 
1. To pass input string data using command line arguments user such command:  **–w:"words"**

		WordFrequencyCounter.exe –w:"This is string and this nice string"

2. To pass input data from the file use command **–i:filepath**

		WordFrequencyCounter.exe –i:input.txt
		
		WordFrequencyCounter.exe –i:"C:\My data\input.txt"
3. If none of the input arguments were passed the application will ask user to enter data using the console

##Sorting (Optional)
1.	In order to sort result by words frequence use command **–s:count**

		WordFrequencyCounter.exe –s:count
		
2.	In order to sort resulted words by alphabet use command **–s:name**

		WordFrequencyCounter.exe –s:name
		
3.	If none of these sorting argument were passed the application will not sort the result

##Output
1.	In order to save result to the file use command **–o:filepath**

		WordFrequencyCounter.exe –o:result.txt
		
		WordFrequencyCounter.exe –i:"C:\My data\result.txt"
		
2.	If saving to the file was not prompted by the –o argument, the whole output will be show in the console

##Example of usage
This is an example of listing with passing input text using the command line arguments:
```
C:\data>WordFrequencyCounter.exe -w:"This should be a simple example. Yes it should" -s:name
Application has been started
Input text has 43 characters
After cleaning input text has 42 characters
After splitting we have 9 words
Sorting words alphabet was applied
Outputting result to the console
___________________________
a - 1
be - 1
example - 1
it - 1
s - 1
should - 2
simple - 1
yes - 1
___________________________
Press return to exit
```
