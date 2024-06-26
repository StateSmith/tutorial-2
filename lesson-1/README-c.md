# Confirm StateSmith plugin loaded
If the last step was successful, you should see something like below. Note the highlighted sections.

![](docs/ss-plugin-1.png)






<br>

# See Plugin How To Use Guide
The [Plugin How To Use Guide](https://github.com/StateSmith/StateSmith-drawio-plugin/wiki/How-To-Use) has lots of good tips with animated gifs.

[![](docs/how-to-preview.png)](https://github.com/StateSmith/StateSmith-drawio-plugin/wiki/How-To-Use)




<br>

# Add Another State
Open the `LightSm` group by either double clicking on the group in VS Code, or selecting the group and choosing `Arrange > Navigation > Enter Group` in the draw.io app.

Copy state `ON1` and rename it to `ON2`. Add transitions between the states.

(See [How To Use guide](https://github.com/StateSmith/StateSmith-drawio-plugin/wiki/How-To-Use) for more info about using the VS code plugin.)


![](./docs/add-state-on2.gif)

NOTE! draw.io allows drawing states that look grouped, but aren't and vice versa. This is a bit weird when you first encounter it. Easy to adapt to though once you understand how draw.io behaves. See [issue 81](https://github.com/StateSmith/StateSmith/issues/81) for more info.



<br>

# Add Transition Events
Select the transition from `ON1` to `ON2` and press `F2` to edit the transition label. Type in `INCREASE`.

Edit the other transition's label to be `DIM`.

![](./docs/add-transition-events.gif)





<br>

# Save and Generate
Save the file, and run the code generation again.
```
dotnet-script code_gen.csx
```
You should see the following:
```
StateSmith Runner - Compiling file: `LightSm.drawio.svg` (no state machine name specified).
StateSmith Runner - State machine `LightSm` selected.
StateSmith Runner - Writing to file `LightSm.js`.
StateSmith Runner - Finished normally.
```

Notice that our state machine now has a state for `ON2`.

![](./docs/run-code-gen-2.gif)





<br>

# draw.io Bugs 🐛
draw.io is a super awesome application, but it does have some bugs. Luckily, we can often have our plugin overcome them. Thank you open source!

You might encounter the "non-related nodes overlap" validation message. See [issue 81](https://github.com/StateSmith/StateSmith/issues/81) for fix.

If you run into an issue specific to draw.io, check our [draw.io plugin repo for issues](https://github.com/StateSmith/StateSmith-drawio-plugin/issues) and/or report there.

One draw.io vscode extension (not draw.io offline app) bug that you will likely bump into is that you should [exit all groups before saving](https://github.com/StateSmith/StateSmith-drawio-plugin/issues/25). Otherwise, draw.io will create an svg that is valid and can be used by StateSmith, but doesn't view properly.

There's also a [troubleshooting section](https://github.com/StateSmith/StateSmith-drawio-plugin/wiki/Troubleshooting) you can consult.




<br>

# Test It In The Browser 🌍
Same as before. Open `index.html` in a browser and send events to your state machine using the buttons.





<br>

# On To The Next Lesson
⏭️ Checkout the [lesson 2 README.md](../lesson-2/README.md).
