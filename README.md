# Snake-And-Ladders-ConsoleApp
A simple snaked and ladders game on a ConsoleApp. Total numbers of player that can play is assigined at prompt line.

**Rules:**
-When two players are playing, each rolls a dice, first to get a six, rolls first.
-PLayers can land on snakes and ladderss moving their tokens accordingly.
// ladder - move up from 2 to square 12
// ladder - move up from 20 square 30
// ladder - move up from 40 square 60
// ladder - move up from 40 square 60
// ladder - move up from 80 square 90
// snake - move down from 12 to square 2
// snake - move down from 15 to square 1
// snake - move down from 55 to square 45
// snake - move down from 75 to square 65
// snake - move down from 95 to square 85
-At point of reaching the goal mark (100), if players dice exceeds 100 mark then it stays at the same postion.
-When players dice hits 100, games ends with the winner announce.

**Tackling the poblem:**
Assigning the numbers of players to play. Initially was going to put a try catch when assigning in strings, but then
the TryParse method takes a string and returns an int indicating if succeeded. warp a loop around till an int is taken.

Numbers of players into an array as its much more easier for me to control/assign its position which then I can use its position
to look at the Dictionary for their Tkey if matches then return the value Tvalue (solving the snake and ladder problem.

Added RollDice to Logic method as it makes sense to have them together when player turns starts.
This mean every time Logic is run, the RollDice gets passes as a parameter.

Within the static Main, tokens.Length; is the No. of players playing. which goes by one for every turn.
logicResult gets copied to the array element Nth of tokens array, so everything is controlled by a for loop, for loop breaks
when logicretults reaches boardlenght (100).

**Improvements:**
I will take this consoleApp and make it a WPF using XAML as my UI now that I have the Core Logic behind.
Maybe will create a Tokens Class with its postioning rather than calling it all from a method.?
