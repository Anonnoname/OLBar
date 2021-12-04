# OLBar

An Online Chatting Bar. Feel free to play!

# Project Description

Our project is called “Valhalla Bar”. The point of “Valhalla Bar” is to create a space and chatroom for users to communicate and interact with each other, specifically in this time of COVID-19. In “Valhalla Bar” users can create their own avatar, chat with other users, drink at the bar, and play games like the dart game. 

# **Requirements & Specifications:**

Supported Platforms: Windows or Mac OS
You can: Run and play!You can directly play the game by running the executable in the folders. We pre-build the project for the Windows x86 platform and Mac OS platform. You can find the zipped games . Or, 
Compile the projectDownload Unity 2020.1.4.1f Choose File > Build and Run

# Process

### Iteration development:

- Iteration 1

  - Goals
    - Improve UML class diagram for Login and Chat and;
    - Implement login and;
    - Implement part of the chat backend structure.
  - Encountered Issues
  - Explanation
    - For this iteration, we already have our first version of UML class diagrams for each class. And we decided to start with the elementary ones, improve the class diagram design and start to implement. That’s why we choose login and chat parts, they are the fundamental parts of our whole projects.

- Iteration 2

  - Goals
    - Create first version of dart game and;
    - Merge chat, movement and interaction with environment and;
    - Create sanity system and;
    - Draw the scratch of the background, basic figures and some assets and;
    - Made the drinking system, and drunk effect.
  - Encountered Issues
    - The scratch of the background does not fit well with the main camera, and needs to break down pixel arts into pixel units.
  - Explanation
    - We had our chat and login class implemented during the last iteration, and we distributed work to each member during this one. We separately implemented a “movement” class, created the sanity system, created drunk effects and created the first version of UI.

- Iteration 3

  - Goals
    - Finalize dart game and;
    - Create bar and environment Interaction and;
    - Create the drink ordering system including UI and code and;
    - Create full bar background (pixel) and;
    - Create two characters with full movement images and;
  - Encountered Issues
    - Massive git conflict due to the not-well managed file systems and structures. Needs refactoring.
  - Explanation
    - We have each of the classes built separately in the last iteration, and the main purpose of this iteration is to gather them up, finish the demo game and run the test. This iteration is where refactoring, testing happened.

  ###  Refactoring

  Code refactoring happened at the last iteration of our project before the presentation. Our whole code structure is based on Unity engine. After the code review, we found out that the code itself is relatively well-structured and easy to understand, so in this phase, our main purpose is to restructure the code file so it would be easier to manage. The main issue we encountered during the development was that there were too many folders without clear marks, and there were even duplicate code files, which often led to errors while we used git. So we did a restructuring of all our code files so it could be easily accessed and no duplicates involved. This process makes our future modifications much easier and accessible.

  ### Testing

  Because our project is more like a game, so we do not have automated tests. Our main testing goal is make sure that our game function and logic is working well. Valhalla Bar is a multi-player online game, so the logic is a little bit more difficult than a local game. We need to make sure that for each user logging into the server, they not only need to function well, but also the players they see in the bar need to function well, too. The issue we ran into during the testing phase is that we found out the user was working well, however the other players were acting strange in the scene. So we worked on fixing this problem by checking the whole logic of the structure.

  ### Collaborative development

  We have a meeting every week to discuss either the purpose of the next iteration or the results of the ongoing iteration. We will listen to each other’s ongoing process and give suggestions. If one of us has an issue, we will work on it together to make it easier and faster. Also we use Wechat to communicate when there is any issue or idea popping up.
