# UltraNixVideoFix
Allows the Credits Museum to play a `.webm` file of the same name in place of the original `.mp4` file for UNIX compatibility.

## IMPORTANT
The video can't just be any `.webm`, it **has** to be encoded with **libvpx/vp8** and **libvorbis**.

## Installation

Copy/move `NixVideoFix.dll` to your BepInEx plugins directory.

## Uninstallation

Remove `NixVideoFix.dll` from your BepInEx plugins directory.

## Usage

Place a WEBM with the same title as the original video (i.e. `uk_museum_ingame.mp4` -> `uk_museum_ingame.webm`) into `ULTRAKILL_Data/StreamingAssets/Videos/` (Linux) / `ULTRAKILL.app/Contents/Resources/StreamingAssets/Videos` (MacOS). Ensure it is encoded with **vp8** video, and **libvorbis** audio.

You can do this with ffmpeg like so (from within the Videos folder):
`ffmpeg -i uk_museum_ingame.mp4 -c:v libvpx -crf 10 -b:v 8M -c:a libvorbis uk_museum_ingame.webm`

You can install ffmpeg using most Linux distributions' package managers, and/or [Brew](https://formulae.brew.sh/formula/ffmpeg) on MacOS.

## Building

Note: I don't use Visual Studio, so I have no clue how to compile this on Windows, though using `msbuild` should be possible. As for MacOS, the file structure is different, but by editing the .csproj file to have correct file names, you should be able to build it with `msbuild`, just like Linux, assuming you have Mono installed.

### Dependencies

* A copy of ULTRAKILL with BepInEx 5.4.21 installed.
* A stripped copy of `Assembly-CSharp.dll` from your copy of ULTRAKILL, located in `ULTRAKILL_Data/Managed/Stripped`.
* (Linux) Mono / `msbuild`.

### Instructions

1. Clone the repo with git. (`git clone https://github.com/coatlessali/UltraNixVideoFix.git`)
2. Enter the directory. (`cd UltraNixVideoFix`)
3. Build project, with `ULTRAKILLPath` set to the path to your copy of ULTRAKILL. (`msbuild NixVideoFix.csproj -p:ULTRAKILLPath=/path/to/your/ULTRAKILL/`)
4. Copy `bin/Debug/NixVideoFix.dll` to your BepInEx folder, if `msbuild` doesn't do it for you.
