/*Code to refactor*/

//      function _ClickON_TheButton(THE_event, argumenti) {
//          var moqProzorec = window;
//          var brauzyra = moqProzorec.navigator.appCodeName;
//          var ism = brauzyra == "Mozilla";
//          if (ism) {
//              alert("Yes");
//          }
//          else {
//              alert("No");
//          }
//      }

function onClick(event, arguments) {
    var currentWindow = window;
    var browser = currentWindow.navigator.appCodeName;
    var isMozilla = (browser == "Mozilla");
    if (isMozilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}
