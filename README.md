# Ombre

**Ombre** est un jeu d’horreur et d’énigmes réalisé en équipe avec Unity et C#. Le joueur explore un univers inquiétant, résout des énigmes et tente d’échapper à un monstre.

Le jeu comprend une introduction, une scène de jeu, une fin et des checkpoints. Les scripts ci-dessous présentent quelques éléments de ma contribution.

## Découvrir le jeu

J’ai créé une présentation visuelle pour raconter l’histoire d’**Ombre** et vous donner un aperçu de son univers.

[**Voir la présentation du jeu sur Figma →**](https://www.figma.com/proto/sj9LXBQB8dzsNBnVJ0dQeo/Ombre?page-id=0%3A1&node-id=6-5&scaling=scale-down-width&content-scaling=fixed)

## Scripts présentés

### `TexteTerminal.cs`

Affiche les messages du terminal et certains événements du jeu.

- Présente les textes lettre par lettre, avec un son.
- Affiche des messages liés au checkpoint et au rétablissement de l’énergie.
- Cache les indications de déplacement quand le joueur bouge.

**C# pratiqué :** coroutines, conditions, variables configurables et composants Unity.

### `RecuperationDonnees.cs`

Gère la récupération de données sur un ordinateur.

- Fait progresser une barre lorsque le joueur maintient **E**.
- Affiche le rapport et met à jour l’état du jeu à 100 %.
- Utilise un son et affiche brièvement un message de sauvegarde.

**C# pratiqué :** variables d’état, méthodes, coroutine et `Time.deltaTime`.

### `GestionScenes.cs`

Gère les fondus et les boutons de l’interface.

- Anime l’image et le volume sonore au démarrage.
- Lance la scène `ImagesDebut` avec le bouton **Commencer**.
- Ferme le jeu avec le bouton **Quitter**.

**C# pratiqué :** méthodes publiques, coroutines et `SceneManager`.

### `DontDestroyManager.cs`

Garde une seule instance du gestionnaire active entre les scènes.

**C# pratiqué :** variable `static`, méthode `Awake` et gestion d’objets Unity.

## Compétences mises en pratique

- Programmation C# dans Unity
- Gestion des interactions et des états
- Liaison entre scripts, interface et objets de jeu

## Technologies

Unity · C# · TextMeshPro
