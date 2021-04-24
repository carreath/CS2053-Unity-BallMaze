# CS 2053: Final Report for RUBIK ESCAPE!

#### Winter 2020

#### Current & Original Group Members:

#### Conor Hennessy

#### Caleb Reath

#### Adalgisa Ferrer

#### Moses Cruz

## 1. Game Design Requirements

_Describe in the following sections how your game meets/supports each of the following project_

#### requirements:

#### 1.1. Story Telling. The game should contain storytelling with audio or text narration.

```
Our game primarily uses text-based storytelling. It involves dialogue of the
antagonist directed at you, the player. The story elements added by the antagonist will be
```
#### tutorials for new elements added in future levels.

#### The synopsis of the story is as follows:

- _The Cube King has taken you (the top Spherical General of the Revolutionary_
    _Army) captive after a long and fierce battle in the war of shapes. To ensure he is_
    _able to maintain his “edge” in the war the King knows he must squeeze every bit_
    _of information out of you. To accomplish this task the Cube King employs his top_
    _cube scientist Rubi K... Rubi K. has developed a rigorous set of “impossible”_
    _puzzles with the help of the top_ **_edgechelon_** _of cube interrogators. These puzzles_
    _will break any sphere that rolls in. Will they break you? Or will you escape and_
    _finish the war once and for all?_

```
The game begins with a short introduction to the interrogation torture chambers.
These chambers are cubic and edge filled rooms which would leave any normal sphere
wallowing in their pointless existence offering everything they know to get out. Then the
player must progress through increasingly difficult levels. Where different levels offer
different challenges. Eventually, when they reach the end of the last level a short outro
can be scripted to show the player’s sphere escaping and defeating the Cube King once
```
#### and for all.

#### The player will be represented by the wellbeing of their spheroid character.

#### Characters:

#### Cube King // Dark Red


#### Rubi K. // rubik cube

#### Player // vibrant blue

```
1.2. The number of levels. The game should be a multi-level/scene game with 2N scenes
(where N is the number of teammates). How many levels do you have and what do they
```
#### represent?

#### 8 Scenes/Levels

#### What the following levels represent

1. _Introduction_ : setting out how the player got stuck in the puzzle
2. _A basic tutorial level_ :
3. _Level 1_ : Another tutorial maze with a new game element, bouncy walls.
4. _Level 2_ : Continuation of bouncy walls but harder
5. _Level 3_ : Continuation of the story where a new game element is introduced
    - A laser emitter that tries to hit players
6. _Level 4_ : Continuation of emitter level but harder
7. _Level 5_ : New game element introduced: Gravity. Also, this is the final Level
    with Boss. Gravity affects how the player can control their ball.
8. _Outro_ : Finally an outro animation and credits level.

## 2. Game Programming Requirements

_Describe in the following sections how your game meets/supports each of the following project_

#### requirements (what parts of the game and how it was provided):

#### The project and resulting game must include the following game programming technologies:

```
2.1. Sound (note that if your game did not contain sound because of limitations in the lab
```
#### computers, please comment on this here).

Voice for characters, sounds for ball such as rolling sound for ball, falling sound for ball,

#### hitting sounds against walls, hitting sounds against bouncy walls and Ambient music.

#### 2.2. Physics

```
The ball itself has physics to roll and move around the board. The board has physics to move
and tilt with the user’s keypresses, the board tilts down the direction pressed and then
```
#### returns to the neutral position when no keys are pressed.

```
Additional game components of bouncy walls, emitters, the boss character and other
```
#### objects all have respected physics technology for their own functions.

#### 2.3. Cameras: should have dynamic (or multiple)

#### The camera follows the player as they wobble around the maze.


```
The camera moves dynamically as the camera follows the ball to transition through an
```
#### obstacle or goal holes.

#### 2.4. User Interface (menu).

#### Dialogue is shown throughout the game at the start of every scene and level.

#### The user interacts with this to remove a piece of dialogue with each level.

```
2.5. AI: AI game objects must have state-based behaviours and involve pathfinding. Note that
for this point, you can use those provided by the game engine/platform which you will use
for the project development and/or write your own. We removed the requirement for AI,
```
#### but if you have some AI in your project, you may describe it here.

#### We do not have a UI component to our game.

### 3. Describe what parts of the game you attempted to build or

### wanted to build, but were unable to

_Distinguish between the parts you were unable to implement, but would have satisfied a project
requirement, from parts that you wanted to add additionally to improve gameplay or play_

#### experience.

#### Parts that would have satisfied project requirements:

#### N/A

#### Parts for additional functionality:

#### Split gravity level and boss (level 5) into two separate levels

## 4. How successful were you?

#### Provide a description of how successful you were in creating a 'good' game with this project.

## There are no right or wrong answers, this is to help you reflect on your experience.

We were very successful, we got a lot done, and we were able to implement all the features we

#### wanted to. We worked as a team and were able to pull of a working game.


### 5. Describe how you were able to work remotely with

## your team or individually.

_Did you have any challenges? What worked well? Would you do something differently in the_

#### future?

We encountered major issues with working remotely. With two of our group members being
international students, they both had to organise, move and relocate back to their home countries
with limited support. Then expected to settle down and continue all projects and assignments with

#### minimal changes, other than a change of deadlines.

With this development for all courses, including CS2053, was affected and slowed and so the

#### expected level of input may not have been achieved.

We also experienced problems due to all group members having additional new commitments,
may it be work to support themselves or supporting family. Additionally, we now had a 4-hour time

#### difference where we would normally be able to meet up and complete tasks.

With all this, we were able to complete something that meets our original project proposal and is

#### overall fun to play.

With regards to doing something differently in the future, not much can be changed with regards
to logistics in light of the current situation. But I would change the course requirements if possible.
As assuming the learning objectives of the course have been achieved, some components could
be dropped, this would have been the easiest way to reduce workload, expectations and stress

#### on the team.

### 6. Describe what external/third-party resources (or asset

## packs) you used

_Please describe what third-party resources/scripts/objects/music/sprites/etc. you used, what
functionality/features they provide and how you used them? You can provide URLs for important_

#### libraries/assets, but leave out simple sprites.

- Sound:
    o Ball roll sound: https://www.youtube.com/watch?v=4nI4xOBgshw
- 3D Models:
    o Blender: the hole and black hole (Caleb Reath)
    o 3DStudio Max: Game Characters (Carlos Ferrer Genao)
- Font:
    o ‘Bubble Font’ from the Unity Asset Store. Creator: Jazz Create Games
    o https://assetstore.unity.com/packages/2d/fonts/bubble-font-free-version- 24987
The sound was used every time the ball was moving to create a better user experience when
playing. The font was just used for the aesthetic of the game and the 3D models were used for

#### the intro and outro of the game, just to put some ‘faces’ to our characters.


