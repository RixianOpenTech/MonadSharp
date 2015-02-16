---
title:  "Introduction to MonadSharp"
date:   2015-02-16 22:37:00
categories: example
---

## What is MonadSharp? ##
MonadSharp is an experimental programming language written in C# which compiles into C#. It uses monads to automatically parallelize the code you write while still preserving the meaning of what was written. First you should read the following paper as a theoretical introduction to the reason MonadSharp was created, then come back and we will work through some examples:

[Computation at the Speed of Monads](http://rixianopentech.github.io/MonadSharp/Documents/ComputationAtTheSpeedOfMonadsPaper.pdf)


## How does it work? ##
The basic idea is that we can use a wrapped value instead of a raw value as parameters to functions and we will automatically get parallelism. The generated C# looks a little bit weird, but if you blur your eyes a bit you will see that it's no different than the regular C#, for example:

Original C# signature:
{% highlight c# %}
Console.WriteLine(string value);
{% endhighlight %}

Modified M# signature:
{% highlight c# %}
_Console.WriteLine(IObservable<string> value);
{% endhighlight %}
