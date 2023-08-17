window.autoRefresh = function () {
    try {
        setTimeout(function () {
            location.reload();
        }, 500); // Refresh every 5 seconds (adjust the time as needed)
    } catch  { }
   
};