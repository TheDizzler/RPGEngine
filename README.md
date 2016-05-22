# RPGEngine
A custom RPG engine using DirectXTK in C++ and story creation tool (MakerEngine) in C#.

This repo contains two projects: An RPG engine (root directory) in C++ and a story creation tool (/MakerEngine) in C#.
The creation tool edits XML files that are parsed by the RPG engine.

3rd party libraries used:
1. RPGEngine
	- pugixml (http://pugixml.org/)
2. MakerEngine 
	- DDSImageParser (https://gist.github.com/soeminnminn/e9c4c99867743a717f5b#file-ddsimageparser-cs)
	- Winform Accordion Control (https://sourceforge.net/projects/accordion/).

## Done:
> RPG Engine
>- Parse and display text from XML
>- Prompt player with a pop-up question box and dialog flows to proper reply
>- Prompt player for alphanumeric input (name input) and save input
>
> Maker Engine
>- Parse and display game text
>- Create new dialog "blocks" and save to XML file

## To Do Next:
> RPG Engine
>- ~~update parser to read changes made to xml structure~~
>- add speakers name to top of text box
>- change dds gfx asset loading from compiled file to parsed xml
>- parse and display .tmx files
>
> Maker Engine
>- Create, edit and save full dialog flow (mostly done: changes likely needed when linking to game objects)
>- Load dds gfx assets and save xml for engine
>- parse .tmx files (Tiled Map Editor) and view (edit?)
>- convert graphic files used in .tmx to .dds
>- ~~Map creation and~~ linking to game text (npc chatting, triggered events, gfx)
>- preview loaded spritefonts (possible??)


## To Do later:
> RPG Engine
>- allow dynamic font changing
>- map/town system
>- battle system
>
> Maker Engine
>- User testing
