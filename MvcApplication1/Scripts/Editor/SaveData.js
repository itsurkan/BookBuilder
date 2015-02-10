////var editor = CKEDITOR.instances.editor;
////var newData = editor.getData().toString();
//var url = '@Url.Action("Save", "Editor")';
//var data = { CommentText: editor_data };


//function saveEditorData() {
//    alert(editor_data);
//    $.post(url, { CommentText: editor_data }, function (result) {

//    });

//};

//$('#Id').change(function () {
//    var selectedText = $(this).val();
//    if (selectedText != null && selectedText != '') {
//        $.getJSON('@Url.Action("Text","Admin")', { Id: selectedText }, function (text) {
//            CKEDITOR.instances['editor1'].setData(text);

//        });

//    }
//});


//function saveEditorData() {
//    var editor = CKEDITOR.instances.editor;
//    var newData = editor.getData().toString();
//    var send = JSON.stringify({ 'text': newData });
//    alert(send);

//    $.ajax({
//        type: 'POST',
//        contentType: "application/json; charset=utf-8",
//        url: 'Save',
//        dataType: 'json',
//        data: send,

//        success: function (context) {
//            debugger;
//            alert("Success");
//        },
//        error: function (data) {
//            debugger;
//            alert(data);
//        }
//    });
//    // Send it with jQuery Ajax
//    //$.ajax({
//    //    url: 'Save',
//    //    data: newData
//    //});

//    // Or store it anywhere...
//    // ...
//    // ...
//};



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