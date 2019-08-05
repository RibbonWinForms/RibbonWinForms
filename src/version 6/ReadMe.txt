Aug 05, 2019, adriancs
================
As suggested by Thorsten Jung,  he had sunk into the codebase for the last days and it's very, very hard to do even minor changes. There are many side effects to take care. As far I can say now, it's nearly impossible to maintain the code in its current state, as 'everything' has been thrown into one single class file, the ProfessionalRenderer.

Some of the minor suggestion:

He would suggest creating a new branch for a new release, why not call it v5.9, and concentrate on these things:

1.       Add ImageList-Support
2.       Work on these Win10-Issues, including Tab-Text & DPI-Awareness,
3.       The Application Menu (Or Orb Menu).
4.       Runtime-Customization-Support.

For the Orb Menu, there are two Variants depending in the Office-Version, and the one that is just an Menu. Suggestion is to work on an normal Menu, but revise its Render Style.

And hence, this version will be called as version 6 - Alpha stage.