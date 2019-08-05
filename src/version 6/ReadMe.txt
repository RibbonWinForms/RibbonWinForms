Aug 05, 2019, adriancs
================
Dear programmers, Version 6 is planned to be a brand new release.

Discussion: "New development of Ribbon: Version 6"
https://github.com/RibbonWinForms/RibbonWinForms/issues/40

tajbender (https://github.com/tajbender) has made a study on the code of current project where he has some findings as follow:

Back to the early stages, there were a few conditions to be considered, but as time went by and across several Windows Operating System, there were far too many things and conditions to be taken care and this resulting too many if else statements and hacking here and there, and this resulting a code base which is high restricted it's potential to do further improvement. It is currently hardly maintainable.

It is suggested to do a brand new release. I personally agreed with tajbender.

I have restructured the repository and created a new folder called "Version 6". From here, a new code will start to evolve from here. As for this new repository, we will try to make it compatible across different platform, such as MONO, Net Core, Net Standard, etc.