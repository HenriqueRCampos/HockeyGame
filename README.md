# HockeyGame
Este jogo é inspirado no jogo de mesa Air Hockey.
É um jogo 2D de estudo, que fiz para ganhar mais conhecimento e pratica, com o objetivo de melhorar o meu Desenvolvimento de jogos, tanto em programação como
no gerenciamento da plataforma Unity3D.

![HockeyGame - Game - Windows, Mac, Linux - Unity 2021 3 16f1 Personal_ _DX11_ 05_04_2023 16_56_47](https://user-images.githubusercontent.com/107483658/230206480-e4411338-8088-4f51-9441-ceaa4c04131a.png)

## Sobre
- Com uma build para Android. O jogo tem como base jogar em uma tela touchscreen.
- Você joga contra um [bot](HockeyGame/Assets/scripts/GameScripts/Bot.cs).
  - Ele persegue a bola quando ela passa para o lado do campo dele. Em quanto a bola esta do lado do jogador, o [bot](HockeyGame/Assets/scripts/GameScripts/Bot.cs) recua um pouco para trás e espera até encontra-la 
  novamente. Ele sempre vai em direção a parte de trás da bola, para assim conseguir chutar na direção do jogador, não possui dificuldade, mas
  ele altera a sua força de chute e a sua velocidade, a cada vez que chuta a bola.
  > Isso torna o jogo mais dinâmico, podendo surpreender o jogador e evitar que o [bot](HockeyGame/Assets/scripts/GameScripts/Bot.cs) tenha um padrão.
- O jogador e o [bot](HockeyGame/Assets/scripts/GameScripts/Bot.cs) tem um limite na área de movimento, impedindo que invadam o campo do adversário. Caso o player tente invadir, o seu disco fica travado na linha central do campo.

- O placar maximo é até 3 gols e não contem tempo limite na partida.

<div align="center">
    <img src= https://user-images.githubusercontent.com/107483658/230387565-e48128b2-4a34-4597-9b49-3d3a6f37e3c5.png width=500px />
</div>

## Design
O campo foi feito com cantos curvos para evitar com que a bola ficasse presa, fazendo com que ela deslize ou rebata em alguma direção.
Atrás do gol possui uma caixa de colisão, que detecta a colisão com a bola ocasionando no:
  - Acionamento da particula dentro do gol;
  - UI "GOOOOLLLL";
  - Acrecentando ponto no placar;
  - Destruindo a bola;
  - Instanciando uma nova bola;

<div align="center">
    <img src= https://user-images.githubusercontent.com/107483658/230357698-9063c1bf-65cd-469f-8f39-b2e5fb2897fb.png width=383px />
    <img src= https://user-images.githubusercontent.com/107483658/230393265-acea757e-6113-4763-873e-19282107cc41.gif width=425px />
    
</div>
