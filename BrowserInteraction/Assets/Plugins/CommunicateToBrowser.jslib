mergeInto(LibraryManager.library, {
    OnModelLoaded: function (str) {
        var message = Pointer_stringify(str);
        console.log("javascript: Unity loaded and can receive messages from browser. " + message);
        // Pass message to the page
        OnUnityModelLoaded(message); // This function is embeded into the page
    },
    
    ToBrowserInfo: function(){
        BrowserInfo();
    }
});