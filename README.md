
# FruityTools

FruityTools is a set of tools for VTuber content creators to make their job easier and faster! Please take note that the latest [UniVRM](https://github.com/vrm-c/UniVRM/releases/latest) package is required for these tools to work.

All tools can be accessed from the `Fruity Tools` menu at the top of the screen.

Here's a list of the current tools and what they do:

### Fruity Blendshapes Generator
Fruity Blendshapes Generator, or FBG for short creates and assigns automatically for you the Blendshapes when creating a VRM avatar. Simply make sure that the Blendshapes inside your model have the exact same names as the ones required by VSeeface and other face-tracking applications.

For example, you should have a Blendshape in your Blender model named `A`, `E`, `I`, `O`, `U`, etc...

The tool will create a Blendshape Clip for every single one in your model and assign to it a value of 100 automatically in a folder named `NewBlendShapes` in the `Assets` folder. Simply assign the new generated Blendshape object in your VRM Prefab and export!