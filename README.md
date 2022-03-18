# CalendarChallenge

To run this:
- You need to run as administrator. However, this can change by replace the output folder to other driver than C:\. 
This can be found in class App method Run()
The line you are looking for is File.WriteAllText("C:\\Calendar of "+ yearToProcess + ".html", html);

- You need to copy the styles.css to the same folder you created the HTML files

Caveat:
- As this is more of an UI testing, and relatively small program, there isn't any unit tests for it. This can be added and checking but would still worth looking at UI more. (decided to go for manual testing)
- 
Known isses:
- Dates in calendar need to be more alligned with weekdays, there are some unalligned days, although not completely but might worth fixing

Improvement in the future:
- HTML created not putting together in a foler, this can be quickly done by adding filePath and create this before creating the file
- Refactor some classes and methods to follow SOLID principles more
- Although this is a small console app, there are some logger can be implemented in the future 
- Add commit policies on master branch
- There are quite some complicated variables and methods, this should be made simplier and easy to follow
- Optimising loops is an option, although this would not be impacting much at the moment but there should be more handlers to perform better
- Week numbers can be added 
- Find better ways to use lists in this programs, although it is running but i think the Lists can be simpler and optimised
