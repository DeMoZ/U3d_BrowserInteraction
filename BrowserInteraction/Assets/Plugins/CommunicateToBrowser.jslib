mergeInto(LibraryManager.library, {
    OnModelLoaded: function () {
        console.log("javascript: Unity loaded and can receive messages from browser.");
        // Pass message to the page
        OnUnityModelLoaded(); // This function is embeded into the page
    },

    SendString: function (value) {
        var msg = Pointer_stringify(value);
        console.log("javascript: SendString. " + msg);
        ReceiveString(msg);
    },

    SendNumber: function (value) {
        // var msg = Pointer_stringify(value);
        console.log("javascript: SendNumber. " + value);
        ReceiveNumber(value);
    },

    SendJson: function (value) {
        var msg = Pointer_stringify(value);
        console.log("javascript: SendJson. " + msg);
        ReceiveJson(msg);
    }
});