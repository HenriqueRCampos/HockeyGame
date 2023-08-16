# HockeyGame
This game is inspired at Air Hockey table game.
It's a 2D game, that I made to pratice and improve my knowledge in Game Development.

![HockeyGame](https://user-images.githubusercontent.com/107483658/230206480-e4411338-8088-4f51-9441-ceaa4c04131a.png)

## About
- Made for Android system. Played with touch screen.
- You play versus a [bot](HockeyGame/Assets/scripts/GameScripts/Bot.cs).
  - He chases the ball when it passes into his side. While the ball is on the player's side, the [bot](HockeyGame/Assets/scripts/GameScripts/Bot.cs) backs up a bit and waits until find it again. He always goes towards the back of the ball, in order to be able to kick in the direction of the player, it hasn't difficult, but he changes his speed and kicking strength each time he kicks the ball.
  > It make the game more dynamic, being able to surprise the player and prevent the [bot](HockeyGame/Assets/scripts/GameScripts/Bot.cs) has a pattern.
- Player and the [bot](HockeyGame/Assets/scripts/GameScripts/Bot.cs) has a movement area limit, preventing that invade adversary's side. Case the player try it, his disc be stuck at center line.

- The maximum score is 3 goals and the match hasn't limit time.

<div align="center">
    <img src= https://user-images.githubusercontent.com/107483658/230387565-e48128b2-4a34-4597-9b49-3d3a6f37e3c5.png width=500px />
</div>

<div align="center">
    <img src= https://user-images.githubusercontent.com/107483658/230357698-9063c1bf-65cd-469f-8f39-b2e5fb2897fb.png width=383px />
    <img src= https://user-images.githubusercontent.com/107483658/230393265-acea757e-6113-4763-873e-19282107cc41.gif width=425px />
    
</div>
