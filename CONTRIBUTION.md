# How to Contribute

---
# Branching

Right now, we have two major branches. The `master` and `integration` branches. 

* `master`
  * This is where we will keep the release version of our code. Everything here is where the code is pretty much final. By keeping this separate from where we are actually pushing our code, it can help us avoid issues where we push unsafe/unstable code into a branch that used to be working.
* `integration`
  * This is where we will mainly be branching off of. We should all be branching off of this branch and working on our specific needed implementations.

## Cloning
In order to contribute, we need to be able to make our own branches. This is how we do it.

1) Clone the repository.
  ```BASH
  git clone https://github.com/beanbeanjuice/ecs189L-back-to-the-jungle.git
  ```

2) Move into the cloned directory.
  ```BASH
  cd ecs189L-back-to-the-jungle
  ```

3) Switch to the `integration` branch.
  ```BASH
  git switch integration
  ```

4) If you were already in the `integration` branch, do the following code to make sure you are up to date with the latest features.
  ```BASH
  git pull
  ```

5) Navigate to [issues](https://github.com/beanbeanjuice/ecs189L-back-to-the-jungle/issues). If the thing you want to add is not specified in the [issues](https://github.com/beanbeanjuice/ecs189L-back-to-the-jungle/issues) yet, please add it.

6) Choose the issue you want to complete. There should be a number right next to the name of the issue. While in the `integration` branch, use that number, and the description of the issue to create a new branch. For example, this is what would be done below.
  ```BASH
  git checkout -b 3-implement-some-function
  ```

## Pushing and Pull Requests
Now that you have implemented changes on your local branch. This is how you create a pull request and push into origin.

1) Push your local branch onto GitHub.
```BASH
git push
```

2) Navigate to [pull requests](https://github.com/beanbeanjuice/ecs189L-back-to-the-jungle/pulls). Create a pull request with any title of your choosing. Make sure to fill out the pull request template.

3) Request a reviewer, and confirm the to-do list is complete.

4) Once complete, you can merge the completed sub-task into the `integration` branch.

---

# Style Guide

For all code, we will be, for the most part, adhering to the [.NET](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions) style guide. The most important thing is consistency.

For example, here are some things that may not follow the style guide, but be important to follow.

## Comments

Make sure to add the appropriate comments to your code. Additionally, for any public function, make sure to add an [XML comment](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags) to allow for any IDE to be able to read it. This will just make the code look a lot nicer.

In Rider, by typing `///` right above a function, it should auto-fill most of the XML information for you.

![Fast Triple Slash](https://github.com/beanbeanjuice/ecs189L-back-to-the-jungle/blob/master/github_images/XML_guide.gif)

Here is an example of how one may fill out a comment below.

```CSHARP
/// <summary>
/// This is some public function that does something.
/// </summary>
/// <param name="value">Some value description.</param>
/// <returns>Some description of the return value.</returns>
public bool SomePublicFunction(int value)
{
  return value + 1;
}
```

## If-Statements

Curly-braces can make code hard to read. They are definitely useful, but too many can cause issues. Following the same style as shown below can help minimize the issues, and help everyone be able to read the code well.

* An `if` statement with a single line.
```CSHARP
if (someBool) DoSomething();
```

* An `if-else` statement with a single line each.
```CSHARP
if (someBool)
  DoSomething1();
else
  DoSomething2();
```

* An `if` statement with multiple lines.
```CSHARP
if (someBool)
{
  DoSomething1();
  DoSomething2();
}
```

* An `if-else` statement, but one of them has multiple lines.
```CSHARP
if (someBool)
{
  DoSomething1();
}
else
{
  DoSomething2();
  DoSomething3();
}
```
