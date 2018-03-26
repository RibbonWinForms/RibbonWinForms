# RibbonWinForms
An Office Ribbon Control for .NET WinForms

## Download
https://github.com/RibbonWinForms/RibbonWinForms/releases


2007 Style<br />
<img src='https://github.com/RibbonWinForms/RibbonWinForms/blob/master/documentation/t3.png' />

2010 Style<br />
<img src='https://github.com/RibbonWinForms/RibbonWinForms/blob/master/documentation/t4.png' />

2013 Style<br />
<img src='https://github.com/RibbonWinForms/RibbonWinForms/blob/master/documentation/t5.png' />

# History
This project is originally created by Jose Menendez Poo at [ribbon.codeplex.com](https://ribbon.codeplex.com/) in May 2008. You can have a read at his early article published at [codeproject.com](https://www.codeproject.com/Articles/25907/A-Professional-Ribbon-You-Will-Use-Now-with-orb). During the time where this project was initially published, there wasn't any free ribbon plugin available for WinForms. Thus, this project quickly gain attention from many .NET WinForms developers. But however, at a later time, Jose had fade out his involvement in the old site.

After the old [project repository](https://ribbon.codeplex.com) has gone inactivity, some [volunteers](https://officeribbon.codeplex.com/team/view) of the fans of this project re-host the source code at [officeribbon.codeplex.com] and continue to [provide support](https://officeribbon.codeplex.com/SourceControl/latest) of it. Until today, multiple changes, improvements, tweaks, bugs fixes have been added/enhanced. Another article was written by the group at  [codeproject.com](https://www.codeproject.com/Articles/364272/Easily-Add-a-Ribbon-into-a-WinForms-Application-Cs) to further explain the implementation of the plugin in WinForms.

In 31 March 2017, codeplex.com has announced the shutdown of the site's operation in [here](https://blogs.msdn.microsoft.com/bharry/2017/03/31/shutting-down-codeplex/) and another announcement [here](https://codeplex.codeplex.com/wikipage?title=Moving%20CodePlex%20to%20read-only) which says codeplex.com will be fully in READ ONLY mode after November 27th, 2017. Therefore, once again, the project is moved and here is the new site. Welcome to the new site.

For historical articles and source code, you can still obtain it at the old sites, but for support and new development, you may continue to seek or contribute here.

Jase Menendez Poo is back with us in this repository :)

by adriancs, Nov 23 2017

# Introduction
*Below is the original introductory message written by Jose Menedez Poo on May 10th, 2008*

This is a Microsoft Office 2007 Ribbon Bar - like control for .NET, as all of the code in [my site](http://www.menendezpoo.com/), **is free and open source**. At the time this is being written, is yet the best ribbon available for free.

Please refer to my site/blog [http://www.menendezpoo.com](http://www.menendezpoo.com/) for more on usage, development and news about this project.

<img src='https://github.com/RibbonWinForms/RibbonWinForms/blob/master/documentation/s1.jpg' />

Because of the lack of good free Ribbon controls on the web, I decided to write one myself. I've analyzed previous work on ribbon-controls. Unfortunately, most existent controls are merely bad tries. Why? well, some lack nice rendering, some lack resizing features, some lack almost everything. Of course, well developed Ribbon controls are available at a price. **This ribbon is free**.

### Some of the design goals

**Performance** - This ribbon is contained on a Control window, and every element inside of it is managed as a bunch of bounds inside the control, just as the ToolStrip control does. Altough this is difficult to manage from the ribboon's inside code, this is a way to keep it at the best performed ribbon. Believe me, download the demo, run it and resize the window. It peforms beautifully.

**Consistency with Office's ribbon** - I read once about Jakob Nielsen saying that most users prefer the programs they use look just like word, excel or powerpoint. This is quite obvious, because people use this software every day. Providing visual consistency with the office's ribbon is very important because people already know what to expect from a ribbon-like interface. I've tried to every element in the ribbon look and behave exactly like it does in the Office's ribbon.

**Ease of use for programmers** - The naming of components is consistent with most WinForms names, even more with the ToolStrip elements. Property, event and method names for similar elements are named just like in the ToolStrip technology items.

**Designer support** - I will be adding more and more designer support so you can manage the ribbon 100% from the designer.

### Using the Ribbon

The ribbon is located in the **System.Windows.Forms** namespace, just as every other control, I think it's annoying to use controls named as **MyCoolFirm.MyCoolNameSpace.MyCoolSubNameSpace**, and so on (Please do that only for bussiness objects).

You can add a reference to the compiled dll: **System.Windows.Forms.Ribbon.dll** or you can directly copy the source files to a folder on your project. The code is currently designed so you can just copy the source files, it doesn't need any extra resources.

### Hands on: Quick Guide

The ribbon is composed mainly by three kind of elements, the tabs, the panels on the tabs (other developers call them groups) and the items inside the panels.

<img src='https://github.com/RibbonWinForms/RibbonWinForms/blob/master/documentation/s2.gif' />

<img src='https://github.com/RibbonWinForms/RibbonWinForms/blob/master/documentation/s3.gif' />

<img src='https://github.com/RibbonWinForms/RibbonWinForms/blob/master/documentation/s4.gif' />

These elements are represented by **RibbonTab**, **RibbonPanel** and **RibbonItem** types. RibbonItem is an abstract class that provides basic functionality for any item hosted on a RibbonPanel or on a RibbonDropDown.

You can add tabs from the smart tag of the Ribbon, you can add panels to the tab by selecting the tab and calling the "AddPanel" verb on the bottom part of the property grid.

The elements on the ribbon are resized according to the available space for the ribbon. This is a key feature of the ribbon. It tries to bring all possible commands to the screen by resizing them, instead of hiding them on an overflow button like the old ToolStrip.

I treat this as three kinds of sizes: Large, Medium and Compact. An additional size is used for panels because panels can be collapsed, and then they will adopt the Overflow size.

<img src='https://github.com/RibbonWinForms/RibbonWinForms/blob/master/documentation/s5.gif' />

Note: There's no way to directly affect the bounds of the elements on the ribbon, the size will always be determined the layout engine inside the ribbon. In fact, the layout depends on two factors: the available horizontal space on the ribbon and the size modes on the items.

If there's no available space on the ribbon for a panel, panel will be collapsed. If all panels are collapsed and space is not available yet, a scroll button will appear so user can scroll the panels horizontally.

<img src='https://github.com/RibbonWinForms/RibbonWinForms/blob/master/documentation/s6.gif' />

### Buttons

There's only one type of button: RibbonButton. It can be set to four styles, three of which are shown below. The fourth style, DropDownListItem, is the same as normal but with no image. It is used in simple dropdown lists like Font Size that don't require icons.

<img src='https://github.com/RibbonWinForms/RibbonWinForms/blob/master/documentation/s7.gif' />

RibbonButton adds the SmallImage property so you can set the image shown when button is in medium or compact mode. Although it's not restricted by functionality, it's highly recommended to use just 32 x 32 pixels for Image property and 16 x 16 for SmallImage property. Results are unexpected when sizes are different.

Note: Use the DropDownItems property to add items to the dropdown of the button.

The appearance of the buttons vary through size modes.

### ItemGroups

The buttons like those on the Font and Paragraph panels are RibbonButton buttons hosted inside a RibbonItemGroup group.

<img src='https://github.com/RibbonWinForms/RibbonWinForms/blob/master/documentation/s8.gif' />

Items added to RibbonItemGroup will always be measured and treated in compact size mode.

Important: If a RibbonPanel will host RibbonItemGroup objects, you must set the RibbonPanel.FlowsTo property to Right. The layout on those items are treated differently because groups flow as rows.

### Lists

Lists are represented by RibbonButtonList and provide two collections: Buttons and DropDownItems. This is because the list can be scrolled on the ribbon and can dropdown more items. The dropdown of list supports resizing by a grip on the south east corner.

If you want the buttons on the list to be shown on the dropdown, you will have to explicitly add another list with those buttons to the DropDownItems property.

### Separators

Separators are represented by RibbonButtonSeparator and provides the well known separator functionality. When in a dropdown, separators can actually contain text. When they contain text, they will be rendered differently.

<img src='https://github.com/RibbonWinForms/RibbonWinForms/blob/master/documentation/s9.gif' />

When they don't contain text, they will displayed as a line and can cover the full width of the dropdown to separate different controls, or partially cover the dropdown width to separate similar controls:

<img src='https://github.com/RibbonWinForms/RibbonWinForms/blob/master/documentation/s10.png' />
