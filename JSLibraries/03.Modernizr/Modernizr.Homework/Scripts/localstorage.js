var localStorageController = (function () {
    function saveAndLoadFromLocalStorage(){
        localStorage.lastname = "This is saved and loaded from local storage";
        document.getElementById("localstorage").innerHTML = localStorage.lastname;
    }

    return {
        saveAndLoad: saveAndLoadFromLocalStorage
    }

})();

localStorageController.saveAndLoad();