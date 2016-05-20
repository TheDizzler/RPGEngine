# RPGEngine
A custom RPG engine using DirectXTK in C++ and story creation tool (MakerEngine) in C#.

This repo contains two projects: An RPG engine (root directory) in C++ and a story creation tool (/MakerEngine) in C#.
The creation tool edits XML files that are parsed by the RPG engine.

3rd party libraries used:
1 RPGEngine
	- pugixml (http://pugixml.org/)
2 MakerEngines 
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
>- change dds gfx asset loading from compiled file to parsed xml
>- parse and display maps
>
> Maker Engine
>- Create, edit and save full dialog flow
>- Load dds gfx assets and save xml for engine
>- Map creation and linking to game text (npc chatting, triggered events, gfx)


## To Do later:
> RPG Engine
>- map/town system
>- battle system
>
> Maker Engine
>- User testing
