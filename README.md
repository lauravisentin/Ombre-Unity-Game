# Ombre

**Ombre** est un jeu d’horreur et d’énigmes développé en équipe avec Unity et C#. Le joueur y explore un univers inquiétant, résout des énigmes et tente d’échapper à un monstre. Le jeu comprend une scène d’introduction, une scène de jeu, une scène de fin et des checkpoints.

Les scripts ci-dessous montrent quelques aspects de ma contribution au projet. Ils ne couvrent pas tout le jeu, qui a été réalisé en équipe.

## Captures du jeu

Ajoutez ici des GIFs ou des captures d’écran du jeu :

<!-- Exemple : ![Le joueur explore une salle](media/exploration.gif) -->

<!-- Exemple : ![Interface du terminal](media/terminal.png) -->

## Scripts présentés

### `TexteTerminal.cs`

Ce script affiche des textes liés au terminal et à certains événements du jeu.

- Il affiche une séquence de deux textes lorsqu’une interaction avec le terminal est signalée par `JoueurCollisions`.
- Il affiche un texte associé au checkpoint du laboratoire et un autre lorsque l’énergie est rétablie, une seule fois pour chacun de ces événements.
- Le texte apparaît lettre par lettre, avec un délai configurable. Un son est joué pendant cette animation.
- Il masque les indications de déplacement dès que le `CharacterController` du joueur se déplace suffisamment.

Ce script montre l’utilisation d’une classe Unity dérivée de `MonoBehaviour`, de variables publiques configurables dans l’Inspector, de conditions et de méthodes. Il emploie aussi des coroutines pour séquencer les messages et leurs délais, ainsi que des composants Unity et TextMeshPro pour relier le comportement à l’interface et au joueur.

### `RecuperationDonnees.cs`

Ce script gère une interaction de récupération de données sur un ordinateur.

- La progression n’est disponible que lorsque l’énergie est rétablie et que le joueur est signalé comme étant à l’ordinateur.
- Tant que la touche **E** est maintenue, une barre de progression augmente et le pourcentage est affiché. Un son accompagne la progression.
- À 100 %, le script affiche un rapport, désactive certaines indications d’interaction et active l’aimant visuel et l’état correspondant dans `JoueurCollisions`.
- Lorsque la progression est terminée, un message de sauvegarde apparaît brièvement.

Ce script met en pratique les variables d’état, les conditions, les méthodes et une coroutine temporisée. Il relie plusieurs composants Unity — notamment un `Slider`, des objets d’interface, un `AudioSource` et d’autres scripts — et utilise `Time.deltaTime` pour faire évoluer la progression au fil du temps.

### `GestionScenes.cs`

Ce script gère les fondus visuels et audio et contient les actions associées aux boutons de l’interface.

- Au démarrage, il lance un fondu d’entrée qui révèle la scène et fait monter le volume sonore.
- La méthode `CommencerJeu`, prévue pour être reliée au bouton « Commencer », lance un fondu puis charge la scène nommée `ImagesDebut`.
- La méthode `QuitterJeu`, prévue pour le bouton « Quitter », arrête le mode Play dans l’éditeur Unity ou ferme l’application dans une version compilée.

Ce script illustre les méthodes publiques reliées à l’interface, les coroutines pour répartir une transition sur plusieurs images, ainsi que l’usage de composants `Image` et `AudioSource`. Il s’appuie également sur `SceneManager` pour charger une scène.

### `DontDestroyManager.cs`

Ce script conserve une seule instance de `DontDestroyManager` lors des changements de scène. La première instance reste active; les suivantes sont détruites pour éviter les doublons.

Ce script montre l’utilisation d’une variable `static` pour partager une référence entre les instances, de la méthode Unity `Awake` et de conditions pour éviter les doublons. Il utilise aussi les fonctions Unity de persistance et de destruction d’objets.

## Compétences mises en pratique

Le projet m’a permis de pratiquer l’organisation de comportements en C#, la gestion d’états et d’interactions, ainsi que la liaison de scripts aux éléments d’une scène Unity. Ce sont des bases utiles pour construire des fonctionnalités modulaires et faire collaborer les différentes parties d’un logiciel.

## Technologies

- Unity
- C#
- TextMeshPro
