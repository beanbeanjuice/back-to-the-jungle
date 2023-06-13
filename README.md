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

##### Removal of Upwards Velocity
https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Player/PlayerMovementController.cs#L80-L90
The above code was specifically to remove the upwards velocity when touching the ceiling. With the way Unity works, this would mean when we let go of the "fly" button, it would take a portion of a second for the player to start falling down as it's upwards velocity was above 0.

##### Ground Checker
https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/Jetpack/Assets/Scripts/Player/PlayerMovementController.cs#L98-L119
The above code is not only to help with the next bullet-point, but to also help the **Animation and Visuals** team to animate the mount/player. Simply checking for a collision with the ground wasn't enough, as when the ground was duplicated, *to allow for infinite scrolling*, because of how the `BoxColliders` overlapped slightly, would cause this sequence of events.
* Player Touches Ground 1 (`IsGrounded() == true`) => Player Touches Ground 2 (`IsGrounded() == true`) => Player Leaves Ground 1 (`IsGrounded() == true`).
* So, to solve it, `Physics2D.BoxCast` is used, the logic of which is explained in the comments of the code above.

##### Gravity Physics and Fly Physics
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

##### Git Branching
Some things I had as producer was ~~attempting~~ to make the `git` branches run smoothly. Right when the GitHub branch was created, I created the file [CONTRIBUTION.md](https://github.com/beanbeanjuice/back-to-the-jungle/blob/b5a6dbdcc7e14b19823f1a3edb895a864107f96e/CONTRIBUTION.md). In the file, it had this image;
<p align="center">
  <img src="/github_images/branches.png" width="400"/>
</p>

From the [issue history](https://github.com/beanbeanjuice/back-to-the-jungle/issues?q=is%3Aissue+is%3Aclosed), you can see that the intention was that each person on our team would work solely on implementing the specific issue we were tasked with working on. If all was going well, we should be able to work on branches without needing to `rebase` or `merge` until a `pull request` was created. This way, we can avoid `merge conflicts`. However, this way, while safe, did cause slow down with some of my team members as this was the first time they were exposed to something like this. Therefore, it was in best interest for the sake of time to forego this and work more quickly. However, we did have some merge conflicts I did then need to fix.

##### Timeline
As producer, I also created a [Gantt Chart](https://docs.google.com/spreadsheets/d/1daxQZKiFalyhVolWCPxCEILbFaG9LCLo/edit?usp=sharing&ouid=112531617366563364567&rtpof=true&sd=true) for everyone to use at their discretion. By adding things in here, in addition to the GitHub issues, we were able to keep track of all the things we have done/completed.

##### GitHub Usage
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

##### Trailer
For the link to the trailer, click [here](https://youtu.be/_5Re1wy7m1A).

<p align="center">
  <img src="/github_images/project_document_images/press_kit_and_trailer/trailer_timeline.png"/>
</p>

The trailer timeline in the video editing program I used, **Adobe Premiere** was not at all complex compared to the other types of content I am used to making.

I think the premise of the video is good, I tried to show all of the *gameplay* aspects of the game as well as including the motivation for why the player is on a dinosaur. I put the types of enemies/collections that are part of the game, as well as the "goals" of the game.

I tried to keep it short, **around 1 minute long**, but in fact, I feel as though I should have made it shorter. I tried to make the trailer a bit funny, including a small IRL portion, but I think it just did not hit the mark.

The credits for the VFX and music used in the trailer are [here](./github_images/project_document_images/press_kit_and_trailer/trailer_credits.md).

##### Press-Kit
For the link to the press-kit, click [here](./press_kit/press_kit.md).

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
