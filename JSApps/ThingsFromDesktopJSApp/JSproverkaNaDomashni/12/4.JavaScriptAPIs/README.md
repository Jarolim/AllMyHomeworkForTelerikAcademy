## JavaScript APIs

1. Write a client-side based web application that consists of a trash bucket and lots of trash items in the browser window. Implement the following functionality:
  * Drag trash items
    * Open the bucket when a trash item is being dragged over it and close when the trash is dragged out of the bucket, or is dropped in the bucket
    * To throw a trash item into the bucket, i.e. make it disappear from the browser window

    ![Screenshot](https://raw.github.com/jasssonpet/TelerikAcademy/master/WebDesign/4.JavaScriptPartTwo/4.JavaScriptAPIs/1.TrashBin/index1.png)

    ![Screenshot](https://raw.github.com/jasssonpet/TelerikAcademy/master/WebDesign/4.JavaScriptPartTwo/4.JavaScriptAPIs/1.TrashBin/index2.png)
* Using the exercise with the bucket implement functionality for high-score
    * When the user cleans all the trash, he is asked for a nickname and his score is saved in the local storage
        * The score of the user is the time that took him to clean the trash
    * Implement a high-score board, that is visible on page load and shows the top 5 scores
        * The 5 users that cleaned the trash fastest
* Create shiv/shim/polyfill to enable `localStorage` and `sessionStorage` in browsers that do not support them
* Draw the following graphics using canvas:

    ![Screenshot](https://raw.github.com/jasssonpet/TelerikAcademy/master/WebDesign/4.JavaScriptPartTwo/4.JavaScriptAPIs/4.Drawings/index1.png)

    ![Screenshot](https://raw.github.com/jasssonpet/TelerikAcademy/master/WebDesign/4.JavaScriptPartTwo/4.JavaScriptAPIs/4.Drawings/index2.png)

    ![Screenshot](https://raw.github.com/jasssonpet/TelerikAcademy/master/WebDesign/4.JavaScriptPartTwo/4.JavaScriptAPIs/4.Drawings/index3.png)
* Draw a circle that flies inside a box
    * When it reaches an edge, it should bounce that edge

    ![Screenshot](https://raw.github.com/jasssonpet/TelerikAcademy/master/WebDesign/4.JavaScriptPartTwo/4.JavaScriptAPIs/5.Line/index.png)
* \* Create the famous game "Snake"
    * The snake is a sequence of rectangles/ellipses
    * The snake can move left, right, up or down
    * The snake dies if it reaches any of the edges or when it tries to eat itself
    * A food should be generated
        * When the snake eats the food, it grows and new food is generated at random position
    * Implement the game using OOP and canvas
    * Implement a high-score board, kept in `localStorage`
