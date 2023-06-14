# Back to the Jungle

[![GitHub Super-Linter](https://github.com/ensemble-ai/exercise-4-factory-pattern-beanbeanjuice/workflows/Lint%20Code%20Base/badge.svg)](https://github.com/marketplace/actions/super-linter)

---

## Summary

**A paragraph-length pitch for your game.**

## Gameplay Explanation

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**

**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

---

## Main Roles

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content.

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at runtime via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course.
[The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

### User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

### Movement/Physics - [William][william-github]

[william-github]: https://www.github.com/beanbeanjuice
[movement-script]: https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Player/PlayerMovementController.cs

Movement in this game was very simple. It was pretty much, move to the right at an initial velocity with constant acceleration, with the camera stuck to the same X position as the player.

The specific script I wrote for player movement is located [here][movement-script].

There were some things I added, however, that made the movement feel more fluid...

#### Removal of Upwards Velocity
https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Player/PlayerMovementController.cs#L80-L90
The above code was specifically to remove the upwards velocity when touching the ceiling. With the way Unity works, this would mean when we let go of the "fly" button, it would take a portion of a second for the player to start falling down as it's upwards velocity was above 0.

#### Ground Checker
https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Player/PlayerMovementController.cs#L98-L119
The above code is not only to help with the next bullet-point, but to also help the **Animation and Visuals** team to animate the mount/player. Simply checking for a collision with the ground wasn't enough, as when the ground was duplicated, *to allow for infinite scrolling*, because of how the `BoxColliders` overlapped slightly, would cause this sequence of events.
* Player Touches Ground 1 (`IsGrounded() == true`) => Player Touches Ground 2 (`IsGrounded() == true`) => Player Leaves Ground 1 (`IsGrounded() == true`).
* So, to solve it, `Physics2D.BoxCast` is used, the logic of which is explained in the comments of the code above.

#### Gravity Physics and Fly Physics
https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Player/PlayerMovementController.cs#L27-L43
Something to note; by convention, movement is usually in `Update()`. However, because our movement is based on physics, the physics portion of movement should be in `FixedUpdate()`.
 * This was a bug I did not figure out until later on because my PC ran the game at 1600 FPS, which would cause the player to move upwards very quickly, but my team mates ran at a lower FPS, which would cause the player to not fly at all.

Overall, even though it was pretty easy, it was still a learning experience. In class, there was a lot of theory about how the game is supposed to *feel*, and by utilizing what I learned in class, there's a lot more to a game than just "add upwards boost" or "stop adding upwards boost" but instead, all of the small details that add up to a whole. Had I not added the upwards velocity removal when touching the ceiling, the player would feel sluggish and off.

### Animation and Visuals

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

### Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

### Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

---

## Sub-Roles

### Producer - [William][william-github]

#### Git Branching
Some things I had as producer was ~~attempting~~ to make the `git` branches run smoothly. Right when the GitHub branch was created, I created the file [CONTRIBUTION.md](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/CONTRIBUTION.md). In the file, it had this image;
<p align="center">
  <img src="/github_images/branches.png" width="400"/>
</p>

From the [issue history](https://github.com/beanbeanjuice/back-to-the-jungle/issues?q=is%3Aissue+is%3Aclosed), you can see that the intention was that each person on our team would work solely on implementing the specific issue we were tasked with working on. If all was going well, we should be able to work on branches without needing to `rebase` or `merge` until a `pull request` was created. This way, we can avoid `merge conflicts`. However, this way, while safe, did cause slow down with some of my team members as this was the first time they were exposed to something like this. Therefore, it was in best interest for the sake of time to forego this and work more quickly. However, we did have some merge conflicts I did then need to fix.

#### Timeline
As producer, I also created a [Gantt Chart](https://docs.google.com/spreadsheets/d/1daxQZKiFalyhVolWCPxCEILbFaG9LCLo/edit?usp=sharing&ouid=112531617366563364567&rtpof=true&sd=true) for everyone to use at their discretion. By adding things in here, in addition to the GitHub issues, we were able to keep track of all the things we have done/completed.

#### GitHub Usage
As stated before, we utilized many of GitHub's features such as `tags`, `issues`, and `pull requests`. This allowed us to keep track of what does what, whether it is a `BUG`, `FEATURE`, or `IMPROVEMENT` as well as which role that specific issue belonged to. As for our [pull request history](https://github.com/beanbeanjuice/back-to-the-jungle/pulls?q=is%3Apr+is%3Aclosed), the original intention was to disallow merging until at least 2 other members of the team had reviewed and approved the code. Not only would this have prevented merge conflicts and issues later one, but would have made the code easier to read. Again, we chose to forego this toward the middle as it was causing slowdown, but also caused a lot of issues regarding code readability later on.

Additionally, I utilized a [GitHub Actions Script](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/.github/workflows/super-linter.yml) that I modified in order to check for linter errors. While this has been failing consistently since we decided to ignore it for the sake of completing the task on time, I will go back and fix any linting errors once everyone has pushed their code.

Also, I utilized templates for issues and pull requests. For the pull request template, you can see an example [here](https://github.com/beanbeanjuice/back-to-the-jungle/pull/144). For the issues, see the images below;

<p align="center">
  <img src="/github_images/project_document_images/producer/issue_templates.png"/>
  <img src="/github_images/project_document_images/producer/feature.png"/>
  <img src="/github_images/project_document_images/producer/improvement.png"/>
  <img src="/github_images/project_document_images/producer/bug.png"/>
</p>

By using these templates, it made it easier to view, at a glance, exactly what the issue completes/fixes and which role should be working on that issue.

Overall, it was my first time working in a group setting like this for a project of this size. I had originally worked on my own project [cafeBot](https://www.github.com/beanbeanjuice/cafeBot) which implements everything I have already stated above. It helps me in my own workflow, which is why I used it for this project as well.

##### Extra Additions

Additionally, I also created a section called [**Notable Completions Outside of Role**](#notable-completions-outside-of-role) [here](#notable-completions-outside-of-role) which highlights some of our completions that were not part of our assigned roles.

### Audio

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.**

### Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

### Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.**

### Press Kit and Trailer - [William][william-github]

*Links*: [Press-Kit](./press_kit/press_kit.md), [Trailer](https://youtu.be/_5Re1wy7m1A)

#### Trailer
<p align="center">
  <img src="/github_images/project_document_images/press_kit_and_trailer/trailer_timeline.png"/>
</p>

The trailer timeline in the video editing program I used, **Adobe Premiere** was not at all complex compared to the other types of content I am used to making.

I think the premise of the video is good, I tried to show all of the *gameplay* aspects of the game as well as including the motivation for why the player is on a dinosaur. I put the types of enemies/collections that are part of the game, as well as the "goals" of the game.

I tried to keep it short, **around 1 minute long**, but in fact, I feel as though I should have made it shorter. I tried to make the trailer a bit funny, including a small IRL portion, but I think it just did not hit the mark.

The credits for the VFX and music used in the trailer are [here](./github_images/project_document_images/press_kit_and_trailer/trailer_credits.md).

#### Press-Kit
For the press-kit, I included things that I know I would like to see when I am looking at a new game;
* [Price, Supported Platforms, Game Type](./press_kit/press_kit.md#back-to-the-jungle)
* [Story Description](./press_kit/press_kit.md#why-run)
* [Trailer](./press_kit/press_kit.md#trailer)
* [In-Game Images](./press_kit/press_kit.md#awesome-images)
* [Scenes](./press_kit/press_kit.md#scenes)
* [Concept and Inspiration Images](./press_kit/press_kit.md#concept-and-inspiration)
* [About the Programmers/Designers](./press_kit/press_kit.md#about)

Essentially, what I included in the press-kit were more specific versions of things I already included in the trailer. I wanted to show our motivation for the game, what initial concepts and inspirations looked like, and how our final game looks like and plays.

I wanted to include a link to the "developer diaries" that some of us wrote for each of our roles, which are linked at the bottom of the press-kit. They are essentially what we are thinking during development, stuff we fixed, and how we fixed it.

### Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**

---

## Notable Completions Outside of Role

### Member: [William][william-github]
I worked on quite a few small things throughout the project. All of my minor and major contributions can be found on my [developer log](./developer_logs/William.md), but the one that took up the bulk of my time was everything to do with the `fish` which is the main currency of our game. This includes [FishFactory.cs](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Fish/FishFactory.cs), [FishBindings.cs](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Fish/FishBindings.cs), [FishController.cs](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Fish/FishController.cs), [FishPattern.cs](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Fish/FishPattern.cs), [FishSpec.cs](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Fish/FishSpec.cs), and [FishType.cs](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Fish/FishType.cs).

Specifically, it took me a very long time to implement the fish in a way that would allow easy modification, easy patterns, and to get it to work with WebGL. The way the fish would spawn was instead of creating prefabs for each of the individual fish, any member of my team could just create a pattern, and that would automatically start spawning that pattern in the game. For example, there is a "BEAN" pattern or a heart-shaped pattern.

My struggle when first implementing the fish started on [this](./developer_logs/William.md#may-30-2023) developer log. It was "easy" to make patterns of fish, but what an artist or developer would have to do, was create the pattern in Microsoft Excel, then translate that pattern into relative XY coordinates for the game. This is easy, but *very* tedious, especially if the pattern of fish you are trying to spawn has 30+ fish.

To fix the tediousness, the professor suggested I added a way to translate Microsoft Excel sheet data automatically. At first, I did not want to do this as I had experience doing this before, and knew it was tedious, but I gave in because it was annoying the way you had to add the XY coordinates of the fish each individually. My struggles are highlighted in [this](./developer_logs/William.md#june-9-2023) developer log.

However, in the [next](./developer_logs/William.md#june-12-2023) developer log right after that, we discovered some errors when trying to export into a WebGL game. Turns out, WebGL does **not** support `System.IO` interactions. I thought I would have to scrap the Excel idea entirely, or at least not export into `WebGL`. However, I had an epiphany and decided to figure out a way to complete it. This is all explained in the developer log.

To complete my objectives, I needed to add a few [Editor Scripts](https://learn.unity.com/tutorial/editor-scripting). The [ExcelImporter.cs](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Editor/ExcelImporter.cs), and [FishFileReader.cs](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Editor/FishFileReader.cs) are scripts for the editor that allow the automatic import and conversion of the [fish_patterns.xlsx](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Resources/Patterns/Fish/fish_patterns.xlsx) file into a readable Unity object. I added instructions [here](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Resources/Patterns/Fish/How%20to%20Add%20Fish%20Patterns.md) for how to actually add new fish patterns. It is as simple as drawing it out in the excel sheet, saving the file, then re-importing the excel sheet.

Again, my process is mostly explained in my developer log, located [here](./developer_logs/William.md).

#### Fish Bindings Asset Menu
https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Fish/FishBindings.cs#L6-L53

By creating an asset menu, it's easy to choose which fish sprites are allowed to be used. I took inspiration from the asset menu from **Exercise #3**.

#### Fish Patterns Asset
https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Editor/ExcelImporter.cs#L10-L46

https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Fish/FishPatternsAsset.cs#L5-L28

Since Unity cannot read the binaries of an Excel sheet from `Resources.Load()`, I had to get creative. I "faked" it upon import, by converting the binaries to a readable format for Unity using an editor script. This allows easy edit-ability while also being directly compiled into the game. Therefore, no `System.IO` is needed for the compiled game. This is a bit of a work-around, but I honestly think this is a good way to do it. No overhead is needed for the person running the game, only for us developers when compiling.

#### Excel File Reader
https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Editor/FishFileReader.cs#L11-L158

I had to learn a lot for this portion; downloading external binaries into Unity and how to use said binaries. I ended up using `NuGET` which made the process somewhat simple, but definitely not painless. There does not seem to be a lot of tutorials/user-created documentation on `EPPLUS`, which is the library I used for reading Excel files, so I had to read from documentation directly.

A lot of functions like [ConvertPosition](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Editor/FishFileReader.cs#L143-L147), [ReadSheetValue](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Editor/FishFileReader.cs#L149-L152), and [GetCellHex](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Editor/FishFileReader.cs#L154-L157), simply exist to make the code more readable. Excel doesn't always start from index = 0. Most of the code is commented and self-explanatory.

Overall, if there was only one thing I could show from this project, it would be my work on spawning the fish in. It was a lot of work, a lot of debugging, but ultimately I am very satisfied with how it turned out.
