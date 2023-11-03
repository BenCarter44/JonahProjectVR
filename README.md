# JonahProjectVR

### [See the project report here](https://codingcando.com/fileShare/file?code=bibleProjectVR)


---
## About

This project consists of a VR simulation of Jonah and the Whale from the Bible. The user goes back in time to a stormy sea and is swallowed by a whale. After that, instead of the user going to Nineveh, the user finds himself in a college dorm. The user is faced with a question: Will he study for his exam, or spend his time goofing off with friends?

The user decides to run away from his much need-to-be-done homework to go be with friends. Along the way, his homework chases him down and swallows him. This sends him back to the dorm. If the user studies for the exam, the user is teleported to his class to discover that he aced the exam!

This project was a project that my team and I created for our CST-320 class. This class is titled "Human-Computer Interaction and Communication Lecture & Lab". This class focuses on modern ways users can interact with a virtual world--namely VR. This class is also a project management class, teaching storyboarding and project development. This repository contains our work for this project. We hope you enjoy it!!

Thank you,
The team.

## Download instructions.
This repository uses Git LFS. The LFS server is [Ben's RPi-based server](https://codingcando.com/) back at his house. 

To download:
- Clone the [repository](https://github.com/BenRobotics101/BibleProjectVR)
- When you clone it, it will appear to "hang" when pulling. It will work! When it is "hanging" is really when it is downloading the large assets from the Git LFS. The failure to see feedback is a bug present in Git LFS.
- Build Settings should be up to date. Should be able to simply press build and run. 
- The scenes may not appear immediately on project load, so you may have to go the scene asset of your choosing in the `Assets/Scenes/` folder. 

**ONE IMPORTANT NOTE: There is one file that is "too big" for git. To solve that, you will find a map.obj.zip in the Assets/Models/Buildings/gcumap5/ folder. Please unzip this after cloning.**

---
## To Install
This project is a XR Unity Project.

> - Unity Version: 2021.3.9f1
> - Oculus XR Plugin 3.0.2
> - OpenXR Plugin 1.4.2
> - XR Interaction Toolkit 2.2.0
> - XR Plugin Management 4.2.1

You will have to make sure it is set to **build on Android** (to run on an Oculus headset). Also, the build settings should match the below. The scenes are in the `Assets/Scenes/` folder.

**When you first open the project, no scenes will appear on project load! You will need to navigate to the scene of your choice (use the scenes below in build settings) to view it.**

**Build settings:**
1. `Scenes/SplashScreenStart 1` - # 0
2. `Scenes/Help` - # 1
3. `Scenes/Scene0` - # 2
4. `Scenes/Scene2` - # 3
5. `Scenes/Scene3` - # 4
6. `Scenes/Scene3b` - # 5
7. `Scene/Scene4` - # 6

**The build must be set to Android.**

## Cybershoe note
This game does not require the Cybershoes. The player can move also with the joystick.
However, the project already includes support for Cybershoes by default. Check the Cybershoe documentation to see setup instructions. Here below is a brief overview:

1. Attach the Cybershoe receiver to the back of the Oculus headset. Connect the receiver to the headset to receive power. 
2. Follow the binding instructions to connect the receiver to the headset. Hold down the black button on the receiver until the two lights are alternating. 
3. Put on the Oculus headset and go to the Bluetooth settings. Pair with the Cybershoes device that will appear.
4. Then, unplug the receiver and plug it back in.
5. It should be all set. Turn on the Cybershoes and point your feet in the same direction as the headset. Then, press the button on the receiver briefly. This calibrates the Cybershoes with the orientation of the VR headset. You only need to do this on Cybershoe powerup. The two lights on the receiver should be blinking blue rapidly.

