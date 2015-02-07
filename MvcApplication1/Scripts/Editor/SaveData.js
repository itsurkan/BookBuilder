function saveEditorData() {
    var editor = CKEDITOR.instances.editor;
    var newData = editor.getData().toString();
    alert(newData);


    $.ajax({
        cache: false,
        async: true,
        type: "POST",
        url: "Save",
        data: newData,
        success: function(data) {
            debugger;
            alert(data);
        },
        error: function(data) {
            debugger;
            alert(data);
        }
    });
    // Send it with jQuery Ajax
    //$.ajax({
    //    url: 'Save',
    //    data: newData
    //});

    // Or store it anywhere...
    // ...
    // ...
};



//var savedData, newData;
//function saveEditorData() {
//    newData = editor.getData();
//    alert(newData);
//    if (newData !== savedData) {
//        savedData = newData;

//        // Send it with jQuery Ajax
//        $.ajax({
//            url: 'Save',
//            data: savedData
//        });

//        // Or store it anywhere...
//        // ...
//        // ...
//    }

//    saveEditorData();
//};

//// Start observing the data.
//saveEditorData();