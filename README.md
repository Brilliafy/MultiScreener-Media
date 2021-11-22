# MultiScreener-Media 

## Introduction
MultiScreener-Media is a GUI presentation tool, designed explicitly to ease the display of media files in a two-screen setup, in exhibitions/events.

## Prerequisites

* _**[.NET Framework 4.6 Runtime](https://dotnet.microsoft.com/download/dotnet-framework/net46)**_
* _**A [dual-screen setup](https://support.microsoft.com/en-us/windows/set-up-dual-monitors-on-windows-3d5c15dc-cc63-d850-aeb6-b41778147554)**_ *(additional screens are ignored)*


## Usage

Upon application launch, second screen is automatically detected and prepared for utilisation

You can load media using the _**`Files`**_ menu on the top left. Once loaded, Subsequently, you can click on the the desired media filename, and media will be played on the second screen.

Audio controls are only accesible during playback, and saved automatically for each session.

Time transformation is moreover attainable, using the _**`Jump at...`**_ functionality on the bottom of the application.


Supported timestamp formats: *`h:mm:ss`*, *`mm:mm`*, *`m:ss`*

Supported media files: [VLC feature formats](https://wiki.videolan.org/VLC_Features_Formats/)

## Project

The project was developed in **Visual Studio Preview 16.11 2019 Community Edition**, using **C# 8.0**.

It is a Windows Presentation Foundation app, in .NET Framework 4.6

The project depends on the **vlclib** library to play media.

Nuget packages are omitted, therefore it would be best to install them back in order to build the project *(See the project's references/dependencies)*





### `Leave a star on the project!`
