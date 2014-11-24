// KaraokeMachine.cpp : Defines the entry point for the console application.
// Please note that this is far from the final version, a work in progress.
// Comments here are reminders of what I need to do and also of code that may
// still be useful.

#include "stdafx.h"
using namespace std;

//This function is only a place holder, code here was used to explore the <time.h> library
void timeFunc()
{
  time_t start,end;
  char szInput [256];
  int dif;
  //int elapTicks, elapMilsec, elapSec, elapMin;

  time (&start); //the time starts ticking down
  printf ("Enter something to see how long it took to type");
  gets (szInput); // gets the user input
  time (&end); //Stops the time counting
  dif = difftime (end,start); //gets the time (in secs) it took by subtracting the end from the start
  cout << dif;

	// This section here helps work out the minutes, seconds etc that pass by, this part of code it obsolute
	// for this app since I will be using "difftime" which calculates time in seconds anyway,
	// Less work for me! :)
   //elapTicks = end - start;        //the number of ticks from Begin to End
   //elapMilsec = elapTicks/1000;     //milliseconds from Begin to End
   //elapSec = elapMilsec/1000;   //seconds from Begin to End
   //elapMin = elapSec/60;   //minutes from Begin to End
}

int _tmain(int argc, _TCHAR* argv[])
{
	int sum = 0;
    int x;
	//vector<string> text (20); To be deleted
	string line;
    ifstream inFile;
    
    //inFile.open("C:\\Documents and Settings\\Rob\\My Documents\\Visual Studio 2008\\Projects\\KaraokeMachine\\KaraokeMachine\\song.txt", ios::out);
	//Finally it works now without the long pathname!, don't delete encase it breaks it again
	inFile.open("song.txt", ios::out);
    if (!inFile) {
        cout << "Unable to open file. \n";
        exit(1); // terminate with error
    }
    
	if (inFile.is_open()) 
	{
		while (!inFile.eof()) { //While not end of file do...
			getline (inFile,line);
			cout << line << endl;
			//if (line[i] ...) use something like this here to get the first number value at the start of each sentance in the txt file
			//Also, it wont do to output lines, will need to output words (use chars?)
		}
	inFile.close();
	}
    
	timeFunc(); //call to time func, To be deleted or replaced by the real time functionality
    return 0;
}

/* To Do:
Find out how to link to .dll to play MP3
Change the read from file code to read chars rather than full lines
Get the timer working properly
...
*/

